namespace LocadoraVeiculosForm.ModuloGrupoVeiculos
{
    partial class TelaCadastroGupoVeiculosForm
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
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.labelNOmeGrupoVEiculos = new System.Windows.Forms.Label();
            this.txtGrupoVeiculos = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(263, 128);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(79, 32);
            this.btnGravar.TabIndex = 0;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(357, 128);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 32);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // labelNOmeGrupoVEiculos
            // 
            this.labelNOmeGrupoVEiculos.AutoSize = true;
            this.labelNOmeGrupoVEiculos.Location = new System.Drawing.Point(24, 50);
            this.labelNOmeGrupoVEiculos.Name = "labelNOmeGrupoVEiculos";
            this.labelNOmeGrupoVEiculos.Size = new System.Drawing.Size(43, 15);
            this.labelNOmeGrupoVEiculos.TabIndex = 3;
            this.labelNOmeGrupoVEiculos.Text = "Nome:";
            this.labelNOmeGrupoVEiculos.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtGrupoVeiculos
            // 
            this.txtGrupoVeiculos.Location = new System.Drawing.Point(86, 47);
            this.txtGrupoVeiculos.Name = "txtGrupoVeiculos";
            this.txtGrupoVeiculos.Size = new System.Drawing.Size(350, 23);
            this.txtGrupoVeiculos.TabIndex = 4;
            // 
            // TelaCadastroGupoVeiculosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 189);
            this.Controls.Add(this.txtGrupoVeiculos);
            this.Controls.Add(this.labelNOmeGrupoVEiculos);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.Name = "TelaCadastroGupoVeiculosForm";
            this.Text = "Cadastro Gupo de Veiculos";
            this.Load += new System.EventHandler(this.TelaCadastroGupoVeiculosForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label labelNOmeGrupoVEiculos;
        private System.Windows.Forms.TextBox txtGrupoVeiculos;
    }
}