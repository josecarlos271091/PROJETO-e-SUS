using com.sus.Bussiness;
using com.sus.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFSUS
{
    public partial class frmPreencherProd : Form
    {
        private string mesRecebido;
        private int idProducaoGET;
        public frmPreencherProd()
        {
            InitializeComponent();
        }

        public frmPreencherProd(string _mesRecebido)
        {
            InitializeComponent();
            ProducaoBussiness _producao = new ProducaoBussiness();
            this.mesRecebido = _mesRecebido;
            getall();
        }

        public void getall()
        {
            ProducaoDTO _prodDTO = new ProducaoDTO();
            ProducaoBussiness _prodDAO = new ProducaoBussiness();
            _prodDTO = _prodDAO.ObterProducao(frmLogin.idusuarioLogado, int.Parse(mesRecebido));
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



        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
            frmProducao frm = new frmProducao();
            frm.Show();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //Verificando se a producao desse mes esta preenchida
            if (producaoPreenchida())
            {
                btnSalvar.Enabled = false;
                return;
            }

            ProducaoDTO dto = new ProducaoDTO();
            
            //Pega e valida os dados e inserta Producao
            try
            { 
                dto.idMes = int.Parse(this.mesRecebido);
                dto.idUsuario = frmLogin.idusuarioLogado; //Pegar idusuario logado
                dto.totalAtend = int.Parse(txtTotalAtend.Text);
                dto.visitasDomic = int.Parse(txtVisitasDomiciliares.Text);
                dto.atColetivas = int.Parse(txtAtividadesColetivas.Text);
                dto.atendAlcDrogas = int.Parse(txtAlcolDrogas.Text);
                dto.atendAsma = int.Parse(txtAsmaticos.Text);
                dto.atendCancerMama = int.Parse(txtCancerMama.Text);
                dto.atendCancerUtero = int.Parse(txtCancerUtero.Text);
                dto.atendDiabeticos = int.Parse(txtDiabeticos.Text);
                dto.atendHanseniase = int.Parse(txtHanseniase.Text);
                dto.atendHipertensos = int.Parse(txtHipertensos.Text);
                dto.atendMental = int.Parse(txtSaudeMental.Text);
                dto.atendPreNatal = int.Parse(txtPreNatal.Text);
                dto.atendPuericultura = int.Parse(txtPuericultura.Text);
                dto.atendTuberculose = int.Parse(txtTuberculose.Text);
                dto.consultasAgendadas = int.Parse(txtConsultasAgend.Text);
                dto.encaminHospital = int.Parse(txtEncaminhamentosHosp.Text);
            }
            catch
            {
                MessageBox.Show("Proibido deixar campos vazios!, Por favor digite os valores correspondentes!, Os campos so aceitam Numeros!", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
      
            ProducaoBussiness _producao = new ProducaoBussiness();
            if (_producao.insertarProducao(dto))
            {
                limpaTextBox();
                MessageBox.Show("Producao Salva com Sucesso!", "Producao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getall();
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            //Pega os dados e atualiza Producao

            ProducaoDTO dto = new ProducaoDTO();
            try
            {
                dto.idProducao = idProducaoGET;
                dto.idMes = int.Parse(this.mesRecebido);
                dto.idUsuario = frmLogin.idusuarioLogado;
                dto.totalAtend = int.Parse(txtTotalAtend.Text);
                dto.visitasDomic = int.Parse(txtVisitasDomiciliares.Text);
                dto.atColetivas = int.Parse(txtAtividadesColetivas.Text);
                dto.atendAlcDrogas = int.Parse(txtAlcolDrogas.Text);
                dto.atendAsma = int.Parse(txtAsmaticos.Text);
                dto.atendCancerMama = int.Parse(txtCancerMama.Text);
                dto.atendCancerUtero = int.Parse(txtCancerUtero.Text);
                dto.atendDiabeticos = int.Parse(txtDiabeticos.Text);
                dto.atendHanseniase = int.Parse(txtHanseniase.Text);
                dto.atendHipertensos = int.Parse(txtHipertensos.Text);
                dto.atendMental = int.Parse(txtSaudeMental.Text);
                dto.atendPreNatal = int.Parse(txtPreNatal.Text);
                dto.atendPuericultura = int.Parse(txtPuericultura.Text);
                dto.atendTuberculose = int.Parse(txtTuberculose.Text);
                dto.consultasAgendadas = int.Parse(txtConsultasAgend.Text);
                dto.encaminHospital = int.Parse(txtEncaminhamentosHosp.Text);
            }
            catch
            {
                MessageBox.Show("Proibido deixar campos vazios!, Por favor digite os valores correspondentes!, Os campos so aceitam Numeros!", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ProducaoBussiness _producao = new ProducaoBussiness();

            if (_producao.atualizarProducao(dto))
            {
                limpaTextBox();
                getall();
                MessageBox.Show("Producao Atualizada com Sucesso!", "Producao", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public Boolean producaoPreenchida()
        {
            ProducaoDTO _prodDTO = new ProducaoDTO();
            ProducaoBussiness _prodDAO = new ProducaoBussiness();
            _prodDTO = _prodDAO.ObterProducao(frmLogin.idusuarioLogado, int.Parse(mesRecebido));
            if (_prodDTO != null)
                return
                    true;
            else
                return false;
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            ProducaoBussiness _prodDAO = new ProducaoBussiness();

            if (MessageBox.Show("Deseja Deletar a Producao do Usuario?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_prodDAO.deletarProducao(idProducaoGET))
                {
                    limpaTextBox();
                    getall();
                    MessageBox.Show("Producao Deletada com Sucesso!", "Producao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
                
        }
    }
}
