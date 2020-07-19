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
            RuleFor(usuario => usuario.Username).NotEmpty().WithMessage("Nome inválido");
            RuleFor(usuario => usuario.Password).MinimumLength(6).Must(x=> ContainUpperLetter(x) && ContainLowerLetter(x) && ContainNumber(x))
                .WithMessage("A senha deve ter no mínimo 6 caracteres, com um letra um numero e uma letra maiuscula ");
            RuleFor(usuario => usuario.Email).NotEmpty().WithMessage("E-mail inválido");
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
