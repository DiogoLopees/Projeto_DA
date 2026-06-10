using ProjetoDA.Controlers;
using ProjetoDA.Data;
using ProjetoDA.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoDA.Views
{
    public partial class FormTipoArtigo : Form
    {
        // Instância do controlador de tipos de artigo
        private TipoArtigoController controller = new TipoArtigoController();

        // Guarda o ID do tipo selecionado (-1 significa nenhum selecionado)
        private int idSelecionado = -1;

        // Construtor do formulário
        public FormTipoArtigo()
        {
            InitializeComponent();
        }

        // =====================================================
        // CARREGAMENTO DO FORMULÁRIO
        // =====================================================
        private void FormTipoArtigo_Load(object sender, EventArgs e)
        {
            // Configura a DataGridView
            ConfigurarGrid();

            // Carrega os dados existentes
            CarregarDados();
        }

        // =====================================================
        // CONFIGURAÇÃO DA GRID
        // =====================================================
        private void ConfigurarGrid()
        {
            // Desativa a criação automática de colunas
            dgvTipos.AutoGenerateColumns = false;

            // Remove colunas existentes
            dgvTipos.Columns.Clear();

            // Oculta o cabeçalho das linhas
            dgvTipos.RowHeadersVisible = false;

            // Permite selecionar linhas completas
            dgvTipos.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            // Apenas uma linha pode ser selecionada
            dgvTipos.MultiSelect = false;

            // Grelha apenas para leitura
            dgvTipos.ReadOnly = true;

            // Ajusta automaticamente a largura das colunas
            dgvTipos.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            // Coluna oculta para guardar o ID
            dgvTipos.Columns.Add(
                new DataGridViewTextBoxColumn()
                {
                    Name = "Id",
                    DataPropertyName = "Id",
                    Visible = false
                });

            // Coluna do nome do tipo de artigo
            dgvTipos.Columns.Add(
                new DataGridViewTextBoxColumn()
                {
                    Name = "Nome",
                    HeaderText = "Nome",
                    DataPropertyName = "Nome"
                });
        }

        // =====================================================
        // CARREGAR DADOS
        // =====================================================
        private void CarregarDados()
        {
            try
            {
                using (AppDbContext db =
                    new AppDbContext())
                {
                    // Carrega todos os tipos de artigo ordenados por nome
                    dgvTipos.DataSource =
                        db.TiposArtigo
                        .OrderBy(t => t.Nome)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                // Mostra qualquer erro ocorrido
                MessageBox.Show(ex.Message);
            }
        }

        // =====================================================
        // EVENTO DE CLIQUE NA GRID
        // =====================================================
        private void dgvTipos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // =====================================================
        // SELECIONAR TIPO DE ARTIGO
        // =====================================================
        private void dgvTipos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignora cliques no cabeçalho
            if (e.RowIndex < 0) return;

            // Guarda o ID do tipo selecionado
            idSelecionado = Convert.ToInt32(
                dgvTipos.Rows[e.RowIndex].Cells["Id"].Value);

            // Mostra o nome na caixa de texto
            txtNome.Text =
                dgvTipos.Rows[e.RowIndex].Cells["Nome"].Value.ToString();
        }

        // Evento sem implementação
        private void dgvTipos_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        // =====================================================
        // ADICIONAR TIPO DE ARTIGO
        // =====================================================
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica se o nome foi preenchido
                if (string.IsNullOrWhiteSpace(
                    txtNome.Text))
                {
                    MessageBox.Show(
                        "Preenche o nome.");

                    return;
                }

                using (AppDbContext db =
                    new AppDbContext())
                {
                    // Cria um novo tipo de artigo
                    TipoArtigo tipo =
                        new TipoArtigo()
                        {
                            Nome =
                                txtNome.Text.Trim()
                        };

                    // Adiciona à base de dados
                    db.TiposArtigo.Add(tipo);

                    // Guarda as alterações
                    db.SaveChanges();
                }

                // Limpa a caixa de texto
                txtNome.Clear();

                // Atualiza a lista
                CarregarDados();

                MessageBox.Show(
                    "Tipo adicionado.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // =====================================================
        // ELIMINAR TIPO DE ARTIGO
        // =====================================================
        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Verifica se existe uma linha selecionada
                if (dgvTipos.CurrentRow == null)
                {
                    MessageBox.Show(
                        "Seleciona um tipo.");

                    return;
                }

                // Obtém o ID do tipo selecionado
                int id = Convert.ToInt32(
                    dgvTipos.CurrentRow.Cells["Id"].Value);

                using (AppDbContext db =
                    new AppDbContext())
                {
                    // Procura o tipo na base de dados
                    TipoArtigo tipo =
                        db.TiposArtigo.Find(id);

                    if (tipo != null)
                    {
                        // Remove o tipo
                        db.TiposArtigo.Remove(tipo);

                        // Guarda as alterações
                        db.SaveChanges();
                    }
                }

                // Atualiza a lista
                CarregarDados();

                MessageBox.Show(
                    "Tipo eliminado.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Não foi possível eliminar.\n\n" +
                    ex.Message);
            }
        }

        // =====================================================
        // EDITAR TIPO DE ARTIGO
        // =====================================================
        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica se existe um tipo selecionado
                if (idSelecionado == -1)
                {
                    MessageBox.Show("Seleciona um tipo.");
                    return;
                }

                using (AppDbContext db = new AppDbContext())
                {
                    // Procura o tipo na base de dados
                    var tipo = db.TiposArtigo.Find(idSelecionado);

                    if (tipo == null) return;

                    // Atualiza o nome do tipo
                    tipo.Nome = txtNome.Text.Trim();

                    // Guarda as alterações
                    db.SaveChanges();
                }

                // Limpa os campos
                txtNome.Clear();
                idSelecionado = -1;

                // Atualiza a lista
                CarregarDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}