namespace ProjetoDA.Views
{
    partial class FormOrcamentos
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
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dgvOrcamentos = new System.Windows.Forms.DataGridView();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.dtMesReferencia = new System.Windows.Forms.DateTimePicker();
            this.nudValor = new System.Windows.Forms.NumericUpDown();
            this.btnEditar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrcamentos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudValor)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(475, 253);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(159, 68);
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // dgvOrcamentos
            // 
            this.dgvOrcamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrcamentos.Location = new System.Drawing.Point(59, 234);
            this.dgvOrcamentos.Name = "dgvOrcamentos";
            this.dgvOrcamentos.RowHeadersWidth = 82;
            this.dgvOrcamentos.RowTemplate.Height = 33;
            this.dgvOrcamentos.Size = new System.Drawing.Size(321, 181);
            this.dgvOrcamentos.TabIndex = 6;
            this.dgvOrcamentos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrcamentos_CellContentClick);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(475, 105);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(159, 68);
            this.btnAdicionar.TabIndex = 7;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // dtMesReferencia
            // 
            this.dtMesReferencia.Location = new System.Drawing.Point(68, 105);
            this.dtMesReferencia.Name = "dtMesReferencia";
            this.dtMesReferencia.Size = new System.Drawing.Size(200, 31);
            this.dtMesReferencia.TabIndex = 8;
            // 
            // nudValor
            // 
            this.nudValor.Location = new System.Drawing.Point(59, 42);
            this.nudValor.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudValor.Name = "nudValor";
            this.nudValor.Size = new System.Drawing.Size(120, 31);
            this.nudValor.TabIndex = 0;
            this.nudValor.ValueChanged += new System.EventHandler(this.nudValor_ValueChanged);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(475, 179);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(159, 68);
            this.btnEditar.TabIndex = 9;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // FormOrcamentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.dtMesReferencia);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.dgvOrcamentos);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.nudValor);
            this.Name = "FormOrcamentos";
            this.Text = "FormOrcamentos";
            this.Load += new System.EventHandler(this.FormOrcamentos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrcamentos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudValor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dgvOrcamentos;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.DateTimePicker dtMesReferencia;
        private System.Windows.Forms.NumericUpDown nudValor;
        private System.Windows.Forms.Button btnEditar;
    }
}