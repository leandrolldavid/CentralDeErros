using CodenationCadastroLogErro.Dominio.Dtos;
using CodenationCadastroLogErro.Dominio.Moldels;

namespace CodenationCadastroLogErro.Dominio.Repository
{
    public interface ILogsRepository : IRepositorioBase<Logs>
    {
        string Incluir(Logs log);
        string Arquivar(LogDto log);

    }
}
