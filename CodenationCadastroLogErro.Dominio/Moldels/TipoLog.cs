using CodenationCadastroLogErro.Dominio.Repository;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace CodenationCadastroLogErro.Dominio.Moldels
{
    [Table("TipoLog")]
    public class TipoLog : IEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("level")]
        [MaxLength(100)]
        [Required]
        //{error Debug warning}
        public String Level { get; set; }

        public virtual ICollection<Logs> Logs { get; set; }
    }
}
