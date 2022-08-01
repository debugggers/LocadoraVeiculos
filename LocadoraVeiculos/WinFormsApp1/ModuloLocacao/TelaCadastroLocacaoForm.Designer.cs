namespace LocadoraVeiculosForm.ModuloLocacao
{
    partial class TelaCadastroLocacaoForm
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
            this.labelFuncionario = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxClientes = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxGrupoVeiculos = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxVeiculo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxPlanosCobranca = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.labelKmVeiculo = new System.Windows.Forms.Label();
            this.dateTimeLocacao = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dateTimePrevisaoEntrega = new System.Windows.Forms.DateTimePicker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabTaxas = new System.Windows.Forms.TabPage();
            this.checkedListBoxTaxas = new System.Windows.Forms.CheckedListBox();
            this.label11 = new System.Windows.Forms.Label();
            this.labelValorPrevisto = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labelRodapeLocacao = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1.SuspendLayout();
            this.tabTaxas.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Funcionário:";
            // 
            // labelFuncionario
            // 
            this.labelFuncionario.AutoSize = true;
            this.labelFuncionario.Location = new System.Drawing.Point(173, 40);
            this.labelFuncionario.Name = "labelFuncionario";
            this.labelFuncionario.Size = new System.Drawing.Size(0, 19);
            this.labelFuncionario.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(499, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cliente:";
            // 
            // comboBoxClientes
            // 
            this.comboBoxClientes.DisplayMember = "Nome";
            this.comboBoxClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxClientes.FormattingEnabled = true;
            this.comboBoxClientes.Location = new System.Drawing.Point(570, 32);
            this.comboBoxClientes.Name = "comboBoxClientes";
            this.comboBoxClientes.Size = new System.Drawing.Size(214, 27);
            this.comboBoxClientes.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Grupo de Veículos:";
            // 
            // comboBoxGrupoVeiculos
            // 
            this.comboBoxGrupoVeiculos.DisplayMember = "Nome";
            this.comboBoxGrupoVeiculos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGrupoVeiculos.FormattingEnabled = true;
            this.comboBoxGrupoVeiculos.Location = new System.Drawing.Point(173, 83);
            this.comboBoxGrupoVeiculos.Name = "comboBoxGrupoVeiculos";
            this.comboBoxGrupoVeiculos.Size = new System.Drawing.Size(214, 27);
            this.comboBoxGrupoVeiculos.TabIndex = 2;
            this.comboBoxGrupoVeiculos.SelectedIndexChanged += new System.EventHandler(this.comboBoxGrupoVeiculos_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(501, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "Veículo:";
            // 
            // comboBoxVeiculo
            // 
            this.comboBoxVeiculo.DisplayMember = "Modelo";
            this.comboBoxVeiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVeiculo.FormattingEnabled = true;
            this.comboBoxVeiculo.Location = new System.Drawing.Point(570, 83);
            this.comboBoxVeiculo.Name = "comboBoxVeiculo";
            this.comboBoxVeiculo.Size = new System.Drawing.Size(214, 27);
            this.comboBoxVeiculo.TabIndex = 3;
            this.comboBoxVeiculo.SelectedIndexChanged += new System.EventHandler(this.comboBoxVeiculo_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 19);
            this.label6.TabIndex = 11;
            this.label6.Text = "Plano de Cobrança:";
            // 
            // comboBoxPlanosCobranca
            // 
            this.comboBoxPlanosCobranca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlanosCobranca.FormattingEnabled = true;
            this.comboBoxPlanosCobranca.Location = new System.Drawing.Point(173, 135);
            this.comboBoxPlanosCobranca.Name = "comboBoxPlanosCobranca";
            this.comboBoxPlanosCobranca.Size = new System.Drawing.Size(214, 27);
            this.comboBoxPlanosCobranca.TabIndex = 4;
            this.comboBoxPlanosCobranca.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlanosCobranca_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(477, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 19);
            this.label7.TabIndex = 13;
            this.label7.Text = "Km Veículo:";
            // 
            // labelKmVeiculo
            // 
            this.labelKmVeiculo.AutoSize = true;
            this.labelKmVeiculo.Location = new System.Drawing.Point(570, 143);
            this.labelKmVeiculo.Name = "labelKmVeiculo";
            this.labelKmVeiculo.Size = new System.Drawing.Size(0, 19);
            this.labelKmVeiculo.TabIndex = 14;
            // 
            // dateTimeLocacao
            // 
            this.dateTimeLocacao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeLocacao.Location = new System.Drawing.Point(173, 192);
            this.dateTimeLocacao.Name = "dateTimeLocacao";
            this.dateTimeLocacao.Size = new System.Drawing.Size(111, 26);
            this.dateTimeLocacao.TabIndex = 5;
            this.dateTimeLocacao.ValueChanged += new System.EventHandler(this.dateTimeLocacao_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(47, 199);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 19);
            this.label9.TabIndex = 16;
            this.label9.Text = "Data da Locação:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(393, 199);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(163, 19);
            this.label10.TabIndex = 18;
            this.label10.Text = "Data Prevista da Entrega:";
            // 
            // dateTimePrevisaoEntrega
            // 
            this.dateTimePrevisaoEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePrevisaoEntrega.Location = new System.Drawing.Point(570, 192);
            this.dateTimePrevisaoEntrega.Name = "dateTimePrevisaoEntrega";
            this.dateTimePrevisaoEntrega.Size = new System.Drawing.Size(111, 26);
            this.dateTimePrevisaoEntrega.TabIndex = 6;
            this.dateTimePrevisaoEntrega.ValueChanged += new System.EventHandler(this.dateTimePrevisaoEntrega_ValueChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabTaxas);
            this.tabControl1.Location = new System.Drawing.Point(47, 264);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(734, 227);
            this.tabControl1.TabIndex = 19;
            // 
            // tabTaxas
            // 
            this.tabTaxas.Controls.Add(this.checkedListBoxTaxas);
            this.tabTaxas.Location = new System.Drawing.Point(4, 28);
            this.tabTaxas.Name = "tabTaxas";
            this.tabTaxas.Padding = new System.Windows.Forms.Padding(3);
            this.tabTaxas.Size = new System.Drawing.Size(726, 195);
            this.tabTaxas.TabIndex = 0;
            this.tabTaxas.Text = "Taxas da Locação";
            this.tabTaxas.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxTaxas
            // 
            this.checkedListBoxTaxas.FormattingEnabled = true;
            this.checkedListBoxTaxas.Location = new System.Drawing.Point(6, 17);
            this.checkedListBoxTaxas.Name = "checkedListBoxTaxas";
            this.checkedListBoxTaxas.Size = new System.Drawing.Size(714, 151);
            this.checkedListBoxTaxas.TabIndex = 7;
            this.checkedListBoxTaxas.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxTaxas_ItemCheck);
            this.checkedListBoxTaxas.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxTaxas_SelectedIndexChanged);
            this.checkedListBoxTaxas.KeyUp += new System.Windows.Forms.KeyEventHandler(this.checkedListBoxTaxas_KeyUp);
            this.checkedListBoxTaxas.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.checkedListBoxTaxas_MouseDoubleClick);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(53, 515);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 19);
            this.label11.TabIndex = 20;
            this.label11.Text = "Valor Previsto:";
            // 
            // labelValorPrevisto
            // 
            this.labelValorPrevisto.AutoSize = true;
            this.labelValorPrevisto.Location = new System.Drawing.Point(173, 515);
            this.labelValorPrevisto.Name = "labelValorPrevisto";
            this.labelValorPrevisto.Size = new System.Drawing.Size(92, 19);
            this.labelValorPrevisto.TabIndex = 21;
            this.labelValorPrevisto.Text = "valor previsto";
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(590, 527);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(94, 51);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCadastrar.Location = new System.Drawing.Point(690, 527);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(91, 51);
            this.btnCadastrar.TabIndex = 9;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelRodapeLocacao});
            this.statusStrip1.Location = new System.Drawing.Point(0, 593);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(817, 24);
            this.statusStrip1.TabIndex = 24;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // labelRodapeLocacao
            // 
            this.labelRodapeLocacao.Name = "labelRodapeLocacao";
            this.labelRodapeLocacao.Size = new System.Drawing.Size(60, 19);
            this.labelRodapeLocacao.Text = "[rodapé]";
            // 
            // TelaCadastroLocacaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 617);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.labelValorPrevisto);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dateTimePrevisaoEntrega);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dateTimeLocacao);
            this.Controls.Add(this.labelKmVeiculo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBoxPlanosCobranca);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBoxVeiculo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxGrupoVeiculos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxClientes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelFuncionario);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCadastroLocacaoForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tela de Cadastro de Locação";
            this.tabControl1.ResumeLayout(false);
            this.tabTaxas.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelFuncionario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxClientes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxGrupoVeiculos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxVeiculo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxPlanosCobranca;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelKmVeiculo;
        private System.Windows.Forms.DateTimePicker dateTimeLocacao;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dateTimePrevisaoEntrega;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabTaxas;
        private System.Windows.Forms.CheckedListBox checkedListBoxTaxas;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label labelValorPrevisto;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel labelRodapeLocacao;
    }
}