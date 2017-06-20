namespace WFSUS
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.producaoMedicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preencherProducaoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relatoriosMedicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizarRelatorioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calendarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblUsuarioLogado = new System.Windows.Forms.Label();
            this.relatoriosEspecificosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.producaoMedicoToolStripMenuItem,
            this.relatoriosMedicoToolStripMenuItem,
            this.calendarioToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(709, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // producaoMedicoToolStripMenuItem
            // 
            this.producaoMedicoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preencherProducaoToolStripMenuItem});
            this.producaoMedicoToolStripMenuItem.Name = "producaoMedicoToolStripMenuItem";
            this.producaoMedicoToolStripMenuItem.Size = new System.Drawing.Size(113, 20);
            this.producaoMedicoToolStripMenuItem.Text = "Producao Medico";
            // 
            // preencherProducaoToolStripMenuItem
            // 
            this.preencherProducaoToolStripMenuItem.Name = "preencherProducaoToolStripMenuItem";
            this.preencherProducaoToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.preencherProducaoToolStripMenuItem.Text = "Preencher Producao";
            this.preencherProducaoToolStripMenuItem.Click += new System.EventHandler(this.preencherProducaoToolStripMenuItem_Click);
            // 
            // relatoriosMedicoToolStripMenuItem
            // 
            this.relatoriosMedicoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.visualizarRelatorioToolStripMenuItem,
            this.relatoriosEspecificosToolStripMenuItem});
            this.relatoriosMedicoToolStripMenuItem.Name = "relatoriosMedicoToolStripMenuItem";
            this.relatoriosMedicoToolStripMenuItem.Size = new System.Drawing.Size(114, 20);
            this.relatoriosMedicoToolStripMenuItem.Text = "Relatorios Medico";
            // 
            // visualizarRelatorioToolStripMenuItem
            // 
            this.visualizarRelatorioToolStripMenuItem.Name = "visualizarRelatorioToolStripMenuItem";
            this.visualizarRelatorioToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.visualizarRelatorioToolStripMenuItem.Text = "Visualizar Todos os Dados";
            this.visualizarRelatorioToolStripMenuItem.Click += new System.EventHandler(this.visualizarRelatorioToolStripMenuItem_Click);
            // 
            // calendarioToolStripMenuItem
            // 
            this.calendarioToolStripMenuItem.Name = "calendarioToolStripMenuItem";
            this.calendarioToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.calendarioToolStripMenuItem.Text = "Calendario";
            this.calendarioToolStripMenuItem.Click += new System.EventHandler(this.calendarioToolStripMenuItem_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // lblUsuarioLogado
            // 
            this.lblUsuarioLogado.AutoSize = true;
            this.lblUsuarioLogado.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblUsuarioLogado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblUsuarioLogado.Location = new System.Drawing.Point(544, 24);
            this.lblUsuarioLogado.Name = "lblUsuarioLogado";
            this.lblUsuarioLogado.Size = new System.Drawing.Size(117, 19);
            this.lblUsuarioLogado.TabIndex = 3;
            this.lblUsuarioLogado.Text = "SEJA BEM VINDO";
            // 
            // relatoriosEspecificosToolStripMenuItem
            // 
            this.relatoriosEspecificosToolStripMenuItem.Name = "relatoriosEspecificosToolStripMenuItem";
            this.relatoriosEspecificosToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.relatoriosEspecificosToolStripMenuItem.Text = "Relatorios Especificos";
            this.relatoriosEspecificosToolStripMenuItem.Click += new System.EventHandler(this.relatoriosEspecificosToolStripMenuItem_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(709, 484);
            this.Controls.Add(this.lblUsuarioLogado);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Seja Bem-Vindo ao Sistema e-SUS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem producaoMedicoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preencherProducaoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relatoriosMedicoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visualizarRelatorioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calendarioToolStripMenuItem;
        private System.Windows.Forms.Label lblUsuarioLogado;
        private System.Windows.Forms.ToolStripMenuItem relatoriosEspecificosToolStripMenuItem;
    }
}

