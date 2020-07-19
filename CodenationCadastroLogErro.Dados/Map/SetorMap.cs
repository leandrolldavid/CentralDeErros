using CodenationCadastroLogErro.Dominio.Moldels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodenationCadastroLogErro.Dados.Map
{
    class SetorMap : IEntityTypeConfiguration<Setor>
    {
        public void Configure(EntityTypeBuilder<Setor> builder)
        {
            builder.HasKey(x => x.Id);
            // builder.HasKey(x => new { x.Id });
            builder.HasMany<User>(setor => setor.Users)
                .WithOne(use => use.Setor)
                .HasForeignKey(use => use.SetorId);
        }
    }
}
