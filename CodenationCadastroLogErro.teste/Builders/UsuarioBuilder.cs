using CodenationCadastroLogErro.Dominio.Moldels;
using System;

namespace CodenationCadastroLogErro.Teste.Builders
{
    public class UsuarioBuilder
    {
        private string _Username = "João da silva";
        private string _Password = "Silvinha01";
        private string _Email = "Joao@joao.com";
        private DateTime _CreatedAt = DateTime.Now;

        public UsuarioBuilder SemNome(string nome)
        {
            _Username = nome;
            return this;
        }
        public UsuarioBuilder SemSenha(string senha)
        {
            _Password = senha;
            return this;
        }
        public UsuarioBuilder SemEmail(string email)
        {
            _Email = email;
            return this;
        }
     
        public User ConstruirUser()
        {
            return new User()
            {
                Username = _Username,
                Password = _Password,
                Email = _Email,
                CreatedAt =_CreatedAt,
            };
        }
       
    }
}
