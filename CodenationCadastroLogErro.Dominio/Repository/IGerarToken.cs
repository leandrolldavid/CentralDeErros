using CodenationCadastroLogErro.Dominio.Moldels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodenationCadastroLogErro.Dominio.Repository
{
    public interface IGerarToken
    {
        string GerarOFToken(User usuario);
    }
}
