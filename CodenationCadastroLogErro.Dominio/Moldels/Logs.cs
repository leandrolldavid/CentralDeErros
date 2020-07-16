using CodenationCadastroLogErro.Dominio.Repository;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodenationCadastroLogErro.Dominio.Moldels
{
    [Table("Logs")]
    public class Logs : IEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("description")]
        [MaxLength(500)]
        [Required]
        public String Description { get; set; }

        [Column("details")]
        [MaxLength(500)]
        [Required]
        //{erro Debug warning}
        public String Details { get; set; }

        [Column("level")]
        [MaxLength(20)]
        [Required]
        public String Level { get; set; }

        [Column("origin")]
        [MaxLength(39)]
        [Required]
        public String Origin { get; set; }

        [Column("created_at")]
        [Required]
        public DateTime CreatedAt { get; set; }

        [Column("userId")]
        [ForeignKey("User")]
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
