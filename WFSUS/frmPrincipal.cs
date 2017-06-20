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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
            lblUsuarioLogado.Text = "Seja Bem-Vindo(a) Doutor(a) "+frmLogin.nomeusuarioLogado.ToUpper()+"!";
        }
        
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja encerrar a aplicação ?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void calendarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCalendario frm = new frmCalendario();
            frm.MdiParent = this;
            frm.Show();
        }

        private void preencherProducaoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProducao frm = new frmProducao();
            frm.MdiParent = this;
            frm.Show();
        }

        private void visualizarRelatorioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRelatorio frm = new frmRelatorio();
            frm.MdiParent = this;
            frm.Show();
        }

        private void relatoriosEspecificosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRelatoriosEspecificos frm = new frmRelatoriosEspecificos();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
