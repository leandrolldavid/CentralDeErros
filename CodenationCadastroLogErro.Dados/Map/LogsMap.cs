﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CodenationCadastroLogErro.Dominio.Moldels;
using Microsoft.EntityFrameworkCore;

namespace CodenationCadastroLogErro.Dados.Map
{
    class LogsMap : IEntityTypeConfiguration<Logs>
    {
        public void Configure(EntityTypeBuilder<Logs> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
