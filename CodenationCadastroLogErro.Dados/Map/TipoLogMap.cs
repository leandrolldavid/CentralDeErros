﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CodenationCadastroLogErro.Dominio.Moldels;
using Microsoft.EntityFrameworkCore;

namespace CodenationCadastroLogErro.Dados.Map
{
    public class TipoLogMap : IEntityTypeConfiguration<TipoLog>
    {
        public void Configure(EntityTypeBuilder<TipoLog> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany<Logs>(log => log.Logs)
               .WithOne(tipolog => tipolog.TipoLog)
               .HasForeignKey(tipolog => tipolog.TipoLogId);
        }
    }
}
