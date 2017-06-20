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
    public class ProducaoBussiness: com.sus.DAL.ProducaoDAL
    {
        //criando variável protegida
        private ProducaoDAL _producaoDAL;

        /// <summary>
        /// Gerando método construtor
        /// </summary>
        public ProducaoBussiness()
        {
            if (_producaoDAL == null)
                _producaoDAL = new ProducaoDAL();
        }

        /// <summary>
        /// Método que busca todas as Producoes
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable buscarProducoes()
        {
            try
            {
                return _producaoDAL.buscarTodasProducoes();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Método busca uma producao e retorna tabela a exportar
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable pesquisarExportarProducao(int idUsuario, int idMes)
        {
            try
            {
                return _producaoDAL.pesquisarExportarProducao(idUsuario,idMes);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Método que busca Producao pelo id
        /// </summary>
        /// <returns>ProducaoDTO</returns>
        public ProducaoDTO ObterProducao(int idUsuario, int idMes)
        {
            try
            {
                return _producaoDAL.ObterProducao(idUsuario, idMes);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Método que inserta Producao
        /// </summary>
        /// <returns>DataTable</returns>
        public void insertarProducao()
        {
            try
            {
                ProducaoDTO _producaoDTO = new ProducaoDTO();
                _producaoDAL.insertarProducao(_producaoDTO);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Método que deleta producao
        /// </summary>
        /// <returns>void</returns>
        public Boolean deletarProducao(int idProducao)
        {
            try
            {
                if (_producaoDAL.deletProducao(idProducao))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Método que deleta producao
        /// </summary>
        /// <returns>void</returns>
        public void deletALLProducoes(int idUsuario)
        {
            try
            {
                _producaoDAL.deletALLProducoes(idUsuario);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Método que atualiza o Nome da producao 
        /// </summary>
        /// <returns>DataTable</returns>
        public Boolean atualizarProducao(ProducaoDTO _producaoDTO)
        {
            try
            {
                if (_producaoDAL.atualizarProducao(_producaoDTO))
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
