using CodenationCadastroLogErro.Dominio.Dtos;
using CodenationCadastroLogErro.Dominio.Moldels;
using System.Threading.Tasks;

namespace CodenationCadastroLogErro.Dominio.Repository
{
    public interface IUserRepository : IRepositorioBase<User>
    {
        string Login(UserDto User);
        string InserirRole(UserRoleDto user);
        string Incluir(User user);
    }
}
