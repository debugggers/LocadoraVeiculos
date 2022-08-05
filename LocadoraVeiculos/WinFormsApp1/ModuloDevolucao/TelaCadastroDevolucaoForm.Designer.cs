namespace LocadoraVeiculosForm.ModuloDevolucao
{
    partial class TelaCadastroDevolucaoForm
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
            this.comboBoxLocacoes = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDataDevolucaoPrevista = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDataLocacao = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPlanoCobranca = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPlaca = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGrupoVeiculos = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFuncionario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtQuilometragem = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dateTimePickerDevolucao = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBoxNivelTanque = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labelRodapeDevolucao = new System.Windows.Forms.ToolStripStatusLabel();
            this.Calcular = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.btnTaxas = new System.Windows.Forms.Button();
            this.btnAddTaxas = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selecione o Id da locação:";
            // 
            // comboBoxLocacoes
            // 
            this.comboBoxLocacoes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLocacoes.FormattingEnabled = true;
            this.comboBoxLocacoes.Location = new System.Drawing.Point(12, 27);
            this.comboBoxLocacoes.Name = "comboBoxLocacoes";
            this.comboBoxLocacoes.Size = new System.Drawing.Size(458, 23);
            this.comboBoxLocacoes.TabIndex = 1;
            this.comboBoxLocacoes.SelectedIndexChanged += new System.EventHandler(this.comboBoxLocacoes_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.txtDataDevolucaoPrevista);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtDataLocacao);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtPlanoCobranca);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtPlaca);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtGrupoVeiculos);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtCliente);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtFuncionario);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(961, 208);
            this.panel1.TabIndex = 11;
            // 
            // txtDataDevolucaoPrevista
            // 
            this.txtDataDevolucaoPrevista.Enabled = false;
            this.txtDataDevolucaoPrevista.Location = new System.Drawing.Point(4, 127);
            this.txtDataDevolucaoPrevista.Name = "txtDataDevolucaoPrevista";
            this.txtDataDevolucaoPrevista.Size = new System.Drawing.Size(230, 26);
            this.txtDataDevolucaoPrevista.TabIndex = 36;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 110);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(152, 15);
            this.label9.TabIndex = 14;
            this.label9.Text = "Data de devolução prevista:";
            // 
            // txtDataLocacao
            // 
            this.txtDataLocacao.Enabled = false;
            this.txtDataLocacao.Location = new System.Drawing.Point(474, 77);
            this.txtDataLocacao.Name = "txtDataLocacao";
            this.txtDataLocacao.Size = new System.Drawing.Size(230, 26);
            this.txtDataLocacao.TabIndex = 35;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(474, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 15);
            this.label8.TabIndex = 12;
            this.label8.Text = "Data  da locação:";
            // 
            // txtPlanoCobranca
            // 
            this.txtPlanoCobranca.Enabled = false;
            this.txtPlanoCobranca.Location = new System.Drawing.Point(229, 77);
            this.txtPlanoCobranca.Name = "txtPlanoCobranca";
            this.txtPlanoCobranca.Size = new System.Drawing.Size(230, 26);
            this.txtPlanoCobranca.TabIndex = 34;
            this.txtPlanoCobranca.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(229, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "Plano de cobrança:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // txtPlaca
            // 
            this.txtPlaca.Enabled = false;
            this.txtPlaca.Location = new System.Drawing.Point(4, 77);
            this.txtPlaca.Name = "txtPlaca";
            this.txtPlaca.Size = new System.Drawing.Size(230, 26);
            this.txtPlaca.TabIndex = 33;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Veículo:";
            // 
            // txtGrupoVeiculos
            // 
            this.txtGrupoVeiculos.Enabled = false;
            this.txtGrupoVeiculos.Location = new System.Drawing.Point(474, 28);
            this.txtGrupoVeiculos.Name = "txtGrupoVeiculos";
            this.txtGrupoVeiculos.Size = new System.Drawing.Size(230, 26);
            this.txtGrupoVeiculos.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(474, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Grupo de Veículo:";
            // 
            // txtCliente
            // 
            this.txtCliente.Enabled = false;
            this.txtCliente.Location = new System.Drawing.Point(229, 28);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(230, 26);
            this.txtCliente.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(229, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cliente:";
            // 
            // txtFuncionario
            // 
            this.txtFuncionario.Enabled = false;
            this.txtFuncionario.Location = new System.Drawing.Point(3, 28);
            this.txtFuncionario.Name = "txtFuncionario";
            this.txtFuncionario.Size = new System.Drawing.Size(230, 26);
            this.txtFuncionario.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Funcionário:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 238);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(152, 15);
            this.label7.TabIndex = 3;
            this.label7.Text = "Quilometragem do veículo:";
            // 
            // txtQuilometragem
            // 
            this.txtQuilometragem.Location = new System.Drawing.Point(13, 256);
            this.txtQuilometragem.Name = "txtQuilometragem";
            this.txtQuilometragem.Size = new System.Drawing.Size(234, 26);
            this.txtQuilometragem.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(242, 238);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(124, 15);
            this.label10.TabIndex = 5;
            this.label10.Text = "Data da de devolução:";
            // 
            // dateTimePickerDevolucao
            // 
            this.dateTimePickerDevolucao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDevolucao.Location = new System.Drawing.Point(242, 256);
            this.dateTimePickerDevolucao.Name = "dateTimePickerDevolucao";
            this.dateTimePickerDevolucao.Size = new System.Drawing.Size(228, 26);
            this.dateTimePickerDevolucao.TabIndex = 5;
            this.dateTimePickerDevolucao.ValueChanged += new System.EventHandler(this.dateTimePickerDevolucao_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 300);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(178, 15);
            this.label11.TabIndex = 7;
            this.label11.Text = "Nivel do tanque de combustivel:";
            // 
            // comboBoxNivelTanque
            // 
            this.comboBoxNivelTanque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNivelTanque.Enabled = false;
            this.comboBoxNivelTanque.FormattingEnabled = true;
            this.comboBoxNivelTanque.Location = new System.Drawing.Point(13, 317);
            this.comboBoxNivelTanque.Name = "comboBoxNivelTanque";
            this.comboBoxNivelTanque.Size = new System.Drawing.Size(234, 27);
            this.comboBoxNivelTanque.TabIndex = 4;
            this.comboBoxNivelTanque.SelectedIndexChanged += new System.EventHandler(this.comboBoxNivelTanque_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(235, 300);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 15);
            this.label12.TabIndex = 9;
            this.label12.Text = "Taxas adicionais:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(524, 309);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 15);
            this.label13.TabIndex = 14;
            this.label13.Text = "Valor total:";
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Location = new System.Drawing.Point(593, 309);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(82, 15);
            this.labelTotal.TabIndex = 15;
            this.labelTotal.Text = "_______________";
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCadastrar.Location = new System.Drawing.Point(744, 353);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(125, 52);
            this.btnCadastrar.TabIndex = 10;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(629, 353);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(125, 52);
            this.button2.TabIndex = 9;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelRodapeDevolucao});
            this.statusStrip1.Location = new System.Drawing.Point(0, 417);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            this.statusStrip1.Size = new System.Drawing.Size(864, 22);
            this.statusStrip1.TabIndex = 28;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // labelRodapeDevolucao
            // 
            this.labelRodapeDevolucao.Name = "labelRodapeDevolucao";
            this.labelRodapeDevolucao.Size = new System.Drawing.Size(52, 17);
            this.labelRodapeDevolucao.Text = "[rodapé]";
            // 
            // Calcular
            // 
            this.Calcular.Location = new System.Drawing.Point(605, 253);
            this.Calcular.Name = "Calcular";
            this.Calcular.Size = new System.Drawing.Size(86, 29);
            this.Calcular.TabIndex = 8;
            this.Calcular.Text = "Calcular";
            this.Calcular.UseVisualStyleBackColor = true;
            this.Calcular.Click += new System.EventHandler(this.Calcular_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(516, 258);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(82, 15);
            this.label14.TabIndex = 30;
            this.label14.Text = "Calcular valor:";
            // 
            // btnTaxas
            // 
            this.btnTaxas.Location = new System.Drawing.Point(235, 318);
            this.btnTaxas.Name = "btnTaxas";
            this.btnTaxas.Size = new System.Drawing.Size(127, 29);
            this.btnTaxas.TabIndex = 6;
            this.btnTaxas.Text = "Selecionar Taxas";
            this.btnTaxas.UseVisualStyleBackColor = true;
            this.btnTaxas.Click += new System.EventHandler(this.btnTaxas_Click);
            // 
            // btnAddTaxas
            // 
            this.btnAddTaxas.Location = new System.Drawing.Point(353, 317);
            this.btnAddTaxas.Name = "btnAddTaxas";
            this.btnAddTaxas.Size = new System.Drawing.Size(134, 29);
            this.btnAddTaxas.TabIndex = 7;
            this.btnAddTaxas.Text = "Adicionar Taxas";
            this.btnAddTaxas.UseVisualStyleBackColor = true;
            this.btnAddTaxas.Click += new System.EventHandler(this.btnAddTaxas_Click);
            // 
            // TelaCadastroDevolucaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 439);
            this.Controls.Add(this.btnAddTaxas);
            this.Controls.Add(this.btnTaxas);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.Calcular);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.comboBoxNivelTanque);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dateTimePickerDevolucao);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtQuilometragem);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.comboBoxLocacoes);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCadastroDevolucaoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Devoluções";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxLocacoes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtDataDevolucaoPrevista;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDataLocacao;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPlanoCobranca;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPlaca;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGrupoVeiculos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFuncionario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtQuilometragem;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dateTimePickerDevolucao;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBoxNivelTanque;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel labelRodapeDevolucao;
        private System.Windows.Forms.Button Calcular;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnTaxas;
        private System.Windows.Forms.Button btnAddTaxas;
    }
}