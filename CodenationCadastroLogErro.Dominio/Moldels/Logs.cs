using CodenationCadastroLogErro.Dominio.Repository;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace CodenationCadastroLogErro.Dominio.Moldels
{
    [Table("Logs")]
    public class Logs : IEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("titulo")]
        [MaxLength(500)]
        [Required]
        public String Titulo { get; set; }

        [Column("descricao")]
        [MaxLength(500)]
        [Required]
        public String Descricao { get; set; }

        [Column("detalhes")]
        [MaxLength(200)]
        [Required]
        public String Detalhes { get; set; }

        [Column("evento")]
        [Required]
        public int Evento { get; set; }
                
        [Column("origim")]
        [MaxLength(100)]
        [Required]
        public String Origim { get; set; }

        [Column("arquivar")]
        public bool Arquivar { get; set; }

        [Column("created_at")]
        [Required]
        public DateTime CreatedAt { get; set; }

        [Column("userId")]
        [ForeignKey("User")]
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        [Column("tipoLogId")]
        [ForeignKey("TipoLog")]
        [Required]
        public int TipoLogId { get; set; }
        public TipoLog TipoLog { get; set; }
    }
}
