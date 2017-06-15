using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.sus.DTO
{
    /// <summary>
    /// Classe que transporta dados entre todas as camadas
    /// Tabela Producao
    /// </summary>
    public class ProducaoDTO
    {
        public int idProducao { get; set; }
        public int idUsuario { get; set; }
        public int idMes { get; set; }
        public int totalAtend { get; set; }
        public int consultasAgendadas { get; set; }
        public int atendPreNatal { get; set; }
        public int atendPuericultura { get; set; }
        public int atendHipertensos { get; set; }
        public int atendDiabeticos { get; set; }
        public int atendAsma { get; set; }
        public int atendMental { get; set; }
        public int atendAlcDrogas { get; set; }
        public int atendTuberculose { get; set; }
        public int atendHanseniase { get; set; }
        public int atendCancerUtero { get; set; }
        public int atendCancerMama { get; set; }
        public int visitasDomic { get; set; }
        public int atColetivas { get; set; }
        public int encaminHospital { get; set; }
    }
}
