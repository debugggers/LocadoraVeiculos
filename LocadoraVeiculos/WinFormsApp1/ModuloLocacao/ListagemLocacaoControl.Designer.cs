namespace LocadoraVeiculosForm.ModuloLocacao
{
    partial class ListagemLocacaoControl
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
            this.gridLocacao = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridLocacao)).BeginInit();
            this.SuspendLayout();
            // 
            // gridLocacao
            // 
            this.gridLocacao.AllowUserToAddRows = false;
            this.gridLocacao.AllowUserToDeleteRows = false;
            this.gridLocacao.AllowUserToResizeColumns = false;
            this.gridLocacao.AllowUserToResizeRows = false;
            this.gridLocacao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridLocacao.Location = new System.Drawing.Point(0, 3);
            this.gridLocacao.Name = "gridLocacao";
            this.gridLocacao.RowTemplate.Height = 28;
            this.gridLocacao.Size = new System.Drawing.Size(824, 727);
            this.gridLocacao.TabIndex = 0;
            // 
            // ListagemLocacaoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridLocacao);
            this.Name = "ListagemLocacaoControl";
            this.Size = new System.Drawing.Size(827, 733);
            ((System.ComponentModel.ISupportInitialize)(this.gridLocacao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridLocacao;
    }
}
