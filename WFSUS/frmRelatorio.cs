using com.sus.Bussiness;
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
    public partial class frmRelatorio : Form
    {
        public frmRelatorio()
        {
            InitializeComponent();
            ProducaoBussiness _producao = new ProducaoBussiness();
            dataGridView1.DataSource = _producao.buscarTodasProducoes();
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
                DataTable _dt = _prod.buscarProducoes();
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
