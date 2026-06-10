namespace ProjetoDA.Views
{
    partial class FormModoCompra
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
            this.lblOrcamentoDisponivel = new System.Windows.Forms.Label();
            this.dgvItens = new System.Windows.Forms.DataGridView();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnFecharCompra = new System.Windows.Forms.Button();
            this.lblOrcamento = new System.Windows.Forms.Label();
            this.cbTipos = new System.Windows.Forms.ComboBox();
            this.cbArtigos = new System.Windows.Forms.ComboBox();
            this.nudQuantidade = new System.Windows.Forms.NumericUpDown();
            this.nudPreco = new System.Windows.Forms.NumericUpDown();
            this.txtObservacoes = new System.Windows.Forms.TextBox();
            this.chkPrevisto = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantidade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPreco)).BeginInit();
            this.SuspendLayout();
            // 
            // lblOrcamentoDisponivel
            // 
            this.lblOrcamentoDisponivel.AutoSize = true;
            this.lblOrcamentoDisponivel.Location = new System.Drawing.Point(45, 35);
            this.lblOrcamentoDisponivel.Name = "lblOrcamentoDisponivel";
            this.lblOrcamentoDisponivel.Size = new System.Drawing.Size(70, 25);
            this.lblOrcamentoDisponivel.TabIndex = 0;
            this.lblOrcamentoDisponivel.Text = "label1";
            // 
            // dgvItens
            // 
            this.dgvItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItens.Location = new System.Drawing.Point(50, 121);
            this.dgvItens.Name = "dgvItens";
            this.dgvItens.RowHeadersWidth = 82;
            this.dgvItens.RowTemplate.Height = 33;
            this.dgvItens.Size = new System.Drawing.Size(566, 268);
            this.dgvItens.TabIndex = 1;
            this.dgvItens.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItens_CellContentClick);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(962, 130);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(140, 63);
            this.btnAdicionar.TabIndex = 9;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(962, 208);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(140, 68);
            this.btnEliminar.TabIndex = 10;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnFecharCompra
            // 
            this.btnFecharCompra.Location = new System.Drawing.Point(962, 282);
            this.btnFecharCompra.Name = "btnFecharCompra";
            this.btnFecharCompra.Size = new System.Drawing.Size(130, 85);
            this.btnFecharCompra.TabIndex = 11;
            this.btnFecharCompra.Text = "Fechar Compra";
            this.btnFecharCompra.UseVisualStyleBackColor = true;
            this.btnFecharCompra.Click += new System.EventHandler(this.btnFecharCompra_Click);
            // 
            // lblOrcamento
            // 
            this.lblOrcamento.AutoSize = true;
            this.lblOrcamento.Location = new System.Drawing.Point(330, 35);
            this.lblOrcamento.Name = "lblOrcamento";
            this.lblOrcamento.Size = new System.Drawing.Size(70, 25);
            this.lblOrcamento.TabIndex = 12;
            this.lblOrcamento.Text = "label1";
            // 
            // cbTipos
            // 
            this.cbTipos.FormattingEnabled = true;
            this.cbTipos.Location = new System.Drawing.Point(724, 297);
            this.cbTipos.Name = "cbTipos";
            this.cbTipos.Size = new System.Drawing.Size(121, 33);
            this.cbTipos.TabIndex = 13;
            this.cbTipos.SelectedIndexChanged += new System.EventHandler(this.cbTipos_SelectedIndexChanged_1);
            // 
            // cbArtigos
            // 
            this.cbArtigos.FormattingEnabled = true;
            this.cbArtigos.Location = new System.Drawing.Point(724, 392);
            this.cbArtigos.Name = "cbArtigos";
            this.cbArtigos.Size = new System.Drawing.Size(121, 33);
            this.cbArtigos.TabIndex = 14;
            // 
            // nudQuantidade
            // 
            this.nudQuantidade.Location = new System.Drawing.Point(709, 72);
            this.nudQuantidade.Name = "nudQuantidade";
            this.nudQuantidade.Size = new System.Drawing.Size(120, 31);
            this.nudQuantidade.TabIndex = 15;
            // 
            // nudPreco
            // 
            this.nudPreco.Location = new System.Drawing.Point(709, 162);
            this.nudPreco.Name = "nudPreco";
            this.nudPreco.Size = new System.Drawing.Size(120, 31);
            this.nudPreco.TabIndex = 16;
            // 
            // txtObservacoes
            // 
            this.txtObservacoes.Location = new System.Drawing.Point(88, 474);
            this.txtObservacoes.Multiline = true;
            this.txtObservacoes.Name = "txtObservacoes";
            this.txtObservacoes.Size = new System.Drawing.Size(312, 47);
            this.txtObservacoes.TabIndex = 17;
            // 
            // chkPrevisto
            // 
            this.chkPrevisto.AutoSize = true;
            this.chkPrevisto.Location = new System.Drawing.Point(554, 434);
            this.chkPrevisto.Name = "chkPrevisto";
            this.chkPrevisto.Size = new System.Drawing.Size(122, 29);
            this.chkPrevisto.TabIndex = 18;
            this.chkPrevisto.Text = "Previsto";
            this.chkPrevisto.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(706, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 25);
            this.label1.TabIndex = 19;
            this.label1.Text = "Quantidade";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(706, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 25);
            this.label2.TabIndex = 20;
            this.label2.Text = "Preço:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(719, 260);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 25);
            this.label3.TabIndex = 21;
            this.label3.Text = "Tipo de Artigo:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(719, 364);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 25);
            this.label4.TabIndex = 22;
            this.label4.Text = "Artigo:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(88, 443);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(181, 25);
            this.label5.TabIndex = 23;
            this.label5.Text = "Nome da compra:";
            // 
            // FormModoCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 703);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkPrevisto);
            this.Controls.Add(this.txtObservacoes);
            this.Controls.Add(this.nudPreco);
            this.Controls.Add(this.nudQuantidade);
            this.Controls.Add(this.cbArtigos);
            this.Controls.Add(this.cbTipos);
            this.Controls.Add(this.lblOrcamento);
            this.Controls.Add(this.btnFecharCompra);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.dgvItens);
            this.Controls.Add(this.lblOrcamentoDisponivel);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormModoCompra";
            this.Text = "FormModoCompra";
            this.Load += new System.EventHandler(this.FormModoCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantidade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPreco)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOrcamentoDisponivel;
        private System.Windows.Forms.DataGridView dgvItens;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnFecharCompra;
        private System.Windows.Forms.Label lblOrcamento;
        private System.Windows.Forms.ComboBox cbTipos;
        private System.Windows.Forms.ComboBox cbArtigos;
        private System.Windows.Forms.NumericUpDown nudQuantidade;
        private System.Windows.Forms.NumericUpDown nudPreco;
        private System.Windows.Forms.TextBox txtObservacoes;
        private System.Windows.Forms.CheckBox chkPrevisto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}