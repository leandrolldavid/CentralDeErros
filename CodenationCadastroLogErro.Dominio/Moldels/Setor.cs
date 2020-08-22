using CodenationCadastroLogErro.Dominio.Repository;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace CodenationCadastroLogErro.Dominio.Moldels
{
    [Table("Setor")]
    public class Setor : IEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        [MaxLength(200)]
        [Required]
        public String Nome { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
