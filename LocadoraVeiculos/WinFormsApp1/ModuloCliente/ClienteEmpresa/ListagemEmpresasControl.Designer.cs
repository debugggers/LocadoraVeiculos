namespace LocadoraVeiculosForm.ModuloCliente.ClienteEmpresa
{
    partial class ListagemEmpresasControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridPessoaJuridica = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridPessoaJuridica)).BeginInit();
            this.SuspendLayout();
            // 
            // gridPessoaJuridica
            // 
            this.gridPessoaJuridica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPessoaJuridica.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPessoaJuridica.Location = new System.Drawing.Point(0, 0);
            this.gridPessoaJuridica.Name = "gridPessoaJuridica";
            this.gridPessoaJuridica.RowTemplate.Height = 25;
            this.gridPessoaJuridica.Size = new System.Drawing.Size(583, 497);
            this.gridPessoaJuridica.TabIndex = 1;
            // 
            // ListagemEmpresasControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridPessoaJuridica);
            this.Name = "ListagemEmpresasControl";
            this.Size = new System.Drawing.Size(583, 497);
            ((System.ComponentModel.ISupportInitialize)(this.gridPessoaJuridica)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridPessoaJuridica;
    }
}
