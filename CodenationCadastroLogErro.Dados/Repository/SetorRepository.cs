using CodenationCadastroLogErro.Dominio.Moldels;
using CodenationCadastroLogErro.Dominio.Repository;
using System;
using System.Collections.Generic;
using System.Text;

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
