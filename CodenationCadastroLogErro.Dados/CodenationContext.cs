using CodenationCadastroLogErro.Dados.Map;
using CodenationCadastroLogErro.Dominio.Moldels;
using Microsoft.EntityFrameworkCore;

namespace CodenationCadastroLogErro.Dados
{
    public class CodenationContext : DbContext
    {
        public DbSet<Logs> Logs { get; set; }
        public DbSet<User> Users { get; set; }
                
        // this constructor is for enable testing with in-memory data
        public CodenationContext(DbContextOptions<CodenationContext> options)
            : base(options)
        {             
        }

        public CodenationContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new LogsMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}