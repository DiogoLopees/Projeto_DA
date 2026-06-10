namespace ProjetoDA.Views
{
    partial class FormPrincipal
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
            this.lblUtilizador = new System.Windows.Forms.Label();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnUtilizadores = new System.Windows.Forms.Button();
            this.btnTiposArtigo = new System.Windows.Forms.Button();
            this.btnArtigos = new System.Windows.Forms.Button();
            this.btnOrcamentos = new System.Windows.Forms.Button();
            this.btnCompras = new System.Windows.Forms.Button();
            this.btnEstatisticas = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvComprasAbertas = new System.Windows.Forms.DataGridView();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Itens = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnIniciarCompra = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComprasAbertas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "IShopping";
            // 
            // lblUtilizador
            // 
            this.lblUtilizador.AutoSize = true;
            this.lblUtilizador.Location = new System.Drawing.Point(376, 34);
            this.lblUtilizador.Name = "lblUtilizador";
            this.lblUtilizador.Size = new System.Drawing.Size(69, 16);
            this.lblUtilizador.TabIndex = 1;
            this.lblUtilizador.Text = "Utilizador :";
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(573, 25);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(70, 35);
            this.btnSair.TabIndex = 2;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            // 
            // btnUtilizadores
            // 
            this.btnUtilizadores.Location = new System.Drawing.Point(26, 62);
            this.btnUtilizadores.Name = "btnUtilizadores";
            this.btnUtilizadores.Size = new System.Drawing.Size(126, 31);
            this.btnUtilizadores.TabIndex = 3;
            this.btnUtilizadores.Text = "👤 Utilizadores";
            this.btnUtilizadores.UseVisualStyleBackColor = true;
            this.btnUtilizadores.Click += new System.EventHandler(this.btnUtilizadores_Click_1);
            // 
            // btnTiposArtigo
            // 
            this.btnTiposArtigo.Location = new System.Drawing.Point(26, 99);
            this.btnTiposArtigo.Name = "btnTiposArtigo";
            this.btnTiposArtigo.Size = new System.Drawing.Size(126, 31);
            this.btnTiposArtigo.TabIndex = 4;
            this.btnTiposArtigo.Text = "📦 Tipos de Artigo";
            this.btnTiposArtigo.UseVisualStyleBackColor = true;
            // 
            // btnArtigos
            // 
            this.btnArtigos.Location = new System.Drawing.Point(26, 136);
            this.btnArtigos.Name = "btnArtigos";
            this.btnArtigos.Size = new System.Drawing.Size(126, 31);
            this.btnArtigos.TabIndex = 5;
            this.btnArtigos.Text = "🏷️ Artigos";
            this.btnArtigos.UseVisualStyleBackColor = true;
            // 
            // btnOrcamentos
            // 
            this.btnOrcamentos.Location = new System.Drawing.Point(26, 173);
            this.btnOrcamentos.Name = "btnOrcamentos";
            this.btnOrcamentos.Size = new System.Drawing.Size(126, 31);
            this.btnOrcamentos.TabIndex = 6;
            this.btnOrcamentos.Text = "💰 Orçamentos";
            this.btnOrcamentos.UseVisualStyleBackColor = true;
            // 
            // btnCompras
            // 
            this.btnCompras.Location = new System.Drawing.Point(26, 210);
            this.btnCompras.Name = "btnCompras";
            this.btnCompras.Size = new System.Drawing.Size(126, 43);
            this.btnCompras.TabIndex = 7;
            this.btnCompras.Text = "🛒 Planeamento de Compras";
            this.btnCompras.UseVisualStyleBackColor = true;
            // 
            // btnEstatisticas
            // 
            this.btnEstatisticas.Location = new System.Drawing.Point(26, 259);
            this.btnEstatisticas.Name = "btnEstatisticas";
            this.btnEstatisticas.Size = new System.Drawing.Size(126, 31);
            this.btnEstatisticas.TabIndex = 8;
            this.btnEstatisticas.Text = "📊 Estatísticas";
            this.btnEstatisticas.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(212, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Compras em Aberto :";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // dgvComprasAbertas
            // 
            this.dgvComprasAbertas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComprasAbertas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nome,
            this.Data,
            this.Itens});
            this.dgvComprasAbertas.Location = new System.Drawing.Point(215, 95);
            this.dgvComprasAbertas.Name = "dgvComprasAbertas";
            this.dgvComprasAbertas.RowHeadersWidth = 51;
            this.dgvComprasAbertas.RowTemplate.Height = 24;
            this.dgvComprasAbertas.Size = new System.Drawing.Size(428, 195);
            this.dgvComprasAbertas.TabIndex = 11;
            // 
            // Nome
            // 
            this.Nome.HeaderText = "Nome";
            this.Nome.MinimumWidth = 6;
            this.Nome.Name = "Nome";
            this.Nome.Width = 125;
            // 
            // Data
            // 
            this.Data.HeaderText = "Data";
            this.Data.MinimumWidth = 6;
            this.Data.Name = "Data";
            this.Data.Width = 125;
            // 
            // Itens
            // 
            this.Itens.HeaderText = "Itens";
            this.Itens.MinimumWidth = 6;
            this.Itens.Name = "Itens";
            this.Itens.Width = 125;
            // 
            // btnIniciarCompra
            // 
            this.btnIniciarCompra.Location = new System.Drawing.Point(215, 311);
            this.btnIniciarCompra.Name = "btnIniciarCompra";
            this.btnIniciarCompra.Size = new System.Drawing.Size(228, 30);
            this.btnIniciarCompra.TabIndex = 12;
            this.btnIniciarCompra.Text = "🛒 Iniciar Compra";
            this.btnIniciarCompra.UseVisualStyleBackColor = true;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnIniciarCompra);
            this.Controls.Add(this.dgvComprasAbertas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnEstatisticas);
            this.Controls.Add(this.btnCompras);
            this.Controls.Add(this.btnOrcamentos);
            this.Controls.Add(this.btnArtigos);
            this.Controls.Add(this.btnTiposArtigo);
            this.Controls.Add(this.btnUtilizadores);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.lblUtilizador);
            this.Controls.Add(this.label1);
            this.Name = "FormPrincipal";
            this.Text = "FormPrincipal";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvComprasAbertas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUtilizador;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnUtilizadores;
        private System.Windows.Forms.Button btnTiposArtigo;
        private System.Windows.Forms.Button btnArtigos;
        private System.Windows.Forms.Button btnOrcamentos;
        private System.Windows.Forms.Button btnCompras;
        private System.Windows.Forms.Button btnEstatisticas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvComprasAbertas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Itens;
        private System.Windows.Forms.Button btnIniciarCompra;
    }
}