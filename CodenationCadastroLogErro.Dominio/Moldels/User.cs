using CodenationCadastroLogErro.Dominio.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CodenationCadastroLogErro.Dominio.Moldels
{
    [Table("Usuario")]
    public class User : IEntity
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("name")]
        [MaxLength(255)]
        [Required]
        public String Username { get; set; }

        [Column("email")]
        [StringLength(255)]
        [Required]
        public String Email { get; set; }

        [Column("password")]
        [MaxLength(255)]
        [Required]
        public String Password { get; set; }

        [Column("role")]
        [MaxLength(100)]
        public string Role { get; set; }

        [Column("created_at")]
        [Required]
        public DateTime CreatedAt { get; set; }
       
        public ICollection<Logs> Logs { get; set; }
    }
}
