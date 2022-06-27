namespace LocadoraVeiculosForm.ModuloTaxa
{
    partial class ListagemTaxasControl
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
            this.gridTaxas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridTaxas)).BeginInit();
            this.SuspendLayout();
            // 
            // gridTaxas
            // 
            this.gridTaxas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTaxas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTaxas.Location = new System.Drawing.Point(0, 0);
            this.gridTaxas.Name = "gridTaxas";
            this.gridTaxas.RowTemplate.Height = 25;
            this.gridTaxas.Size = new System.Drawing.Size(667, 474);
            this.gridTaxas.TabIndex = 0;
            // 
            // ListagemTaxasControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridTaxas);
            this.Name = "ListagemTaxasControl";
            this.Size = new System.Drawing.Size(667, 474);
            ((System.ComponentModel.ISupportInitialize)(this.gridTaxas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridTaxas;
    }
}
