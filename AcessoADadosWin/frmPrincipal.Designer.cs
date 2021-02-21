namespace AcessoADadosWin
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ingredienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unidadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classificaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dificuldadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.receitasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insereReceitasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminaReceitasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.validaReceitasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.receitasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.categoriasToolStripMenuItem,
            this.ingredienteToolStripMenuItem,
            this.unidadeToolStripMenuItem,
            this.classificaçãoToolStripMenuItem,
            this.dificuldadeToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(138, 24);
            this.toolStripMenuItem1.Text = "G&estão Atributos ";
            // 
            // categoriasToolStripMenuItem
            // 
            this.categoriasToolStripMenuItem.Name = "categoriasToolStripMenuItem";
            this.categoriasToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.categoriasToolStripMenuItem.Text = "Categorias";
            this.categoriasToolStripMenuItem.Click += new System.EventHandler(this.categoriasToolStripMenuItem_Click);
            // 
            // ingredienteToolStripMenuItem
            // 
            this.ingredienteToolStripMenuItem.Name = "ingredienteToolStripMenuItem";
            this.ingredienteToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.ingredienteToolStripMenuItem.Text = "Ingrediente";
            this.ingredienteToolStripMenuItem.Click += new System.EventHandler(this.ingredienteToolStripMenuItem_Click);
            // 
            // unidadeToolStripMenuItem
            // 
            this.unidadeToolStripMenuItem.Name = "unidadeToolStripMenuItem";
            this.unidadeToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.unidadeToolStripMenuItem.Text = "Unidade";
            this.unidadeToolStripMenuItem.Click += new System.EventHandler(this.unidadeToolStripMenuItem_Click);
            // 
            // classificaçãoToolStripMenuItem
            // 
            this.classificaçãoToolStripMenuItem.Name = "classificaçãoToolStripMenuItem";
            this.classificaçãoToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.classificaçãoToolStripMenuItem.Text = "Classificação";
            this.classificaçãoToolStripMenuItem.Click += new System.EventHandler(this.classificaçãoToolStripMenuItem_Click);
            // 
            // dificuldadeToolStripMenuItem
            // 
            this.dificuldadeToolStripMenuItem.Name = "dificuldadeToolStripMenuItem";
            this.dificuldadeToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.dificuldadeToolStripMenuItem.Text = "Dificuldade";
            this.dificuldadeToolStripMenuItem.Click += new System.EventHandler(this.dificuldadeToolStripMenuItem_Click);
            // 
            // receitasToolStripMenuItem
            // 
            this.receitasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insereReceitasToolStripMenuItem,
            this.eliminaReceitasToolStripMenuItem,
            this.validaReceitasToolStripMenuItem});
            this.receitasToolStripMenuItem.Name = "receitasToolStripMenuItem";
            this.receitasToolStripMenuItem.Size = new System.Drawing.Size(78, 24);
            this.receitasToolStripMenuItem.Text = "Receitas";
            // 
            // insereReceitasToolStripMenuItem
            // 
            this.insereReceitasToolStripMenuItem.Name = "insereReceitasToolStripMenuItem";
            this.insereReceitasToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.insereReceitasToolStripMenuItem.Text = "Insere Receitas";
            this.insereReceitasToolStripMenuItem.Click += new System.EventHandler(this.insereReceitasToolStripMenuItem_Click);
            // 
            // eliminaReceitasToolStripMenuItem
            // 
            this.eliminaReceitasToolStripMenuItem.Name = "eliminaReceitasToolStripMenuItem";
            this.eliminaReceitasToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.eliminaReceitasToolStripMenuItem.Text = "Elimina Receitas";
            this.eliminaReceitasToolStripMenuItem.Click += new System.EventHandler(this.eliminaReceitasToolStripMenuItem_Click);
            // 
            // validaReceitasToolStripMenuItem
            // 
            this.validaReceitasToolStripMenuItem.Name = "validaReceitasToolStripMenuItem";
            this.validaReceitasToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.validaReceitasToolStripMenuItem.Text = "Valida Receitas";
            this.validaReceitasToolStripMenuItem.Click += new System.EventHandler(this.validaReceitasToolStripMenuItem_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmPrincipal";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem categoriasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ingredienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unidadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem classificaçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dificuldadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem receitasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insereReceitasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminaReceitasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem validaReceitasToolStripMenuItem;
    }
}