using System;

namespace CodenationCadastroLogErro.Dominio.Dtos
{
    public class LogQuery
    {
        public int Id { get; set; }
        public string Origim { get; set; }//
        public DateTime CreatedAt { get; set; }//
        public string Titulo { get; set; }
        public string Detalhes { get; set; }
        public string Level { get; set; }//
        public int Evento { get; set; }//
        public string Arquivar { get; set; }
        public string Usuario { get; set; }
        public string Setor { get; set; }
        public string Descricao { get; set; }
    }
}
