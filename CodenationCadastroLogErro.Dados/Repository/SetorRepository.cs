using CodenationCadastroLogErro.Dominio.Moldels;
using CodenationCadastroLogErro.Dominio.Repository;

namespace CodenationCadastroLogErro.Dados.Repository
{
    public class SetorRepository : RepositorioBase<Setor>, ISetorRepository
    {
        public SetorRepository(CodenationContext contexto)
            : base(contexto)
        {
        }
    }
}
