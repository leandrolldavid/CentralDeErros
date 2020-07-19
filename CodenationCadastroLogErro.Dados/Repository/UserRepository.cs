using CodenationCadastroLogErro.Dominio.Dtos;
using CodenationCadastroLogErro.Dominio.Moldels;
using CodenationCadastroLogErro.Dominio.Repository;
using CodenationCadastroLogErro.Resursos;
using FluentValidation.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

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

        public string  Login(UserDto user)
        {
            var entity = _contexto.Users.FirstOrDefault(x => x.Email == user.Email);
            if (entity is null) return null ;
            if (entity.Password.Equals(user.Password))
            {
                return _gerarToken.GerarOFToken(entity);
            }
            return null;

        }
        public void inserirRole(User user)
        {
            _contexto.Users.Update(user);
        }
    }
}
