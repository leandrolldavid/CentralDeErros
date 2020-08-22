using Microsoft.AspNetCore.Authentication.JwtBearer;
using CodenationCadastroLogErro.Dominio.Repository;
using CodenationCadastroLogErro.Servico.Servicos;
using CodenationCadastroLogErro.Dados.Repository;
using CodenationCadastroLogErro.Dominio.Moldels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using CodenationCadastroLogErro.Dados;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
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
            // parar o fluxo de referencia ciclicar do Json instalar o pakote NewtonsofJson=>
            services.AddControllers()
          .AddNewtonsoftJson(Options => Options.SerializerSettings.ReferenceLoopHandling =
                                Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddMvc()
            .AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<Startup>());
            services.AddMvc().AddJsonOptions(opcoes =>
            { // ignore valores nulos
                opcoes.JsonSerializerOptions.IgnoreNullValues = true;
            });
            // services.AddMvc(Options => Options.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            //services.AddAutoMapper(typeof(Startup));
            //injeção de dependencia 
            services.AddScoped(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ILogsRepository, LogsRepository>();
            services.AddScoped<ISetorRepository, SetorRepository>();
            services.AddScoped<ITipoLogRepository, TipoLogRepository>();
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
            });
            services.AddMvcCore().AddAuthorization(opt =>
            {
                opt.AddPolicy("admin", policy => policy.RequireClaim(ClaimTypes.Role, "admin"));
                opt.AddPolicy("user", policy => policy.RequireClaim(ClaimTypes.Role, "user"));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddDbContext<CodenationContext>(options => options.UseSqlServer(Configuration.GetConnectionString("CentralDeErros")));

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc(name: "v1", new OpenApiInfo
                {
                    Title = "Central de Erros",
                    Version = "v1"
                });
                x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."

                });
                x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Api Central de Erros");
            });
            app.UseHttpsRedirection(); //forçar a usar o https

            app.UseRouting();

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
            });
            //    app.UseMvc();
        }
    }
}
