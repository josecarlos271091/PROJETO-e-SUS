using com.sus.Bussiness;
using com.sus.DAL;
using com.sus.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFSUS
{
    public partial class frmRelatoriosEspecificos : Form
    {
        private int idProducaoGET;
        public frmRelatoriosEspecificos()
        {
            InitializeComponent();
            carregaDadosComboUsuario();
            carregaDadosComboMes();
        }

        private void carregaDadosComboUsuario()
        {
            try
            {
                using (SqlConnection _connection = new
                    SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MinhaConexao"].ToString()))
                {
                    DataTable _dtSet = new DataTable();

                    //abrir a conexao com o banco de dados
                    _connection.Open();

                    //usando objeto desconectado e informando o parametro com a variavel de conexao
                    SqlDataAdapter _dtAdapter = new SqlDataAdapter();
                    _dtAdapter.SelectCommand = new SqlCommand("SELECT * FROM Usuario", _connection);

                    //preenche o objeto para ficar desconectado
                    _dtAdapter.Fill(_dtSet);

                    //retorna o data table na posicao 0
                    cbUsuario.DataSource = _dtSet;
                    cbUsuario.DisplayMember = "nomeUsuario";
                    cbUsuario.ValueMember = "idUsuario";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void carregaDadosComboMes()
        {
            try
            {
                using (SqlConnection _connection = new
                    SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MinhaConexao"].ToString()))
                {
                    DataTable _dtSet = new DataTable();

                    //abrir a conexao com o banco de dados
                    _connection.Open();

                    //usando objeto desconectado e informando o parametro com a variavel de conexao
                    SqlDataAdapter _dtAdapter = new SqlDataAdapter();
                    _dtAdapter.SelectCommand = new SqlCommand("SELECT * FROM Mes", _connection);

                    //preenche o objeto para ficar desconectado
                    _dtAdapter.Fill(_dtSet);

                    //retorna o data table na posicao 0
                    cbxMes.DataSource = _dtSet;
                    cbxMes.DisplayMember = "nomeMes";
                    cbxMes.ValueMember = "idMes";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            ProducaoDTO _prodDTO = new ProducaoDTO();
            ProducaoBussiness _prodDAO = new ProducaoBussiness();
            _prodDTO = _prodDAO.ObterProducao(int.Parse(cbUsuario.SelectedValue.ToString()), int.Parse(cbxMes.SelectedValue.ToString()));
            if (_prodDTO != null)
            {
                //Obtendo id da Producao e armazenando em variavel privada
                idProducaoGET = _prodDTO.idProducao;
                txtAlcolDrogas.Text = _prodDTO.atendAlcDrogas.ToString();
                txtAsmaticos.Text = _prodDTO.atendAsma.ToString();
                txtAtividadesColetivas.Text = _prodDTO.atColetivas.ToString();
                txtCancerMama.Text = _prodDTO.atendCancerMama.ToString();
                txtCancerUtero.Text = _prodDTO.atendCancerUtero.ToString();
                txtConsultasAgend.Text = _prodDTO.consultasAgendadas.ToString();
                txtDiabeticos.Text = _prodDTO.atendDiabeticos.ToString();
                txtEncaminhamentosHosp.Text = _prodDTO.encaminHospital.ToString();
                txtHanseniase.Text = _prodDTO.atendHanseniase.ToString();
                txtHipertensos.Text = _prodDTO.atendHipertensos.ToString();
                txtPreNatal.Text = _prodDTO.atendPreNatal.ToString();
                txtPuericultura.Text = _prodDTO.atendPuericultura.ToString();
                txtSaudeMental.Text = _prodDTO.atendMental.ToString();
                txtTotalAtend.Text = _prodDTO.totalAtend.ToString();
                txtTuberculose.Text = _prodDTO.atendTuberculose.ToString();
                txtVisitasDomiciliares.Text = _prodDTO.visitasDomic.ToString();
            }
            else
            {
                MessageBox.Show("Pesquisa nao retornou nenhum valor!", "Pesquisa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpaTextBox();
            }
        }

        private void limpaTextBox()
        {
            //Limpa textboxs
            txtAlcolDrogas.Text = "";
            txtAsmaticos.Text = "";
            txtAtividadesColetivas.Text = "";
            txtCancerMama.Text = "";
            txtCancerUtero.Text = "";
            txtConsultasAgend.Text = "";
            txtDiabeticos.Text = "";
            txtEncaminhamentosHosp.Text = "";
            txtHanseniase.Text = "";
            txtHipertensos.Text = "";
            txtPreNatal.Text = "";
            txtPuericultura.Text = "";
            txtSaudeMental.Text = "";
            txtTotalAtend.Text = "";
            txtTuberculose.Text = "";
            txtVisitasDomiciliares.Text = "";
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {

            SaveFileDialog salvarArquivo = new SaveFileDialog();
            string _strFormato = DateTime.Now.Date.ToString("yyyyMMdd");
            salvarArquivo.FileName = "DadosSalvos-" + frmLogin.nomeusuarioLogado + "-" + _strFormato;
            salvarArquivo.DefaultExt = "*.xml";
            salvarArquivo.Filter = "Documentos xml (*.xml)|*.xml| Todos os arquivos (*.*)|*.*";
            if (salvarArquivo.ShowDialog() == System.Windows.Forms.DialogResult.OK && salvarArquivo.FileName.Length > 0)
            {
                ProducaoBussiness _prod = new ProducaoBussiness();
                DataTable _dt = _prod.pesquisarExportarProducao(int.Parse(cbUsuario.SelectedValue.ToString()), int.Parse(cbxMes.SelectedValue.ToString()));
                if (_dt != null)
                {

                    _dt.WriteXml(salvarArquivo.FileName);
                    MessageBox.Show("Dados Exportados com Sucesso!", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Erro ao Exportar XML!", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
