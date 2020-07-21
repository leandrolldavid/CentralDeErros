using CodenationCadastroLogErro.Dominio.Dtos;
using CodenationCadastroLogErro.Dominio.Moldels;
using System.Threading.Tasks;

namespace CodenationCadastroLogErro.Dominio.Repository
{
    public interface IUserRepository : IRepositorioBase<User>
    {//colocar metodos que nao fazem parte do crud generico
        string Login(UserDto User);
        string InserirRole(UserRoleDto user);
        string Incluir(User user);
    }
}
