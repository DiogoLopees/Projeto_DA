using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetoDA.Controlers;


namespace ProjetoDA.Views
{
    public partial class FormTipoArtigo : Form
    {
        private TipoArtigoController controller = new TipoArtigoController();
        private int idSelecionado = -1; // -1 significa que nenhum está selecionado
        public FormTipoArtigo()
        {
            InitializeComponent();
        }

        private void FormTipoArtigo_Load(object sender, EventArgs e)
        {
            CarregarTabela();
            ModoNovo();
        }
        // ── Carregar tabela ──────────────────────────────

        private void CarregarTabela()
        {
            dgvTipos.DataSource = controller.GetTodos();
            dgvTipos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTipos.ReadOnly = true;
            dgvTipos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (dgvTipos.Columns["Artigos"] != null)
                dgvTipos.Columns["Artigos"].Visible = false;
        }

        // ── Modos do formulário ──────────────────────────

        private void ModoNovo()
        {
            idSelecionado = -1;
            txtNome.Clear();
            txtNome.Focus();
            btnEliminar.Enabled = false;
        }

        private void ModoEdicao(int id, string nome)
        {
            idSelecionado = id;
            txtNome.Text = nome;
            btnEliminar.Enabled = true;
        }

        // ── Eventos dos botões ───────────────────────────

        private void btnNovo_Click(object sender, EventArgs e)
        {
            ModoNovo();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text.Trim();

            if (string.IsNullOrEmpty(nome))
            {
                MessageBox.Show("O nome não pode estar vazio.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool sucesso;

            if (idSelecionado == -1)
            {
                // Inserir novo
                sucesso = controller.Inserir(nome);
                if (!sucesso)
                {
                    MessageBox.Show("Já existe um tipo com esse nome.", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Tipo de artigo criado com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Atualizar existente
                sucesso = controller.Atualizar(idSelecionado, nome);
                if (!sucesso)
                {
                    MessageBox.Show("Erro ao atualizar.", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Tipo de artigo atualizado com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            CarregarTabela();
            ModoNovo();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSelecionado == -1) return;

            var confirmacao = MessageBox.Show(
                "Tens a certeza que queres eliminar este tipo de artigo?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacao != DialogResult.Yes) return;

            bool sucesso = controller.Eliminar(idSelecionado);

            if (!sucesso)
            {
                MessageBox.Show("Não é possível eliminar — existem artigos associados a este tipo.",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Eliminado com sucesso!", "Sucesso",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            CarregarTabela();
            ModoNovo();
        }

        // ── Clique na tabela ─────────────────────────────

        private void dgvTipos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = (int)dgvTipos.Rows[e.RowIndex].Cells["Id"].Value;
            string nome = dgvTipos.Rows[e.RowIndex].Cells["Nome"].Value.ToString();

            ModoEdicao(id, nome);
        }

        private void dgvTipos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvTipos_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
                
        }
    }
}
