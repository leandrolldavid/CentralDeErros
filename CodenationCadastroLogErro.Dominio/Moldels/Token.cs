using System;
namespace CodenationCadastroLogErro.Dominio.Moldels
{
    public class Token
    {
        public String Secret { get; set; }
        public int ExpiracaoHoras  { get; set; }
        public String Emissor { get; set; }//ValidIssuer Http://192.168.10.103:5000
        public String ValidoEm { get; set; }//ValidAudience 
    }
}
