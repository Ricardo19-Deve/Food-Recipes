namespace AcessoADadosWin
{
    partial class frmValidaReceitas
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
            this.chlReceitasValidar = new System.Windows.Forms.CheckedListBox();
            this.btnValidar = new System.Windows.Forms.Button();
            this.ckbTodosNenhum = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chlReceitasValidar
            // 
            this.chlReceitasValidar.FormattingEnabled = true;
            this.chlReceitasValidar.Location = new System.Drawing.Point(81, 75);
            this.chlReceitasValidar.Name = "chlReceitasValidar";
            this.chlReceitasValidar.Size = new System.Drawing.Size(179, 378);
            this.chlReceitasValidar.TabIndex = 3;
            // 
            // btnValidar
            // 
            this.btnValidar.Location = new System.Drawing.Point(81, 499);
            this.btnValidar.Name = "btnValidar";
            this.btnValidar.Size = new System.Drawing.Size(168, 43);
            this.btnValidar.TabIndex = 4;
            this.btnValidar.Text = "Validar";
            this.btnValidar.UseVisualStyleBackColor = true;
            this.btnValidar.Click += new System.EventHandler(this.btnValidar_Click);
            // 
            // ckbTodosNenhum
            // 
            this.ckbTodosNenhum.AutoSize = true;
            this.ckbTodosNenhum.Location = new System.Drawing.Point(81, 48);
            this.ckbTodosNenhum.Name = "ckbTodosNenhum";
            this.ckbTodosNenhum.Size = new System.Drawing.Size(136, 21);
            this.ckbTodosNenhum.TabIndex = 5;
            this.ckbTodosNenhum.Text = "Seleciona Todos";
            this.ckbTodosNenhum.UseVisualStyleBackColor = true;
            this.ckbTodosNenhum.CheckedChanged += new System.EventHandler(this.ckbTodosNenhum_CheckedChanged);
            // 
            // frmValidaReceitas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 577);
            this.Controls.Add(this.ckbTodosNenhum);
            this.Controls.Add(this.btnValidar);
            this.Controls.Add(this.chlReceitasValidar);
            this.Name = "frmValidaReceitas";
            this.Text = "frmValidaReceitas";
            this.Load += new System.EventHandler(this.frmValidaReceitas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckedListBox chlReceitasValidar;
        private System.Windows.Forms.Button btnValidar;
        private System.Windows.Forms.CheckBox ckbTodosNenhum;
    }
}