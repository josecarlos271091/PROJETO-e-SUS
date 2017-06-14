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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja encerrar a aplicação ?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// Cria var _nome e _senha as quais recebem do App.config o nome e usuario predeterminados
        /// Caso o inserido nos txtUsuario e txtSenha nao ser iguais mostra mensagem de erro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            var _nome = System.Configuration.ConfigurationManager.AppSettings["usuario"].ToString();
            var _senha = System.Configuration.ConfigurationManager.AppSettings["senha"].ToString();

            if (txtUsuario.Text.Equals(_nome) && txtSenha.Text.Equals(_senha))
            {
                this.Hide();
                frmPrincipal form = new frmPrincipal();
                form.Show();
            }
            else
            {
                MessageBox.Show("Por favor digite a senha corretamente", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsuario.Focus();
            }
        }
    }
}
