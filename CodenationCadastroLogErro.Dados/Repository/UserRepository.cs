using CodenationCadastroLogErro.Dominio.Dtos;
using CodenationCadastroLogErro.Dominio.Moldels;
using CodenationCadastroLogErro.Dominio.Repository;
using CodenationCadastroLogErro.Recursos;
using CodenationCadastroLogErro.Servico.Validador;
using System;
using System.Linq;

namespace CodenationCadastroLogErro.Dados.Repository
{
    public class UserRepository : RepositorioBase<User>, IUserRepository
    {
        private readonly IGerarToken _gerarToken;
        private readonly ValidadorUsuario _validador;


        public UserRepository(CodenationContext contexto,IGerarToken gerarToken)
            : base(contexto)
        {
            _gerarToken = gerarToken;
            _validador = new ValidadorUsuario();
        }

        public string Incluir(User user)
        {
            var validarResultado = _validador.Validate(user);
            if (!validarResultado.IsValid.Equals(true)) throw new Exception(validarResultado.ToString());
            if (!EmailEstaEmUso(user.Email).Equals(false)) throw new Exception(MensagensErro.verificarEmail);
            user.Role = "user";
            _contexto.Users.Add(user);
            _contexto.SaveChanges();
            return string.Format("Usuario '{0} {1}'", user.Username, MensagensErro.Ok); 
        }
        public string Login(UserDto user)
        {
            var entity = _contexto.Users.FirstOrDefault(x => x.Email == user.Email);
            if (entity is null) throw new Exception(MensagensErro.Login);
            if (!entity.Password.Equals(user.Password))
            {
                throw new Exception(MensagensErro.Login);
            }
                return _gerarToken.GerarOFToken(entity);
        }
        public string InserirRole(UserRoleDto user)
        {
            var entity = _contexto.Users.FirstOrDefault(x => x.Id == user.Id);
            entity.Role = user.Role;
            _contexto.Users.Update(entity);
            _contexto.SaveChanges();
            return MensagensErro.Alterar;
        }
        public bool EmailEstaEmUso(string email)
        {
            return _contexto.Users.Any(x => x.Email == email);
        }
    }
}
