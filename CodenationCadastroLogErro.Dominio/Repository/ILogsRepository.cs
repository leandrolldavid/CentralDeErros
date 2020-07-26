using CodenationCadastroLogErro.Dominio.Dtos;
using CodenationCadastroLogErro.Dominio.Moldels;
using System.Collections.Generic;

namespace CodenationCadastroLogErro.Dominio.Repository
{
    public interface ILogsRepository : IRepositorioBase<Logs>
    {
        string Arquivar(LogDto log);
        List<LogQuery> SelecionarLog(int id);
        List<LogQuery> OrdernaPorLevel();
        List<LogQuery> OrdernaPorFrequencia();
        List<LogQuery> SelecionarPorSetor(int id);
        List<LogQuery> Listar();
    }
}
