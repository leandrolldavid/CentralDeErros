using CodenationCadastroLogErro.Dominio.Moldels;
using FluentValidation;


namespace CodenationCadastroLogErro.Servico.Validador
{
    public class ValidadorLogs : AbstractValidator<Logs>
    {
        public ValidadorLogs()
        {
            RuleFor(log => log.Level).NotEmpty().Must(x => ConstaPalavara(x))
                .WithMessage("O level deve ser do tipo 'erro', 'debug' ou 'warning' ");
        }
        private bool ConstaPalavara(string x)
        {
            return x.Equals("erro") || x.Equals("debug") || x.Equals("warning");
        }

    }
}
