using CodenationCadastroLogErro.Dominio.Dtos;
using CodenationCadastroLogErro.Dominio.Moldels;

namespace CodenationCadastroLogErro.Dominio.Repository
{
    public interface IUserRepository : IRepositorioBase<User>
    {//colocar metodos que nao fazem parte do crud generico
        string Login(UserDto User);
        void inserirRole(User user);
    }
}
