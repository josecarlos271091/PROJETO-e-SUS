using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.sus.DTO
{
    /// <summary>
    /// Classe que transporta dados entre todas as camadas
    /// Tabela Usuario
    /// </summary>
    public class UsuarioDTO
    {
        public int idUsuario { get; set; }
        public string nomeUsuario { get; set; }
        public string senhaUsuario { get; set; }
    }
}
