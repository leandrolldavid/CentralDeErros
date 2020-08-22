using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CodenationCadastroLogErro.Dominio.Moldels;
using Microsoft.EntityFrameworkCore;

namespace CodenationCadastroLogErro.Dados.Map
{
    class SetorMap : IEntityTypeConfiguration<Setor>
    {
        public void Configure(EntityTypeBuilder<Setor> builder)
        {
            builder.HasKey(x => x.Id);
           // builder.HasKey(x => new { x.Id });
            builder.HasMany<User>(u => u.Users)
                .WithOne(s => s.Setor)
                .HasForeignKey(s => s.SetorId);
        }
    }
}
