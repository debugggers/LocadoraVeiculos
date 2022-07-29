namespace LocadoraVeiculosForm.ModuloDevolucao
{
    partial class ListagemDevolucoesControl
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
            this.GridDevolucao = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.GridDevolucao)).BeginInit();
            this.SuspendLayout();
            // 
            // GridDevolucao
            // 
            this.GridDevolucao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridDevolucao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridDevolucao.Location = new System.Drawing.Point(0, 0);
            this.GridDevolucao.Name = "GridDevolucao";
            this.GridDevolucao.RowTemplate.Height = 25;
            this.GridDevolucao.Size = new System.Drawing.Size(800, 505);
            this.GridDevolucao.TabIndex = 0;
            // 
            // ListagemDevolucoesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GridDevolucao);
            this.Name = "ListagemDevolucoesControl";
            this.Size = new System.Drawing.Size(800, 505);
            ((System.ComponentModel.ISupportInitialize)(this.GridDevolucao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView GridDevolucao;
    }
}
