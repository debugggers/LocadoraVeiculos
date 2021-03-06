namespace LocadoraVeiculosForm.ModuloCliente
{
    partial class TelaCadastroClienteForm
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
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNumeroCnh = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonCadastrar = new System.Windows.Forms.Button();
            this.monthCalendarVencimento = new System.Windows.Forms.DateTimePicker();
            this.txtNomeCnh = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTelefone = new System.Windows.Forms.MaskedTextBox();
            this.txtCpf = new System.Windows.Forms.MaskedTextBox();
            this.comboBoxEmpresas = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBoxCondutor = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome:";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(12, 27);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(253, 23);
            this.txtNome.TabIndex = 1;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(12, 82);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(253, 23);
            this.txtEmail.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Email:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Telefone((xx) xxxxx-xxxx):";
            // 
            // txtEndereco
            // 
            this.txtEndereco.Location = new System.Drawing.Point(12, 194);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(253, 23);
            this.txtEndereco.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Endereço";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "CPF:";
            // 
            // txtNumeroCnh
            // 
            this.txtNumeroCnh.Location = new System.Drawing.Point(311, 27);
            this.txtNumeroCnh.Name = "txtNumeroCnh";
            this.txtNumeroCnh.Size = new System.Drawing.Size(253, 23);
            this.txtNumeroCnh.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(311, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Número da CNH:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(311, 119);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 15);
            this.label8.TabIndex = 14;
            this.label8.Text = "Vencimento da CNH:";
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelar.Location = new System.Drawing.Point(369, 302);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(95, 44);
            this.buttonCancelar.TabIndex = 16;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            // 
            // buttonCadastrar
            // 
            this.buttonCadastrar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonCadastrar.Location = new System.Drawing.Point(470, 302);
            this.buttonCadastrar.Name = "buttonCadastrar";
            this.buttonCadastrar.Size = new System.Drawing.Size(95, 44);
            this.buttonCadastrar.TabIndex = 17;
            this.buttonCadastrar.Text = "Cadastrar";
            this.buttonCadastrar.UseVisualStyleBackColor = true;
            this.buttonCadastrar.Click += new System.EventHandler(this.buttonCadastrar_Click);
            // 
            // monthCalendarVencimento
            // 
            this.monthCalendarVencimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.monthCalendarVencimento.Location = new System.Drawing.Point(311, 137);
            this.monthCalendarVencimento.Name = "monthCalendarVencimento";
            this.monthCalendarVencimento.Size = new System.Drawing.Size(253, 23);
            this.monthCalendarVencimento.TabIndex = 19;
            // 
            // txtNomeCnh
            // 
            this.txtNomeCnh.Location = new System.Drawing.Point(311, 82);
            this.txtNomeCnh.Name = "txtNomeCnh";
            this.txtNomeCnh.Size = new System.Drawing.Size(253, 23);
            this.txtNomeCnh.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(311, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 15);
            this.label7.TabIndex = 20;
            this.label7.Text = "Nome da CNH:";
            // 
            // txtTelefone
            // 
            this.txtTelefone.Location = new System.Drawing.Point(12, 140);
            this.txtTelefone.Mask = "(99)99999-9999";
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(253, 23);
            this.txtTelefone.TabIndex = 22;
            // 
            // txtCpf
            // 
            this.txtCpf.Location = new System.Drawing.Point(12, 247);
            this.txtCpf.Mask = "000.000.000-00";
            this.txtCpf.Name = "txtCpf";
            this.txtCpf.Size = new System.Drawing.Size(253, 23);
            this.txtCpf.TabIndex = 23;
            this.txtCpf.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // comboBoxEmpresas
            // 
            this.comboBoxEmpresas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEmpresas.FormattingEnabled = true;
            this.comboBoxEmpresas.Location = new System.Drawing.Point(311, 221);
            this.comboBoxEmpresas.Name = "comboBoxEmpresas";
            this.comboBoxEmpresas.Size = new System.Drawing.Size(253, 23);
            this.comboBoxEmpresas.TabIndex = 25;
            this.comboBoxEmpresas.SelectedIndexChanged += new System.EventHandler(this.comboBoxPessoasFisicas_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(311, 203);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(189, 15);
            this.label9.TabIndex = 24;
            this.label9.Text = "Selecione o nome de sua empresa:";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // checkBoxCondutor
            // 
            this.checkBoxCondutor.AutoSize = true;
            this.checkBoxCondutor.Location = new System.Drawing.Point(311, 175);
            this.checkBoxCondutor.Name = "checkBoxCondutor";
            this.checkBoxCondutor.Size = new System.Drawing.Size(151, 19);
            this.checkBoxCondutor.TabIndex = 26;
            this.checkBoxCondutor.Text = "Condutor para empresa";
            this.checkBoxCondutor.UseVisualStyleBackColor = true;
            this.checkBoxCondutor.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // TelaCadastroClienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 358);
            this.Controls.Add(this.checkBoxCondutor);
            this.Controls.Add(this.comboBoxEmpresas);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtCpf);
            this.Controls.Add(this.txtTelefone);
            this.Controls.Add(this.txtNomeCnh);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.monthCalendarVencimento);
            this.Controls.Add(this.buttonCadastrar);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtNumeroCnh);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtEndereco);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCadastroClienteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de pessoas físicas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNumeroCnh;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonCadastrar;
        private System.Windows.Forms.DateTimePicker monthCalendarVencimento;
        private System.Windows.Forms.TextBox txtNomeCnh;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox txtTelefone;
        private System.Windows.Forms.MaskedTextBox txtCpf;
        private System.Windows.Forms.ComboBox comboBoxEmpresas;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkBoxCondutor;
    }
}