using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.sus.DTO;
using System.Data;
using System.Data.SqlClient;

namespace com.sus.DAL
{
    class ProducaoDAL
    {
        /// <summary>
        /// Método que busca todas Producoes 
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable buscarTodasProducoes()
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
                    _dtAdapter.SelectCommand = new SqlCommand("SELECT * FROM Producao", _connection);

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
        /// Método que inserta uma producao 
        /// </summary>
        /// <returns>Boolean</returns>
        public Boolean insertarProducao(ProducaoDTO dto)
        {
            try
            {
                using (SqlConnection _connection = new
                    SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MinhaConexao"].ToString()))
                {

                    var sql = "INSERT INTO Producao VALUES (@idUsuario,@idMes,@totalAtend,@consultasAgendadas,@atendPreNatal,@atendPuericultura,@atendHipertensos,@atendDiabeticos,@atendAsma,@atendMental,@atendAlcDrogas,@atendTuberculose,@atendHanseniase,@atendCancerUtero,@atendCancerMama,@visitasDomic,@atColetivas,@encaminHospital)";

                    //Instancia um novo comando com uma consulta e uma conexão
                    using (SqlCommand _sqlComm = new SqlCommand(sql, _connection))
                    {
                        _sqlComm.Parameters.Add("@idUsuario", SqlDbType.Int).Value = dto.idUsuario;
                        _sqlComm.Parameters.Add("@idMes", SqlDbType.Int).Value = dto.idMes;
                        _sqlComm.Parameters.Add("@totalAtend", SqlDbType.Int).Value = dto.totalAtend;
                        _sqlComm.Parameters.Add("@consultasAgendadas", SqlDbType.Int).Value = dto.consultasAgendadas;
                        _sqlComm.Parameters.Add("@atendPreNatal", SqlDbType.Int).Value = dto.atendPreNatal;
                        _sqlComm.Parameters.Add("@atendPuericultura", SqlDbType.Int).Value = dto.atendPuericultura;
                        _sqlComm.Parameters.Add("@atendHipertensos", SqlDbType.Int).Value = dto.atendHipertensos;
                        _sqlComm.Parameters.Add("@atendDiabeticos", SqlDbType.Int).Value = dto.atendDiabeticos;
                        _sqlComm.Parameters.Add("@atendAsma", SqlDbType.Int).Value = dto.atendAsma;
                        _sqlComm.Parameters.Add("@atendMental", SqlDbType.Int).Value = dto.atendMental;
                        _sqlComm.Parameters.Add("@atendAlcDrogas", SqlDbType.Int).Value = dto.atendAlcDrogas;
                        _sqlComm.Parameters.Add("@atendTuberculose", SqlDbType.Int).Value = dto.atendTuberculose;
                        _sqlComm.Parameters.Add("@atendHanseniase", SqlDbType.Int).Value = dto.atendHanseniase;
                        _sqlComm.Parameters.Add("@atendCancerUtero", SqlDbType.Int).Value = dto.atendCancerUtero;
                        _sqlComm.Parameters.Add("@atendAlcDrogas", SqlDbType.Int).Value = dto.atendAlcDrogas;
                        _sqlComm.Parameters.Add("@visitasDomic", SqlDbType.Int).Value = dto.visitasDomic;
                        _sqlComm.Parameters.Add("@atColetivas", SqlDbType.Int).Value = dto.atColetivas;
                        _sqlComm.Parameters.Add("@encaminHospital", SqlDbType.Int).Value = dto.encaminHospital;

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
        /// Método que deleta uma Producao 
        /// </summary>
        /// <returns>Boolean</returns>
        public Boolean deletProducao(ProducaoDTO dto)
        {
            try
            {
                using (SqlConnection _connection = new
                    SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MinhaConexao"].ToString()))
                {

                    var sql = "DELETE FROM Producao WHERE idProducao = @idProducao";

                    //Instancia um novo comando com uma consulta e uma conexão
                    using (SqlCommand _sqlComm = new SqlCommand(sql, _connection))
                    {
                        _sqlComm.Parameters.Add("@idProducao", SqlDbType.Int).Value = dto.idProducao;

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
        /// Método Update Producao
        /// </summary>
        /// <returns>Boolean</returns>
        public Boolean atualizarProducao(ProducaoDTO dto)
        {
            try
            {
                using (SqlConnection _connection = new
                    SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MinhaConexao"].ToString()))
                {

                    var sql = "UPDATE Producao SET totalAtend=@totalAtend, consultasAgendadas=@consultasAgendadas,atendPreNatal=@atendPreNatal,atendPuericultura=@atendPuericultura,atendHipertensos=@atendHipertensos,atendDiabeticos=@atendDiabeticos,atendAsma=@atendAsma,atendMental=@atendMental,atendMental=@atendMental,atendAlcDrogas=@atendAlcDrogas,atendTuberculose=@atendTuberculose,atendHanseniase=@atendHanseniase,atendCancerUtero=@atendCancerUtero,atendAlcDrogas=@atendAlcDrogas,visitasDomic=@visitasDomic,atColetivas=@atColetivas,encaminHospital=@encaminHospital WHERE idProducao=@idProducao";

                    //Instancia um novo comando com uma consulta e uma conexão
                    using (SqlCommand _sqlComm = new SqlCommand(sql, _connection))
                    {
                        _sqlComm.Parameters.Add("@idProducao", SqlDbType.Int).Value = dto.idProducao;
                        _sqlComm.Parameters.Add("@idUsuario", SqlDbType.Int).Value = dto.idUsuario;
                        _sqlComm.Parameters.Add("@idMes", SqlDbType.Int).Value = dto.idMes;
                        _sqlComm.Parameters.Add("@totalAtend", SqlDbType.Int).Value = dto.totalAtend;
                        _sqlComm.Parameters.Add("@consultasAgendadas", SqlDbType.Int).Value = dto.consultasAgendadas;
                        _sqlComm.Parameters.Add("@atendPreNatal", SqlDbType.Int).Value = dto.atendPreNatal;
                        _sqlComm.Parameters.Add("@atendPuericultura", SqlDbType.Int).Value = dto.atendPuericultura;
                        _sqlComm.Parameters.Add("@atendHipertensos", SqlDbType.Int).Value = dto.atendHipertensos;
                        _sqlComm.Parameters.Add("@atendDiabeticos", SqlDbType.Int).Value = dto.atendDiabeticos;
                        _sqlComm.Parameters.Add("@atendAsma", SqlDbType.Int).Value = dto.atendAsma;
                        _sqlComm.Parameters.Add("@atendMental", SqlDbType.Int).Value = dto.atendMental;
                        _sqlComm.Parameters.Add("@atendAlcDrogas", SqlDbType.Int).Value = dto.atendAlcDrogas;
                        _sqlComm.Parameters.Add("@atendTuberculose", SqlDbType.Int).Value = dto.atendTuberculose;
                        _sqlComm.Parameters.Add("@atendHanseniase", SqlDbType.Int).Value = dto.atendHanseniase;
                        _sqlComm.Parameters.Add("@atendCancerUtero", SqlDbType.Int).Value = dto.atendCancerUtero;
                        _sqlComm.Parameters.Add("@atendAlcDrogas", SqlDbType.Int).Value = dto.atendAlcDrogas;
                        _sqlComm.Parameters.Add("@visitasDomic", SqlDbType.Int).Value = dto.visitasDomic;
                        _sqlComm.Parameters.Add("@atColetivas", SqlDbType.Int).Value = dto.atColetivas;
                        _sqlComm.Parameters.Add("@encaminHospital", SqlDbType.Int).Value = dto.encaminHospital;

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
