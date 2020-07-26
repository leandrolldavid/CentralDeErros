using CodenationCadastroLogErro.Dominio.Moldels;

namespace CodenationCadastroLogErro.Dominio.Repository
{
    public interface ITipoLogRepository : IRepositorioBase<TipoLog>
    {
        string Cadastrar(TipoLog tipoLog);
    }
}
