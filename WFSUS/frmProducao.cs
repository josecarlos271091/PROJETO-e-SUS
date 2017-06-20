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
    public partial class frmProducao : Form
    {
        public frmProducao()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnJaneiro_Click(object sender, EventArgs e)
        {
            frmPreencherProd frm = new frmPreencherProd("1");
            this.Hide();
            frm.Show();
        }

        private void btnFevereiro_Click(object sender, EventArgs e)
        {
            frmPreencherProd frm = new frmPreencherProd("2");
            this.Hide();
            frm.Show();
        }

        private void btnMarco_Click(object sender, EventArgs e)
        {
            frmPreencherProd frm = new frmPreencherProd("3");
            this.Hide();
            frm.Show();
        }

        private void btnAbril_Click(object sender, EventArgs e)
        {
            frmPreencherProd frm = new frmPreencherProd("4");
            this.Hide();
            frm.Show();
        }

        private void btnMaio_Click(object sender, EventArgs e)
        {
            frmPreencherProd frm = new frmPreencherProd("5");
            this.Hide();
            frm.Show();
        }

        private void btnJunho_Click(object sender, EventArgs e)
        {
            frmPreencherProd frm = new frmPreencherProd("6");
            this.Hide();
            frm.Show();
        }

        private void btnJulho_Click(object sender, EventArgs e)
        {
            frmPreencherProd frm = new frmPreencherProd("7");
            this.Hide();
            frm.Show();
        }

        private void btnAgosto_Click(object sender, EventArgs e)
        {
            frmPreencherProd frm = new frmPreencherProd("8");
            this.Hide();
            frm.Show();
        }

        private void btnSetembro_Click(object sender, EventArgs e)
        {
            frmPreencherProd frm = new frmPreencherProd("9");
            this.Hide();
            frm.Show();
        }

        private void btnOutubro_Click(object sender, EventArgs e)
        {
            frmPreencherProd frm = new frmPreencherProd("10");
            this.Hide();
            frm.Show();
        }

        private void btnNovembro_Click(object sender, EventArgs e)
        {
            frmPreencherProd frm = new frmPreencherProd("11");
            this.Hide();
            frm.Show();
        }

        private void btnDezembro_Click(object sender, EventArgs e)
        {
            frmPreencherProd frm = new frmPreencherProd("12");
            this.Hide();
            frm.Show();
        }

        private void btnResetar_Click(object sender, EventArgs e)
        {
            //Perguntar a Usuario se tem certeza de eliminar
            if (MessageBox.Show("Deseja Deletar as Producoes do Usuario?, esse Processo e Irreversivel!", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ProducaoBussiness _prodDAO = new ProducaoBussiness();
                _prodDAO.deletALLProducoes(frmLogin.idusuarioLogado);
            }
        }
    }
}
