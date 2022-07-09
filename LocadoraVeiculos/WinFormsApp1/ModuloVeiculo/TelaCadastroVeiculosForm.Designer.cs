namespace LocadoraVeiculosForm.ModuloVeiculo
{
    partial class TelaCadastroVeiculosForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxGrupoVeiculos = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCor = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxCombustivel = new System.Windows.Forms.ComboBox();
            this.txtCapacidadeTanque = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAno = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtKm = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBoxVeiculo = new System.Windows.Forms.PictureBox();
            this.btnImagem = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.maskedTxtPlaca = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVeiculo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Grupo de veiculos:";
            // 
            // comboBoxGrupoVeiculos
            // 
            this.comboBoxGrupoVeiculos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGrupoVeiculos.FormattingEnabled = true;
            this.comboBoxGrupoVeiculos.Location = new System.Drawing.Point(14, 34);
            this.comboBoxGrupoVeiculos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxGrupoVeiculos.Name = "comboBoxGrupoVeiculos";
            this.comboBoxGrupoVeiculos.Size = new System.Drawing.Size(426, 27);
            this.comboBoxGrupoVeiculos.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Modelo:";
            // 
            // txtModelo
            // 
            this.txtModelo.Location = new System.Drawing.Point(14, 111);
            this.txtModelo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(201, 26);
            this.txtModelo.TabIndex = 3;
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(239, 111);
            this.txtMarca.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(201, 26);
            this.txtMarca.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(239, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Marca:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Placa:";
            // 
            // txtCor
            // 
            this.txtCor.Location = new System.Drawing.Point(239, 190);
            this.txtCor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCor.Name = "txtCor";
            this.txtCor.Size = new System.Drawing.Size(201, 26);
            this.txtCor.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(239, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "Cor:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 246);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 19);
            this.label6.TabIndex = 10;
            this.label6.Text = "Tipo Combustivel:";
            // 
            // comboBoxCombustivel
            // 
            this.comboBoxCombustivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCombustivel.FormattingEnabled = true;
            this.comboBoxCombustivel.Location = new System.Drawing.Point(14, 269);
            this.comboBoxCombustivel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxCombustivel.Name = "comboBoxCombustivel";
            this.comboBoxCombustivel.Size = new System.Drawing.Size(201, 27);
            this.comboBoxCombustivel.TabIndex = 11;
            // 
            // txtCapacidadeTanque
            // 
            this.txtCapacidadeTanque.Location = new System.Drawing.Point(239, 269);
            this.txtCapacidadeTanque.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCapacidadeTanque.Name = "txtCapacidadeTanque";
            this.txtCapacidadeTanque.Size = new System.Drawing.Size(201, 26);
            this.txtCapacidadeTanque.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(239, 246);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 19);
            this.label7.TabIndex = 12;
            this.label7.Text = "Capacidade do tanque:";
            // 
            // txtAno
            // 
            this.txtAno.Location = new System.Drawing.Point(14, 343);
            this.txtAno.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAno.Name = "txtAno";
            this.txtAno.Size = new System.Drawing.Size(201, 26);
            this.txtAno.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 320);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 19);
            this.label8.TabIndex = 14;
            this.label8.Text = "Ano:";
            // 
            // txtKm
            // 
            this.txtKm.Location = new System.Drawing.Point(239, 343);
            this.txtKm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtKm.Name = "txtKm";
            this.txtKm.Size = new System.Drawing.Size(201, 26);
            this.txtKm.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(239, 320);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 19);
            this.label9.TabIndex = 16;
            this.label9.Text = "Km percorridos:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 432);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 19);
            this.label10.TabIndex = 18;
            this.label10.Text = "Foto:";
            // 
            // pictureBoxVeiculo
            // 
            this.pictureBoxVeiculo.Location = new System.Drawing.Point(14, 455);
            this.pictureBoxVeiculo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBoxVeiculo.Name = "pictureBoxVeiculo";
            this.pictureBoxVeiculo.Size = new System.Drawing.Size(426, 209);
            this.pictureBoxVeiculo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxVeiculo.TabIndex = 19;
            this.pictureBoxVeiculo.TabStop = false;
            // 
            // btnImagem
            // 
            this.btnImagem.Location = new System.Drawing.Point(304, 418);
            this.btnImagem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnImagem.Name = "btnImagem";
            this.btnImagem.Size = new System.Drawing.Size(136, 29);
            this.btnImagem.TabIndex = 20;
            this.btnImagem.Text = "Escolher imagem";
            this.btnImagem.UseVisualStyleBackColor = true;
            this.btnImagem.Click += new System.EventHandler(this.btnImagem_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(230, 690);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(102, 51);
            this.btnCancelar.TabIndex = 21;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCadastrar.Location = new System.Drawing.Point(338, 690);
            this.btnCadastrar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(102, 51);
            this.btnCadastrar.TabIndex = 22;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog";
            // 
            // maskedTxtPlaca
            // 
            this.maskedTxtPlaca.Location = new System.Drawing.Point(14, 190);
            this.maskedTxtPlaca.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.maskedTxtPlaca.Name = "maskedTxtPlaca";
            this.maskedTxtPlaca.Size = new System.Drawing.Size(197, 26);
            this.maskedTxtPlaca.TabIndex = 23;
            // 
            // TelaCadastroVeiculosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 749);
            this.Controls.Add(this.maskedTxtPlaca);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnImagem);
            this.Controls.Add(this.pictureBoxVeiculo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtKm);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtAno);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCapacidadeTanque);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBoxCombustivel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMarca);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtModelo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxGrupoVeiculos);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCadastroVeiculosForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cadastro de veiculos";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVeiculo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxGrupoVeiculos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxCombustivel;
        private System.Windows.Forms.TextBox txtCapacidadeTanque;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAno;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtKm;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBoxVeiculo;
        private System.Windows.Forms.Button btnImagem;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MaskedTextBox maskedTxtPlaca;
    }
}