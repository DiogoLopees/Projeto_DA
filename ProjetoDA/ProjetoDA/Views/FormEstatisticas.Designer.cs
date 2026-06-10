namespace ProjetoDA.Views
{
    partial class FormEstatisticas
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
            this.dgvPercentagens = new System.Windows.Forms.DataGridView();
            this.dgvResumo = new System.Windows.Forms.DataGridView();
            this.lblSugestao = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPercentagens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResumo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPercentagens
            // 
            this.dgvPercentagens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPercentagens.Location = new System.Drawing.Point(45, 383);
            this.dgvPercentagens.Name = "dgvPercentagens";
            this.dgvPercentagens.RowHeadersWidth = 82;
            this.dgvPercentagens.RowTemplate.Height = 33;
            this.dgvPercentagens.Size = new System.Drawing.Size(599, 165);
            this.dgvPercentagens.TabIndex = 1;
            this.dgvPercentagens.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPercentagens_CellContentClick);
            // 
            // dgvResumo
            // 
            this.dgvResumo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResumo.Location = new System.Drawing.Point(45, 96);
            this.dgvResumo.Name = "dgvResumo";
            this.dgvResumo.RowHeadersWidth = 82;
            this.dgvResumo.RowTemplate.Height = 33;
            this.dgvResumo.Size = new System.Drawing.Size(599, 165);
            this.dgvResumo.TabIndex = 2;
            // 
            // lblSugestao
            // 
            this.lblSugestao.AutoSize = true;
            this.lblSugestao.Location = new System.Drawing.Point(689, 290);
            this.lblSugestao.Name = "lblSugestao";
            this.lblSugestao.Size = new System.Drawing.Size(70, 25);
            this.lblSugestao.TabIndex = 4;
            this.lblSugestao.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Resume:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 352);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Percentagens:";
            // 
            // FormEstatisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1688, 583);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSugestao);
            this.Controls.Add(this.dgvResumo);
            this.Controls.Add(this.dgvPercentagens);
            this.Name = "FormEstatisticas";
            this.Text = "FormEstatisticas";
            this.Load += new System.EventHandler(this.FormEstatisticas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPercentagens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResumo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvPercentagens;
        private System.Windows.Forms.DataGridView dgvResumo;
        private System.Windows.Forms.Label lblSugestao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}