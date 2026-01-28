namespace AutoridadeRegisto
{
    partial class FrmAutoridadeRegisto
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAutoridadeRegisto));
            grpDadosEleitor = new GroupBox();
            lblStatus = new Label();
            label3 = new Label();
            lblElegivelValor = new Label();
            label2 = new Label();
            btnObterCredencial = new Button();
            txtCartaoCidadao = new TextBox();
            label1 = new Label();
            label5 = new Label();
            btnVotar = new Button();
            lstCandidatos = new ListBox();
            grpResultado = new GroupBox();
            picP = new PictureBox();
            picV = new PictureBox();
            picS = new PictureBox();
            lblMensagemInstr = new Label();
            lblMsgConfirmacao = new Label();
            lblCandSelecionado = new Label();
            label6 = new Label();
            grpDadosEleitor.SuspendLayout();
            grpResultado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picP).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picV).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picS).BeginInit();
            SuspendLayout();
            // 
            // grpDadosEleitor
            // 
            grpDadosEleitor.Controls.Add(lblStatus);
            grpDadosEleitor.Controls.Add(label3);
            grpDadosEleitor.Controls.Add(lblElegivelValor);
            grpDadosEleitor.Controls.Add(label2);
            grpDadosEleitor.Controls.Add(btnObterCredencial);
            grpDadosEleitor.Controls.Add(txtCartaoCidadao);
            grpDadosEleitor.Controls.Add(label1);
            grpDadosEleitor.Location = new Point(12, 12);
            grpDadosEleitor.Name = "grpDadosEleitor";
            grpDadosEleitor.Size = new Size(762, 205);
            grpDadosEleitor.TabIndex = 3;
            grpDadosEleitor.TabStop = false;
            grpDadosEleitor.Text = "Dados do Eleitor";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(67, 174);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(172, 15);
            lblStatus.TabIndex = 11;
            lblStatus.Text = "A contactar serviço de registo...";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 174);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 10;
            label3.Text = "Status:";
            // 
            // lblElegivelValor
            // 
            lblElegivelValor.AutoSize = true;
            lblElegivelValor.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblElegivelValor.Location = new Point(78, 80);
            lblElegivelValor.Name = "lblElegivelValor";
            lblElegivelValor.Size = new Size(30, 15);
            lblElegivelValor.TabIndex = 7;
            lblElegivelValor.Text = "N/D";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 80);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 6;
            label2.Text = "Elegível:";
            // 
            // btnObterCredencial
            // 
            btnObterCredencial.Location = new Point(178, 80);
            btnObterCredencial.Name = "btnObterCredencial";
            btnObterCredencial.Size = new Size(151, 42);
            btnObterCredencial.TabIndex = 5;
            btnObterCredencial.Text = "Obter Credencial";
            btnObterCredencial.UseVisualStyleBackColor = true;
            btnObterCredencial.Click += btnObterCredencial_Click;
            // 
            // txtCartaoCidadao
            // 
            txtCartaoCidadao.Location = new Point(153, 38);
            txtCartaoCidadao.Name = "txtCartaoCidadao";
            txtCartaoCidadao.Size = new Size(176, 23);
            txtCartaoCidadao.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 41);
            label1.Name = "label1";
            label1.Size = new Size(125, 15);
            label1.TabIndex = 3;
            label1.Text = "Nº Cartão de Cidadão:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.Location = new Point(21, 79);
            label5.Name = "label5";
            label5.Size = new Size(112, 15);
            label5.TabIndex = 16;
            label5.Text = "Lista de Candidatos";
            // 
            // btnVotar
            // 
            btnVotar.Enabled = false;
            btnVotar.Location = new Point(540, 253);
            btnVotar.Name = "btnVotar";
            btnVotar.Size = new Size(175, 73);
            btnVotar.TabIndex = 17;
            btnVotar.Text = "Votar";
            btnVotar.UseVisualStyleBackColor = true;
            btnVotar.Click += btnVotar_Click;
            // 
            // lstCandidatos
            // 
            lstCandidatos.BackColor = Color.Silver;
            lstCandidatos.FormattingEnabled = true;
            lstCandidatos.Location = new Point(21, 102);
            lstCandidatos.Name = "lstCandidatos";
            lstCandidatos.Size = new Size(308, 244);
            lstCandidatos.TabIndex = 18;
            lstCandidatos.SelectedIndexChanged += lstCandidatos_SelectedIndexChanged;
            // 
            // grpResultado
            // 
            grpResultado.Controls.Add(picP);
            grpResultado.Controls.Add(picV);
            grpResultado.Controls.Add(picS);
            grpResultado.Controls.Add(lblMensagemInstr);
            grpResultado.Controls.Add(lblMsgConfirmacao);
            grpResultado.Controls.Add(lblCandSelecionado);
            grpResultado.Controls.Add(label6);
            grpResultado.Controls.Add(lstCandidatos);
            grpResultado.Controls.Add(btnVotar);
            grpResultado.Controls.Add(label5);
            grpResultado.Location = new Point(12, 234);
            grpResultado.Name = "grpResultado";
            grpResultado.Size = new Size(762, 369);
            grpResultado.TabIndex = 4;
            grpResultado.TabStop = false;
            grpResultado.Text = "Votação";
            // 
            // picP
            // 
            picP.Image = (Image)resources.GetObject("picP.Image");
            picP.Location = new Point(363, 102);
            picP.Name = "picP";
            picP.Size = new Size(143, 244);
            picP.SizeMode = PictureBoxSizeMode.Zoom;
            picP.TabIndex = 25;
            picP.TabStop = false;
            picP.Visible = false;
            // 
            // picV
            // 
            picV.Image = (Image)resources.GetObject("picV.Image");
            picV.Location = new Point(363, 102);
            picV.Name = "picV";
            picV.Size = new Size(143, 244);
            picV.SizeMode = PictureBoxSizeMode.Zoom;
            picV.TabIndex = 24;
            picV.TabStop = false;
            picV.Visible = false;
            // 
            // picS
            // 
            picS.Image = (Image)resources.GetObject("picS.Image");
            picS.Location = new Point(363, 102);
            picS.Name = "picS";
            picS.Size = new Size(143, 244);
            picS.SizeMode = PictureBoxSizeMode.Zoom;
            picS.TabIndex = 23;
            picS.TabStop = false;
            picS.Visible = false;
            // 
            // lblMensagemInstr
            // 
            lblMensagemInstr.AutoSize = true;
            lblMensagemInstr.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblMensagemInstr.Location = new Point(261, 19);
            lblMensagemInstr.Name = "lblMensagemInstr";
            lblMensagemInstr.Size = new Size(263, 21);
            lblMensagemInstr.TabIndex = 22;
            lblMensagemInstr.Text = "Selecione o candidato(a) na lista.";
            lblMensagemInstr.Visible = false;
            // 
            // lblMsgConfirmacao
            // 
            lblMsgConfirmacao.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblMsgConfirmacao.ForeColor = Color.Green;
            lblMsgConfirmacao.Location = new Point(530, 130);
            lblMsgConfirmacao.Name = "lblMsgConfirmacao";
            lblMsgConfirmacao.Size = new Size(198, 93);
            lblMsgConfirmacao.TabIndex = 21;
            lblMsgConfirmacao.Text = "Verifique se o candidato(a) está correto(a) e prima o botão \"Votar\"";
            lblMsgConfirmacao.TextAlign = ContentAlignment.MiddleCenter;
            lblMsgConfirmacao.Visible = false;
            lblMsgConfirmacao.Click += lblMsgConfirmacao_Click;
            // 
            // lblCandSelecionado
            // 
            lblCandSelecionado.AutoSize = true;
            lblCandSelecionado.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCandSelecionado.Location = new Point(363, 79);
            lblCandSelecionado.Name = "lblCandSelecionado";
            lblCandSelecionado.Size = new Size(42, 21);
            lblCandSelecionado.TabIndex = 20;
            lblCandSelecionado.Text = "N/D";
            lblCandSelecionado.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(363, 59);
            label6.Name = "label6";
            label6.Size = new Size(131, 15);
            label6.TabIndex = 19;
            label6.Text = "Candidato selecionado:";
            // 
            // FrmAutoridadeRegisto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 636);
            Controls.Add(grpResultado);
            Controls.Add(grpDadosEleitor);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FrmAutoridadeRegisto";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Autoridade de Registo";
            Load += Form1_Load;
            grpDadosEleitor.ResumeLayout(false);
            grpDadosEleitor.PerformLayout();
            grpResultado.ResumeLayout(false);
            grpResultado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picP).EndInit();
            ((System.ComponentModel.ISupportInitialize)picV).EndInit();
            ((System.ComponentModel.ISupportInitialize)picS).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpDadosEleitor;
        private Button btnObterCredencial;
        private TextBox txtCartaoCidadao;
        private Label label1;
        private Label lblStatus;
        private Label label3;
        private Label lblElegivelValor;
        private Label label2;
        private Label label5;
        private Button btnVotar;
        private ListBox lstCandidatos;
        private GroupBox grpResultado;
        private Label lblMsgConfirmacao;
        private Label lblCandSelecionado;
        private Label label6;
        private Label lblMensagemInstr;
        private PictureBox picS;
        private PictureBox picP;
        private PictureBox picV;
    }
}
