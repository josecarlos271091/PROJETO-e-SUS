using com.sus.DAL;
using com.sus.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.sus.Bussiness
{
    public class UsuariosBussiness : UsuarioDAL
    {
        //criando variável protegida
        private UsuarioDAL _usuarioDAL;

        /// <summary>
        /// Gerando método construtor
        /// </summary>
        public UsuariosBussiness()
        {
            if (_usuarioDAL == null)
                _usuarioDAL = new UsuarioDAL();
        }

        /// <summary>
        /// Método que busca todas os Usuarios
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable buscarUsuarios()
        {
            try
            {
                return _usuarioDAL.buscarTodosUsuarios();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Método que atualiza os Dados do Usuario
        /// </summary>
        /// <returns>DataTable</returns>
        public Boolean atualizarUsuario(UsuarioDTO _usuarioDTO)
        {
            try
            {
                if (_usuarioDAL.atualizarUsuario(_usuarioDTO))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
