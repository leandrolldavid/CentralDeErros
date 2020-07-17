using CodenationCadastroLogErro.Dados;
using CodenationCadastroLogErro.Dados.Repository;
using CodenationCadastroLogErro.Dominio.Moldels;
using CodenationCadastroLogErro.Dominio.Repository;
using CodenationCadastroLogErro.Servico.Servicos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;


namespace CodenationCadastroLogErro.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();// parar o fluxo de referencia ciclicar do Json =>
            //.AddNewtonsoftJson(Options => Options.SerializerSettings.ReferenceLoopHandling = 
           //  Newtonsoft.Json.ReferenceLoopHandling.Ignore);

           // services.AddMvc(Options => Options.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            //services.AddAutoMapper(typeof(Startup));
            //injeção de dependencia 
            services.AddScoped(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ILogsRepository, LogsRepository>();
            services.AddScoped<IGerarToken, GerarToken>();
            

            var section = Configuration.GetSection("token");
            services.Configure<Token>(section);

            var token = section.Get<Token>();
            var key = Encoding.ASCII.GetBytes(token.Secret);//linha do JWT
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;//true
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidAudience = token.ValidoEm,
                        ValidIssuer = token.Emissor,
                        ValidateLifetime = true,  //verificar vadidade do token
                         
                    };
                });
            services.AddAuthorization(auth =>
            {//ativar o uso do token para autorizar o acesso
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
              //  auth.AddPolicy("admin", policy => policy.RequireClaim(ClaimTypes.Role, "admin"));
               // auth.AddPolicy("user", policy => policy.RequireClaim(ClaimTypes.Role, "user"));
            });
            services.AddMvcCore().AddAuthorization(opt =>
            {
                opt.AddPolicy("Admin", policy => policy.RequireClaim(ClaimTypes.Role,"Admin"));
                opt.AddPolicy("User", policy => policy.RequireClaim(ClaimTypes.Role,"User"));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            /*
             */
            services.AddDbContext<CodenationContext>(options => options.UseSqlServer(Configuration.GetConnectionString("CentralDeErros")));
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseHttpsRedirection(); //forçar a usar o https
              app.UseRouting();
            /*
             */
              app.UseAuthentication();
              app.UseAuthorization();
              app.UseEndpoints(endpoints =>
              {
                  endpoints.MapControllers();
              });
            app.UseCors(config =>
            {
                config.AllowAnyHeader();
                config.AllowAnyMethod();
                config.AllowAnyOrigin();
            } );
          //    app.UseMvc();
        }
    }
}
