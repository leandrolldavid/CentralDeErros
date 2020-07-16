using CodenationCadastroLogErro.Dominio.Moldels;
using CodenationCadastroLogErro.Dominio.Repository;

namespace CodenationCadastroLogErro.Dados.Repository
{
    public class LogsRepository : RepositorioBase<Logs>, ILogsRepository
    {

        public LogsRepository(CodenationContext contexto)
            : base(contexto)
        {
        }
    }
}
