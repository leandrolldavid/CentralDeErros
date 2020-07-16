using CodenationCadastroLogErro.Dominio.Moldels;
using FluentValidation;
using System;
using System.Linq;

namespace CodenationCadastroLogErro.Servico.Validador
{
    public class ValidadorUsuario : AbstractValidator<User>
    {
        public ValidadorUsuario()
        {
            RuleFor(usuario => usuario.Username).NotEmpty();
            RuleFor(usuario => usuario.Password).MinimumLength(6).Must(x=> ContainUpperLetter(x) && ContainLowerLetter(x) && ContainNumber(x));
            RuleFor(usuario => usuario.Email).NotEmpty();
        }

        private bool ContainNumber(string x)
        {
            return x.Any(char.IsNumber);
        }

        private bool ContainLowerLetter(string x)
        {
            return x.Any(char.IsLower);
        }

        private bool ContainUpperLetter(string x)
        {
            return x.Any(char.IsUpper);
        }

    }
}
