using com.sus.DAL;
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
using com.sus.Bussiness;

namespace WFSUS
{
    public partial class frmDadosUsuarios : Form
    {
        private int _idUsuario;
        public frmDadosUsuarios()
        {
            InitializeComponent();
            UsuariosBussiness _usuarios = new UsuariosBussiness();
            grdUsuarios.DataSource = _usuarios.buscarTodosUsuarios();
            limpaTextBox();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            UsuarioDTO dto = new UsuarioDTO();

            //Pega e valida os dados e inserta usuario
            try
            {
                dto.nomeUsuario = txtNomeUsuario.Text;
                dto.senhaUsuario = txtSenhaUsuario.Text;
                if(dto.nomeUsuario == "" || dto.senhaUsuario == "")
                {
                    MessageBox.Show("Dados nao podem ser vazios!", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Dados em Formato Incorreto!", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UsuarioDAL _usuario = new UsuarioDAL();
            if (_usuario.insertarUsuario(dto))
            {
                limpaTextBox();
                MessageBox.Show("Usuario Cadastrado com Sucesso!", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Actualiza Tabela
                grdUsuarios.DataSource = _usuario.buscarTodosUsuarios();
            }
        }

        public void limpaTextBox()
        {
            txtNomeUsuario.Text = "";
            txtSenhaUsuario.Text = "";
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            //Pega os dados e atualiza o usuario
            UsuarioDTO dto = new UsuarioDTO();
            
            try
            {
                dto.idUsuario = _idUsuario;
                dto.nomeUsuario = txtNomeUsuario.Text;
                dto.senhaUsuario = txtSenhaUsuario.Text;
            }
            catch
            {
                MessageBox.Show("Dados em Formato Incorreto!", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            UsuariosBussiness _usuario = new UsuariosBussiness();
            if (_usuario.atualizarUsuario(dto))
            {
                limpaTextBox();

                MessageBox.Show("Usuario Editado com Sucesso!", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Actualiza Tabela
                grdUsuarios.DataSource = _usuario.buscarTodosUsuarios();
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            //Pega os dados e deleta o usuario
            UsuarioDTO dto = new UsuarioDTO();
            try
            {
                dto.idUsuario = _idUsuario;
                dto.nomeUsuario = txtNomeUsuario.Text;
                dto.senhaUsuario = txtSenhaUsuario.Text;
            }
            catch
            {
                MessageBox.Show("Dados em Formato Incorreto!", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UsuariosBussiness _usuario = new UsuariosBussiness();

            if (MessageBox.Show("Deseja Deletar o Usuario?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if (_usuario.deletUsuario(dto))
                {
                    limpaTextBox();

                    MessageBox.Show("Usuario Deletado com Sucesso!", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Actualiza Tabela
                    grdUsuarios.DataSource = _usuario.buscarTodosUsuarios();
                }
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            _idUsuario = int.Parse(grdUsuarios.CurrentRow.Cells[0].Value.ToString());
            txtNomeUsuario.Text = grdUsuarios.CurrentRow.Cells[1].Value.ToString();
            txtSenhaUsuario.Text = grdUsuarios.CurrentRow.Cells[2].Value.ToString();
        }

        private void grdUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            try
            { 
            _idUsuario = int.Parse(grdUsuarios.CurrentRow.Cells[0].Value.ToString());
            txtNomeUsuario.Text = grdUsuarios.CurrentRow.Cells[1].Value.ToString();
            txtSenhaUsuario.Text = grdUsuarios.CurrentRow.Cells[2].Value.ToString();
            }catch
            {
                MessageBox.Show("Selecione a Linha Corretamente!", "Error de Selecao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
