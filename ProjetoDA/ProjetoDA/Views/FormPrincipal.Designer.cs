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
            this.label1.Location = new System.Drawing.Point(40, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IShopping";
            // 
            // lblUtilizador
            // 
            this.lblUtilizador.AutoSize = true;
            this.lblUtilizador.Location = new System.Drawing.Point(282, 28);
            this.lblUtilizador.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUtilizador.Name = "lblUtilizador";
            this.lblUtilizador.Size = new System.Drawing.Size(56, 13);
            this.lblUtilizador.TabIndex = 1;
            this.lblUtilizador.Text = "Utilizador :";
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(430, 20);
            this.btnSair.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(52, 29);
            this.btnSair.TabIndex = 2;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click_1);
            // 
            // btnUtilizadores
            // 
            this.btnUtilizadores.Location = new System.Drawing.Point(20, 50);
            this.btnUtilizadores.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnUtilizadores.Name = "btnUtilizadores";
            this.btnUtilizadores.Size = new System.Drawing.Size(94, 25);
            this.btnUtilizadores.TabIndex = 3;
            this.btnUtilizadores.Text = "Utilizadores";
            this.btnUtilizadores.UseVisualStyleBackColor = true;
            this.btnUtilizadores.Click += new System.EventHandler(this.btnUtilizadores_Click_1);
            // 
            // btnTiposArtigo
            // 
            this.btnTiposArtigo.Location = new System.Drawing.Point(20, 81);
            this.btnTiposArtigo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnTiposArtigo.Name = "btnTiposArtigo";
            this.btnTiposArtigo.Size = new System.Drawing.Size(119, 25);
            this.btnTiposArtigo.TabIndex = 4;
            this.btnTiposArtigo.Text = "Tipos de Artigo";
            this.btnTiposArtigo.UseVisualStyleBackColor = true;
            this.btnTiposArtigo.Click += new System.EventHandler(this.btnTiposArtigo_Click_1);
            // 
            // btnArtigos
            // 
            this.btnArtigos.Location = new System.Drawing.Point(20, 110);
            this.btnArtigos.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnArtigos.Name = "btnArtigos";
            this.btnArtigos.Size = new System.Drawing.Size(94, 25);
            this.btnArtigos.TabIndex = 5;
            this.btnArtigos.Text = "Artigos";
            this.btnArtigos.UseVisualStyleBackColor = true;
            this.btnArtigos.Click += new System.EventHandler(this.btnArtigos_Click_1);
            // 
            // btnOrcamentos
            // 
            this.btnOrcamentos.Location = new System.Drawing.Point(20, 140);
            this.btnOrcamentos.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnOrcamentos.Name = "btnOrcamentos";
            this.btnOrcamentos.Size = new System.Drawing.Size(94, 25);
            this.btnOrcamentos.TabIndex = 6;
            this.btnOrcamentos.Text = "Orçamentos";
            this.btnOrcamentos.UseVisualStyleBackColor = true;
            this.btnOrcamentos.Click += new System.EventHandler(this.btnOrcamentos_Click_1);
            // 
            // btnCompras
            // 
            this.btnCompras.Location = new System.Drawing.Point(20, 171);
            this.btnCompras.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnCompras.Name = "btnCompras";
            this.btnCompras.Size = new System.Drawing.Size(94, 35);
            this.btnCompras.TabIndex = 7;
            this.btnCompras.Text = "Compras";
            this.btnCompras.UseVisualStyleBackColor = true;
            this.btnCompras.Click += new System.EventHandler(this.btnCompras_Click_1);
            // 
            // btnEstatisticas
            // 
            this.btnEstatisticas.Location = new System.Drawing.Point(20, 211);
            this.btnEstatisticas.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnEstatisticas.Name = "btnEstatisticas";
            this.btnEstatisticas.Size = new System.Drawing.Size(94, 25);
            this.btnEstatisticas.TabIndex = 8;
            this.btnEstatisticas.Text = "Estatísticas";
            this.btnEstatisticas.UseVisualStyleBackColor = true;
            this.btnEstatisticas.Click += new System.EventHandler(this.btnEstatisticas_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(159, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
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
            this.dgvComprasAbertas.Location = new System.Drawing.Point(161, 77);
            this.dgvComprasAbertas.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgvComprasAbertas.Name = "dgvComprasAbertas";
            this.dgvComprasAbertas.RowHeadersWidth = 51;
            this.dgvComprasAbertas.RowTemplate.Height = 24;
            this.dgvComprasAbertas.Size = new System.Drawing.Size(321, 159);
            this.dgvComprasAbertas.TabIndex = 11;
            this.dgvComprasAbertas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvComprasAbertas_CellContentClick);
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
            this.btnIniciarCompra.Location = new System.Drawing.Point(161, 253);
            this.btnIniciarCompra.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnIniciarCompra.Name = "btnIniciarCompra";
            this.btnIniciarCompra.Size = new System.Drawing.Size(171, 24);
            this.btnIniciarCompra.TabIndex = 12;
            this.btnIniciarCompra.Text = "Iniciar Compra";
            this.btnIniciarCompra.UseVisualStyleBackColor = true;
            this.btnIniciarCompra.Click += new System.EventHandler(this.btnIniciarCompra_Click_1);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
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
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
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