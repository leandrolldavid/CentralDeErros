using CodenationCadastroLogErro.Dominio.Dtos;
using CodenationCadastroLogErro.Dominio.Moldels;
using CodenationCadastroLogErro.Dominio.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace CodenationCadastroLogErro.Dados.Repository
{
    public class UserRepository : RepositorioBase<User>, IUserRepository
    {
        private readonly IGerarToken _gerarToken;
        public UserRepository(CodenationContext contexto,IGerarToken gerarToken)
            : base(contexto)
        {
            _gerarToken = gerarToken;
        }

        public string Login(UserDto user)
        {
            var entity = _contexto.Users.FirstOrDefault(x => x.Email == user.Email);
            if (entity.Password.Equals(user.Password))
            {
                return _gerarToken.GerarOFToken(entity);
            }
            return null;
        }
        public List<User> SelecionarUltimoRegistro()
        {
            return _contexto.Users.OrderByDescending(x => x.Id)
                    .Take(1).ToList();
        }
    }
}
