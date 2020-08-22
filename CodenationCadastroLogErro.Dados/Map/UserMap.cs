using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CodenationCadastroLogErro.Dominio.Moldels;
using Microsoft.EntityFrameworkCore;

namespace CodenationCadastroLogErro.Dados.Map
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany<Logs>(log => log.Log)
                .WithOne(use => use.User)
                .HasForeignKey(use => use.UserId);           
        }
    }
}
