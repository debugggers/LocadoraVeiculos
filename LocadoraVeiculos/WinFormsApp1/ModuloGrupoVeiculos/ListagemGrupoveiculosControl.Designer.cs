namespace LocadoraVeiculosForm.ModuloGrupoVeiculos
{
    partial class ListagemGrupoveiculosControl
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
            this.gridGrupoVeiculos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridGrupoVeiculos)).BeginInit();
            this.SuspendLayout();
            // 
            // gridGrupoVeiculos
            // 
            this.gridGrupoVeiculos.AllowUserToAddRows = false;
            this.gridGrupoVeiculos.AllowUserToDeleteRows = false;
            this.gridGrupoVeiculos.AllowUserToResizeColumns = false;
            this.gridGrupoVeiculos.AllowUserToResizeRows = false;
            this.gridGrupoVeiculos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridGrupoVeiculos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridGrupoVeiculos.Location = new System.Drawing.Point(0, 0);
            this.gridGrupoVeiculos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridGrupoVeiculos.Name = "gridGrupoVeiculos";
            this.gridGrupoVeiculos.RowTemplate.Height = 28;
            this.gridGrupoVeiculos.Size = new System.Drawing.Size(703, 573);
            this.gridGrupoVeiculos.TabIndex = 3;
            this.gridGrupoVeiculos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridFuncionarios_CellContentClick);
            // 
            // ListagemGrupoveiculosControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridGrupoVeiculos);
            this.Name = "ListagemGrupoveiculosControl";
            this.Size = new System.Drawing.Size(703, 573);
            ((System.ComponentModel.ISupportInitialize)(this.gridGrupoVeiculos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridGrupoVeiculos;
    }
}
