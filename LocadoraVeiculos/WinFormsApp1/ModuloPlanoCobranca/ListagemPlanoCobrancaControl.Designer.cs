namespace LocadoraVeiculosForm.ModuloPlanoCobranca
{
    partial class ListagemPlanoCobrancaControl
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
            this.gridPlanoCobranca = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridPlanoCobranca)).BeginInit();
            this.SuspendLayout();
            // 
            // gridPlanoCobranca
            // 
            this.gridPlanoCobranca.AllowUserToAddRows = false;
            this.gridPlanoCobranca.AllowUserToDeleteRows = false;
            this.gridPlanoCobranca.AllowUserToResizeColumns = false;
            this.gridPlanoCobranca.AllowUserToResizeRows = false;
            this.gridPlanoCobranca.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPlanoCobranca.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPlanoCobranca.Location = new System.Drawing.Point(0, 0);
            this.gridPlanoCobranca.Name = "gridPlanoCobranca";
            this.gridPlanoCobranca.RowTemplate.Height = 28;
            this.gridPlanoCobranca.Size = new System.Drawing.Size(1160, 778);
            this.gridPlanoCobranca.TabIndex = 0;
            // 
            // ListagemPlanoCobrancaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridPlanoCobranca);
            this.Name = "ListagemPlanoCobrancaControl";
            this.Size = new System.Drawing.Size(1160, 778);
            ((System.ComponentModel.ISupportInitialize)(this.gridPlanoCobranca)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridPlanoCobranca;
    }
}
