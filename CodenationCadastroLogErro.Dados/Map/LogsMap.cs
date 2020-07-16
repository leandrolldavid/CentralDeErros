using CodenationCadastroLogErro.Dominio.Moldels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CodenationCadastroLogErro.Dados.Map
{
    class LogsMap : IEntityTypeConfiguration<Logs>
    {
        public void Configure(EntityTypeBuilder<Logs> builder)
        {
            builder.HasKey(x => x.Id);
            // builder.HasKey(x => new { x.Id });
        }
    }
}
