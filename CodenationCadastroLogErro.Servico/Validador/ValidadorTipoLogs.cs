using CodenationCadastroLogErro.Dominio.Moldels;
using FluentValidation;


namespace CodenationCadastroLogErro.Servico.Validador
{
    public class ValidadorTipoLogs : AbstractValidator<TipoLog>
    {
        public ValidadorTipoLogs()
        {
            RuleFor(log => log.Level).NotEmpty().Must(x => ConstaPalavara(x))
                .WithMessage("O campo level deve ser do tipo 'Error', 'Debug' ou 'Warning' ");
        }
        private bool ConstaPalavara(string x)
        {
            return x.Equals("Error") || x.Equals("Debug") || x.Equals("Warning");
        }

    }
}
