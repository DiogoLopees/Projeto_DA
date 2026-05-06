using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetoDA.Data;
using ProjetoDA.Helpers;

namespace ProjetoDA.Views
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        public void FormPrincipal_Load(object sender, EventArgs e)
        {
            lblUtilizador.Text = "Utilizador: " + Sessao.UtilizadorNome;
            CarregarComprasAbertas();
        }
        public void CarregarComprasAbertas()
        {
            using (var db = new AppDbContext())
            {
                var compras = db.Compras
                    .Where(c => !c.Fechada)
                    .Select(c => new
                    {
                        c.Id,
                        c.Nome,
                        DataCriacao = c.DataCriacao.ToString(),
                        TotalItens = c.Itens.Count()
                    })
                    .ToList();

                dgvComprasAbertas.DataSource = compras;

                // Esconde a coluna Id (não precisa de aparecer)
                if (dgvComprasAbertas.Columns["Id"] != null)
                    dgvComprasAbertas.Columns["Id"].Visible = false;

                // Nomes das colunas em português
                if (dgvComprasAbertas.Columns["Nome"] != null)
                    dgvComprasAbertas.Columns["Nome"].HeaderText = "Nome";
                if (dgvComprasAbertas.Columns["DataCriacao"] != null)
                    dgvComprasAbertas.Columns["DataCriacao"].HeaderText = "Data de Criação";
                if (dgvComprasAbertas.Columns["TotalItens"] != null)
                    dgvComprasAbertas.Columns["TotalItens"].HeaderText = "Nº de Itens";

                dgvComprasAbertas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvComprasAbertas.ReadOnly = true;
                dgvComprasAbertas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
        }
        // ── Botões do Menu ──────────────────────────────

        private void btnUtilizadores_Click(object sender, EventArgs e)
        {
            new FormUtilizadores().ShowDialog();
        }

        private void btnTiposArtigo_Click(object sender, EventArgs e)
        {
            new FormTiposArtigo().ShowDialog();
        }

        private void btnArtigos_Click(object sender, EventArgs e)
        {
            new FormArtigos().ShowDialog();
        }

        private void btnOrcamentos_Click(object sender, EventArgs e)
        {
            new FormOrcamentos().ShowDialog();
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            new FormCompras().ShowDialog();
            CarregarComprasAbertas(); // Atualiza lista ao voltar
        }

        private void btnEstatisticas_Click(object sender, EventArgs e)
        {
            new FormEstatisticas().ShowDialog();
        }

        // ── Iniciar Compra ──────────────────────────────

        private void btnIniciarCompra_Click(object sender, EventArgs e)
        {
            if (dgvComprasAbertas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleciona uma compra em aberto para iniciar.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int compraId = (int)dgvComprasAbertas.SelectedRows[0].Cells["Id"].Value;
            new FormModoCompra(compraId).ShowDialog();
            CarregarComprasAbertas(); // Atualiza após a compra
        }

        // ── Sair ────────────────────────────────────────

        private void btnSair_Click(object sender, EventArgs e)
        {
            Sessao.UtilizadorId = 0;
            Sessao.UtilizadorNome = string.Empty;

            new FormLogin().Show();
            this.Close();
        }

        // Atualiza a lista quando o formulário volta a estar em foco
        private void FormPrincipal_Activated(object sender, EventArgs e)
        {
            CarregarComprasAbertas();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnUtilizadores_Click_1(object sender, EventArgs e)
        {

        }
    }
}
