using CodenationCadastroLogErro.Dominio.Dtos;
using CodenationCadastroLogErro.Dominio.Moldels;

namespace CodenationCadastroLogErro.Dominio.Repository
{
    public interface IUserRepository : IRepositorioBase<User>
    {
        string Login(UserDto User);
        string InserirRole(UserRoleDto user);
        string Cadastrar(User user);
    }
}
