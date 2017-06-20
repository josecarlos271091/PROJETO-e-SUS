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
            ProducaoBussiness _prod = new ProducaoBussiness();
            DataTable _dt = _prod.buscarProducoes();
            if (_dt != null)
            {
                string _strFormato = DateTime.Now.Date.ToString("yyyyMMdd");
                _dt.WriteXml(@"C:\Users\Jose Carlos\Desktop\PROJETO FINAL TALP\ProjetoFinalTALP\DadosSalvos-" + frmLogin.nomeusuarioLogado + "-" + _strFormato + ".xml");
                MessageBox.Show("Dados Exportados com Sucesso!", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Erro ao Exportar XML!", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
