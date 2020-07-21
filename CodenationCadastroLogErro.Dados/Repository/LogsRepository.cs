using CodenationCadastroLogErro.Dominio.Dtos;
using CodenationCadastroLogErro.Dominio.Moldels;
using CodenationCadastroLogErro.Dominio.Repository;
using CodenationCadastroLogErro.Recursos;
using CodenationCadastroLogErro.Servico.Validador;
using System;
using System.Linq;

namespace CodenationCadastroLogErro.Dados.Repository
{
    public class LogsRepository : RepositorioBase<Logs>, ILogsRepository
    {
        private readonly ValidadorLogs _validador;
        public LogsRepository(CodenationContext contexto)
            : base(contexto)
        {
           _validador = new ValidadorLogs();
        }
        public string Incluir(Logs log)
        {
            var validarResultado = _validador.Validate(log);
            if (!validarResultado.IsValid.Equals(true)) throw new Exception(validarResultado.ToString());
            _contexto.Logs.Add(log);
            _contexto.SaveChanges();
            return string.Format("O '{0} {1}'", log.Level, MensagensErro.Ok);
        }
        public string Arquivar(LogDto user)
        {
            var entity = _contexto.Logs.FirstOrDefault(x => x.Id == user.Id);
            entity.Arquivar = true;
            _contexto.Logs.Update(entity);
            _contexto.SaveChanges();
            return MensagensErro.Alterar;
        }
    }
}
