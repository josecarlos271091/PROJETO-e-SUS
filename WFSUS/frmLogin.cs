using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFSUS
{
    public partial class frmLogin : Form
    {
        public static string nomeusuarioLogado;
        public static int idusuarioLogado;
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
        /// Cria var _nome e _senha as quais recebem do Banco de dados o nome e usuario previamente cadastrados
        /// Caso o inserido nos txtUsuario e txtSenha nao ser iguais mostra mensagem de erro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MinhaConexao"].ToString());

                String _usuario = txtUsuario.Text;
                String _senha = txtSenha.Text;

                con.Open();
                string sql = "SELECT * FROM Usuario WHERE nomeUsuario=@_usuario AND senhaUsuario=@_senha";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@_usuario", SqlDbType.NVarChar).Value = _usuario;
                cmd.Parameters.Add("@_senha", SqlDbType.NVarChar).Value = _senha;

                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.Read())
                {

                    idusuarioLogado = sdr.GetInt32(0);
                    nomeusuarioLogado = _usuario;
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
