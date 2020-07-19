using CodenationCadastroLogErro.Dominio.Repository;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

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

        public ICollection<User> Users { get; set; }
    }
}
