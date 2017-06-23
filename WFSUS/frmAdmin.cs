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
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
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

        private void usuarioaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDadosUsuarios frm = new frmDadosUsuarios();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
