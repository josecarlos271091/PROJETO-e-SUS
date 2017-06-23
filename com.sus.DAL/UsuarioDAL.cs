using com.sus.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.sus.DAL
{
    public class UsuarioDAL
    {
        /// <summary>
        /// Método que busca todas os Usuarios 
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable buscarTodosUsuarios()
        {
            try
            {
                using (SqlConnection _connection = new
                    SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MinhaConexao"].ToString()))
                {
                    DataSet _dtSet = new DataSet();

                    //abrir a conexao com o banco de dados
                    _connection.Open();

                    //usando objeto desconectado e informando o parametro com a variavel de conexao
                    SqlDataAdapter _dtAdapter = new SqlDataAdapter();
                    _dtAdapter.SelectCommand = new SqlCommand("SELECT * FROM Usuario", _connection);

                    //preenche o objeto para ficar desconectado
                    _dtAdapter.Fill(_dtSet);

                    //retorna o data table na posicao 0
                    return _dtSet.Tables[0];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método que inserta um usuario 
        /// </summary>
        /// <returns>Boolean</returns>
        public Boolean insertarUsuario(UsuarioDTO dto)
        {
            try
            {
                using (SqlConnection _connection = new
                    SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MinhaConexao"].ToString()))
                {

                    var sql = "INSERT INTO Usuario VALUES (@nomeUsuario,@senhaUsuario)";

                    //Instancia um novo comando com uma consulta e uma conexão
                    using (SqlCommand _sqlComm = new SqlCommand(sql, _connection))
                    {
                        _sqlComm.Parameters.Add("@nomeUsuario", SqlDbType.VarChar).Value = dto.nomeUsuario;
                        _sqlComm.Parameters.Add("@senhaUsuario", SqlDbType.VarChar).Value = dto.senhaUsuario;

                        //Abrir a conexao com o banco de dados
                        _connection.Open();

                        //Chama o método ExecuteNonQuery para enviar o comando
                        _sqlComm.ExecuteNonQuery();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método que deleta um Usuario 
        /// </summary>
        /// <returns>Boolean</returns>
        public Boolean deletUsuario(UsuarioDTO dto)
        {
            try
            {
                using (SqlConnection _connection = new
                    SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MinhaConexao"].ToString()))
                {

                    var sql = "DELETE FROM Usuario WHERE idUsuario = @idUsuario";

                    //Instancia um novo comando com uma consulta e uma conexão
                    using (SqlCommand _sqlComm = new SqlCommand(sql, _connection))
                    {
                        _sqlComm.Parameters.Add("@idUsuario", SqlDbType.Int).Value = dto.idUsuario;

                        //Abrir a conexao com o banco de dados
                        _connection.Open();

                        //Chama o método ExecuteNonQuery para enviar o comando
                        _sqlComm.ExecuteNonQuery();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método Update 
        /// </summary>
        /// <returns>Boolean</returns>
        public Boolean atualizarUsuario(UsuarioDTO dto)
        {
            try
            {
                using (SqlConnection _connection = new
                    SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MinhaConexao"].ToString()))
                {

                    var sql = "UPDATE Usuario SET nomeUsuario=@nomeUsuario, senhaUsuario=@senhaUsuario WHERE idUsuario=@idUsuario";

                    //Instancia um novo comando com uma consulta e uma conexão
                    using (SqlCommand _sqlComm = new SqlCommand(sql, _connection))
                    {
                        _sqlComm.Parameters.Add("@idUsuario", SqlDbType.Int).Value = dto.idUsuario;
                        _sqlComm.Parameters.Add("@nomeUsuario", SqlDbType.VarChar).Value = dto.nomeUsuario;
                        _sqlComm.Parameters.Add("@senhaUsuario", SqlDbType.VarChar).Value = dto.senhaUsuario;

                        //Abrir a conexao com o banco de dados
                        _connection.Open();

                        //Chama o método ExecuteNonQuery para enviar o comando
                        _sqlComm.ExecuteNonQuery();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
