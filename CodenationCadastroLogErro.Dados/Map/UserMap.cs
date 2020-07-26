using System.Collections.Generic;
using System.Text;
using System;
using Microsoft.EntityFrameworkCore;
using CodenationCadastroLogErro.Dominio.Moldels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
