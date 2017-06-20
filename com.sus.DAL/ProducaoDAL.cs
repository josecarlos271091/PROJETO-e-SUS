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
    public class ProducaoDAL
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
        /// Método que busca uma Producao e retorna tabela para exportar 
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable pesquisarExportarProducao(int idUsuario, int idMes)
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
                    _dtAdapter.SelectCommand = new SqlCommand("SELECT * FROM Producao WHERE idUsuario="+idUsuario.ToString()+"AND idMes="+idMes.ToString(), _connection);

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
        /// método que faz a consulta no bd e obtém a producao dado id do mes, id do usario 
        /// </summary>
        /// <returns>DataTable</returns>
        public ProducaoDTO ObterProducao(int idUsuario, int idMes)
        {
            //objeto producao que será retornado pelo método 
            ProducaoDTO _producao = new ProducaoDTO();
            SqlConnection _connection = new
            SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MinhaConexao"].ToString());

            //string com o comando a ser executado 
            string sql = "SELECT * FROM Producao WHERE idUsuario=@idUsuario AND idMes=@idMes";

            //instância do comando recebendo como parâmetro 
            //a string com o comando e a conexão 
            SqlCommand cmd = new SqlCommand(sql, _connection);

            //informo o parâmetro do comando 
            cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
            cmd.Parameters.AddWithValue("@idMes", idMes);

            //abro conexão 
            _connection.Open();

            //instância do leitor 
            SqlDataReader leitor = cmd.ExecuteReader();
            if (leitor.HasRows)
            {
                //enquanto leitor lê 
                while (leitor.Read())
                {
                    //passo os valores para o objeto producao 
                    //que será retornado 
                    _producao.idProducao = Convert.ToInt32(leitor["idProducao"].ToString());
                    _producao.idUsuario = Convert.ToInt32(leitor["idUsuario"].ToString());
                    _producao.idMes = Convert.ToInt32(leitor["idMes"].ToString());
                    _producao.totalAtend = Convert.ToInt32(leitor["totalAtend"].ToString());
                    _producao.visitasDomic = Convert.ToInt32(leitor["visitasDomic"].ToString());
                    _producao.atColetivas = Convert.ToInt32(leitor["atColetivas"].ToString());
                    _producao.atendAlcDrogas = Convert.ToInt32(leitor["atendAlcDrogas"].ToString());
                    _producao.atendAsma = Convert.ToInt32(leitor["atendAsma"].ToString());
                    _producao.atendCancerMama = Convert.ToInt32(leitor["atendCancerMama"].ToString());
                    _producao.atendCancerUtero = Convert.ToInt32(leitor["atendCancerUtero"].ToString());
                    _producao.atendDiabeticos = Convert.ToInt32(leitor["atendDiabeticos"].ToString());
                    _producao.atendHanseniase = Convert.ToInt32(leitor["atendHanseniase"].ToString());
                    _producao.atendHipertensos = Convert.ToInt32(leitor["atendHipertensos"].ToString());
                    _producao.atendMental = Convert.ToInt32(leitor["atendMental"].ToString());
                    _producao.atendPreNatal = Convert.ToInt32(leitor["atendPreNatal"].ToString());
                    _producao.atendPuericultura = Convert.ToInt32(leitor["atendPuericultura"].ToString());
                    _producao.atendTuberculose = Convert.ToInt32(leitor["atendTuberculose"].ToString());
                    _producao.consultasAgendadas = Convert.ToInt32(leitor["consultasAgendadas"].ToString());
                    _producao.encaminHospital = Convert.ToInt32(leitor["encaminHospital"].ToString());

                }

            }
            else
                return null;

            //fecha conexão 
            _connection.Close();

            //Retorno o objeto producao cujo o  
            //nome é igual ao informado no parâmetro 
            return _producao;
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
                        _sqlComm.Parameters.Add("@atendCancerMama", SqlDbType.Int).Value = dto.atendCancerMama;
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
        public Boolean deletProducao(int idProducao)
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
                        _sqlComm.Parameters.Add("@idProducao", SqlDbType.Int).Value = idProducao;

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
        /// Método que deleta TODAS as Producoes de um Usaurio 
        /// </summary>
        /// <returns>Boolean</returns>
        public Boolean deletALLProducoes(int idUsuario)
        {
            try
            {
                using (SqlConnection _connection = new
                    SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MinhaConexao"].ToString()))
                {

                    var sql = "DELETE FROM Producao WHERE idUsuario = @idUsuario";

                    //Instancia um novo comando com uma consulta e uma conexão
                    using (SqlCommand _sqlComm = new SqlCommand(sql, _connection))
                    {
                        _sqlComm.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;

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

                    var sql = "UPDATE Producao SET totalAtend=@totalAtend, consultasAgendadas=@consultasAgendadas,atendPreNatal=@atendPreNatal,atendPuericultura=@atendPuericultura,atendHipertensos=@atendHipertensos,atendDiabeticos=@atendDiabeticos,atendAsma=@atendAsma,atendMental=@atendMental,atendAlcDrogas=@atendAlcDrogas,atendTuberculose=@atendTuberculose,atendHanseniase=@atendHanseniase,atendCancerUtero=@atendCancerUtero,visitasDomic=@visitasDomic,atColetivas=@atColetivas,encaminHospital=@encaminHospital WHERE idProducao=@idProducao";

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
                        _sqlComm.Parameters.Add("@atendCancerMama", SqlDbType.Int).Value = dto.atendCancerMama;
                        _sqlComm.Parameters.Add("@visitasDomic", SqlDbType.Int).Value = dto.visitasDomic;
                        _sqlComm.Parameters.Add("@atColetivas", SqlDbType.Int).Value = dto.atColetivas;
                        _sqlComm.Parameters.Add("@encaminHospital", SqlDbType.Int).Value = dto.encaminHospital;

                        //Abrir a conexao com o banco de dados
                        _connection.Open();

                        //Chama o método ExecuteNonQuery para enviar o comando
                        _sqlComm.ExecuteNonQuery();

                        _connection.Close();
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
