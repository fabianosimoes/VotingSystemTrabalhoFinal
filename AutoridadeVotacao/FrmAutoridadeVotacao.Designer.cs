namespace AutoridadeVotacao
{
    partial class FrmAutoridadeVotacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAutoridadeVotacao));
            label1 = new Label();
            lblStatus = new Label();
            label2 = new Label();
            label8 = new Label();
            label9 = new Label();
            groupBox3 = new GroupBox();
            gridResultados = new DataGridView();
            btnVerResultados = new Button();
            label4 = new Label();
            label3 = new Label();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridResultados).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 401);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 0;
            label1.Text = "Status";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(89, 401);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(43, 15);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "Pronto";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(44, 401);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 0;
            label2.Text = "Status";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(332, 35);
            label8.Name = "label8";
            label8.Size = new Size(110, 15);
            label8.TabIndex = 12;
            label8.Text = "Lista de Candidatos";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(12, 35);
            label9.Name = "label9";
            label9.Size = new Size(66, 15);
            label9.TabIndex = 11;
            label9.Text = "Credencial:";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(gridResultados);
            groupBox3.Controls.Add(btnVerResultados);
            groupBox3.Controls.Add(label4);
            groupBox3.Location = new Point(22, 37);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(601, 345);
            groupBox3.TabIndex = 12;
            groupBox3.TabStop = false;
            groupBox3.Text = "Resultados";
            // 
            // gridResultados
            // 
            gridResultados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridResultados.Location = new Point(6, 116);
            gridResultados.Name = "gridResultados";
            gridResultados.Size = new Size(589, 199);
            gridResultados.TabIndex = 15;
            // 
            // btnVerResultados
            // 
            btnVerResultados.Location = new Point(22, 29);
            btnVerResultados.Name = "btnVerResultados";
            btnVerResultados.Size = new Size(155, 36);
            btnVerResultados.TabIndex = 13;
            btnVerResultados.Text = "Consultar Resultados";
            btnVerResultados.UseVisualStyleBackColor = true;
            btnVerResultados.Click += btnVerResultados_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 93);
            label4.Name = "label4";
            label4.Size = new Size(64, 15);
            label4.TabIndex = 11;
            label4.Text = "Resultados";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.ForeColor = Color.Green;
            label3.Location = new Point(244, 13);
            label3.Name = "label3";
            label3.Size = new Size(160, 21);
            label3.TabIndex = 13;
            label3.Text = "Apuração dos votos";
            // 
            // FrmAutoridadeVotacao
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(663, 433);
            Controls.Add(label3);
            Controls.Add(groupBox3);
            Controls.Add(label2);
            Controls.Add(lblStatus);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmAutoridadeVotacao";
            Text = "Autoridade Votação";
            Load += FrmAutoridadeVotacao_Load;
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridResultados).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblStatus;
        private Label label2;
        private Label label8;
        private Label label9;
        private GroupBox groupBox3;
        private DataGridView gridResultados;
        private Button btnVerResultados;
        private Label label4;
        private Label label3;
    }
}
