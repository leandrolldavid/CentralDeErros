using System;

namespace CodenationCadastroLogErro.Dominio.Dtos
{
    public class UserDto 
    {
        public String Email { get; set; }
        public String Password { get; set; }
    }
    public class UserRoleDto
    {
        public int Id { get; set; }
        public String Role { get; set; }

    } 
}
