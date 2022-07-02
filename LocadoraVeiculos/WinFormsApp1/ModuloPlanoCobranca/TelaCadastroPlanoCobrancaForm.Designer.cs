namespace LocadoraVeiculosForm.ModuloPlanoCobranca
{
    partial class TelaCadastroPlanoCobrancaForm
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
            this.comboBoxGrupoVeiculos = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labelRodapePlanoCobranca = new System.Windows.Forms.ToolStripStatusLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtValorDiario_Diario = new System.Windows.Forms.TextBox();
            this.txtValorPorKm_Diario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.tabControlTipoPlano = new System.Windows.Forms.TabControl();
            this.tabDiario = new System.Windows.Forms.TabPage();
            this.tabLivre = new System.Windows.Forms.TabPage();
            this.txtValorDiario_Livre = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabControlado = new System.Windows.Forms.TabPage();
            this.txtControleKm = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtValorPorKm_Controlado = new System.Windows.Forms.TextBox();
            this.txtValorDiario_Controlado = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.tabControlTipoPlano.SuspendLayout();
            this.tabDiario.SuspendLayout();
            this.tabLivre.SuspendLayout();
            this.tabControlado.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxGrupoVeiculos
            // 
            this.comboBoxGrupoVeiculos.DisplayMember = "Nome";
            this.comboBoxGrupoVeiculos.FormattingEnabled = true;
            this.comboBoxGrupoVeiculos.Location = new System.Drawing.Point(161, 81);
            this.comboBoxGrupoVeiculos.Name = "comboBoxGrupoVeiculos";
            this.comboBoxGrupoVeiculos.Size = new System.Drawing.Size(197, 27);
            this.comboBoxGrupoVeiculos.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Grupo de Veículos:";
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCadastrar.Location = new System.Drawing.Point(607, 530);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(91, 51);
            this.btnCadastrar.TabIndex = 10;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(507, 530);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(94, 51);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelRodapePlanoCobranca});
            this.statusStrip1.Location = new System.Drawing.Point(0, 601);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(724, 24);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // labelRodapePlanoCobranca
            // 
            this.labelRodapePlanoCobranca.Name = "labelRodapePlanoCobranca";
            this.labelRodapePlanoCobranca.Size = new System.Drawing.Size(60, 19);
            this.labelRodapePlanoCobranca.Text = "[rodapé]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Valor Diário:";
            // 
            // txtValorDiario_Diario
            // 
            this.txtValorDiario_Diario.Location = new System.Drawing.Point(79, 86);
            this.txtValorDiario_Diario.Name = "txtValorDiario_Diario";
            this.txtValorDiario_Diario.Size = new System.Drawing.Size(148, 26);
            this.txtValorDiario_Diario.TabIndex = 3;
            // 
            // txtValorPorKm_Diario
            // 
            this.txtValorPorKm_Diario.Location = new System.Drawing.Point(79, 179);
            this.txtValorPorKm_Diario.Name = "txtValorPorKm_Diario";
            this.txtValorPorKm_Diario.Size = new System.Drawing.Size(148, 26);
            this.txtValorPorKm_Diario.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(79, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Valor por KM:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(104, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 19);
            this.label7.TabIndex = 22;
            this.label7.Text = "Id:";
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(161, 24);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(148, 26);
            this.txtId.TabIndex = 1;
            // 
            // tabControlTipoPlano
            // 
            this.tabControlTipoPlano.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlTipoPlano.Controls.Add(this.tabDiario);
            this.tabControlTipoPlano.Controls.Add(this.tabLivre);
            this.tabControlTipoPlano.Controls.Add(this.tabControlado);
            this.tabControlTipoPlano.Location = new System.Drawing.Point(21, 165);
            this.tabControlTipoPlano.Name = "tabControlTipoPlano";
            this.tabControlTipoPlano.SelectedIndex = 0;
            this.tabControlTipoPlano.Size = new System.Drawing.Size(677, 359);
            this.tabControlTipoPlano.TabIndex = 23;
            // 
            // tabDiario
            // 
            this.tabDiario.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabDiario.Controls.Add(this.txtValorPorKm_Diario);
            this.tabDiario.Controls.Add(this.label2);
            this.tabDiario.Controls.Add(this.label3);
            this.tabDiario.Controls.Add(this.txtValorDiario_Diario);
            this.tabDiario.Location = new System.Drawing.Point(4, 28);
            this.tabDiario.Name = "tabDiario";
            this.tabDiario.Padding = new System.Windows.Forms.Padding(3);
            this.tabDiario.Size = new System.Drawing.Size(669, 327);
            this.tabDiario.TabIndex = 0;
            this.tabDiario.Text = "Diário";
            // 
            // tabLivre
            // 
            this.tabLivre.Controls.Add(this.txtValorDiario_Livre);
            this.tabLivre.Controls.Add(this.label9);
            this.tabLivre.Location = new System.Drawing.Point(4, 28);
            this.tabLivre.Name = "tabLivre";
            this.tabLivre.Padding = new System.Windows.Forms.Padding(3);
            this.tabLivre.Size = new System.Drawing.Size(669, 327);
            this.tabLivre.TabIndex = 1;
            this.tabLivre.Text = "Livre";
            this.tabLivre.UseVisualStyleBackColor = true;
            // 
            // txtValorDiario_Livre
            // 
            this.txtValorDiario_Livre.Location = new System.Drawing.Point(79, 86);
            this.txtValorDiario_Livre.Name = "txtValorDiario_Livre";
            this.txtValorDiario_Livre.Size = new System.Drawing.Size(148, 26);
            this.txtValorDiario_Livre.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(79, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 19);
            this.label9.TabIndex = 4;
            this.label9.Text = "Valor Diário:";
            // 
            // tabControlado
            // 
            this.tabControlado.Controls.Add(this.txtControleKm);
            this.tabControlado.Controls.Add(this.label8);
            this.tabControlado.Controls.Add(this.txtValorPorKm_Controlado);
            this.tabControlado.Controls.Add(this.txtValorDiario_Controlado);
            this.tabControlado.Controls.Add(this.label10);
            this.tabControlado.Controls.Add(this.label11);
            this.tabControlado.Location = new System.Drawing.Point(4, 28);
            this.tabControlado.Name = "tabControlado";
            this.tabControlado.Size = new System.Drawing.Size(669, 327);
            this.tabControlado.TabIndex = 2;
            this.tabControlado.Text = "Controlado";
            this.tabControlado.UseVisualStyleBackColor = true;
            // 
            // txtControleKm
            // 
            this.txtControleKm.Location = new System.Drawing.Point(79, 158);
            this.txtControleKm.Name = "txtControleKm";
            this.txtControleKm.Size = new System.Drawing.Size(152, 26);
            this.txtControleKm.TabIndex = 27;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(79, 118);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(184, 19);
            this.label8.TabIndex = 26;
            this.label8.Text = "Controle de Quilometragem:";
            // 
            // txtValorPorKm_Controlado
            // 
            this.txtValorPorKm_Controlado.Location = new System.Drawing.Point(79, 238);
            this.txtValorPorKm_Controlado.Name = "txtValorPorKm_Controlado";
            this.txtValorPorKm_Controlado.Size = new System.Drawing.Size(152, 26);
            this.txtValorPorKm_Controlado.TabIndex = 25;
            // 
            // txtValorDiario_Controlado
            // 
            this.txtValorDiario_Controlado.Location = new System.Drawing.Point(79, 78);
            this.txtValorDiario_Controlado.Name = "txtValorDiario_Controlado";
            this.txtValorDiario_Controlado.Size = new System.Drawing.Size(152, 26);
            this.txtValorDiario_Controlado.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(79, 198);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 19);
            this.label10.TabIndex = 24;
            this.label10.Text = "Valor por KM:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(79, 46);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 19);
            this.label11.TabIndex = 22;
            this.label11.Text = "Valor Diário:";
            // 
            // TelaCadastroPlanoCobrancaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 625);
            this.Controls.Add(this.tabControlTipoPlano);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxGrupoVeiculos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCadastroPlanoCobrancaForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tela de Cadastro de Plano de Cobranca";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControlTipoPlano.ResumeLayout(false);
            this.tabDiario.ResumeLayout(false);
            this.tabDiario.PerformLayout();
            this.tabLivre.ResumeLayout(false);
            this.tabLivre.PerformLayout();
            this.tabControlado.ResumeLayout(false);
            this.tabControlado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxGrupoVeiculos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel labelRodapePlanoCobranca;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtValorDiario_Diario;
        private System.Windows.Forms.TextBox txtValorPorKm_Diario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TabControl tabControlTipoPlano;
        private System.Windows.Forms.TabPage tabDiario;
        private System.Windows.Forms.TabPage tabLivre;
        private System.Windows.Forms.TextBox txtValorDiario_Livre;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tabControlado;
        private System.Windows.Forms.TextBox txtControleKm;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtValorPorKm_Controlado;
        private System.Windows.Forms.TextBox txtValorDiario_Controlado;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}