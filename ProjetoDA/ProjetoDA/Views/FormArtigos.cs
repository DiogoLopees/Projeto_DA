using ProjetoDA.Controlers;
using ProjetoDA.Data;
using ProjetoDA.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoDA.Views
{
    // Formulário responsável pela gestão de Artigos
    public partial class FormArtigos : Form
    {
        // Controller responsável pelas operações de TipoArtigo
        private TipoArtigoController controller = new TipoArtigoController();

        // Guarda o ID do artigo selecionado (-1 = nenhum selecionado)
        private int idSelecionado = -1;

        // Construtor do formulário
        public FormArtigos()
        {
            InitializeComponent();
        }

        // Evento de carregamento do formulário
        private void FormArtigos_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();   // configura tabela
            CarregarTipos();    // carrega tipos no combobox
            CarregarArtigos();  // carrega artigos na grid
        }

        // =====================================================
        // CONFIGURAR GRID
        // =====================================================
        private void ConfigurarGrid()
        {
            // Desativa geração automática de colunas
            dgvArtigos.AutoGenerateColumns = false;

            // Limpa colunas existentes
            dgvArtigos.Columns.Clear();

            // Esconde cabeçalho de linhas
            dgvArtigos.RowHeadersVisible = false;

            // Seleção de linha inteira
            dgvArtigos.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            // Permite apenas uma linha selecionada
            dgvArtigos.MultiSelect = false;

            // Não permite adicionar linhas diretamente na grid
            dgvArtigos.AllowUserToAddRows = false;

            // Grid apenas leitura (não editável)
            dgvArtigos.ReadOnly = true;

            // Ajusta colunas automaticamente
            dgvArtigos.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            // Coluna Id (oculta)
            dgvArtigos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Id",
                HeaderText = "Id",
                DataPropertyName = "Id",
                Visible = false
            });

            // Coluna Nome do artigo
            dgvArtigos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Nome",
                HeaderText = "Artigo",
                DataPropertyName = "Nome"
            });

            // Coluna Tipo de artigo
            dgvArtigos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Tipo",
                HeaderText = "Tipo",
                DataPropertyName = "Tipo"
            });
        }

        // =====================================================
        // CARREGAR TIPOS DE ARTIGO
        // =====================================================
        private void CarregarTipos()
        {
            using (AppDbContext db = new AppDbContext())
            {
                // Carrega tipos ordenados alfabeticamente
                cbTipos.DataSource = db.TiposArtigo
                    .OrderBy(t => t.Nome)
                    .ToList();

                // Texto mostrado no comboBox
                cbTipos.DisplayMember = "Nome";

                // Valor interno (ID)
                cbTipos.ValueMember = "Id";
            }
        }

        // =====================================================
        // CARREGAR ARTIGOS
        // =====================================================
        private void CarregarArtigos()
        {
            try
            {
                using (AppDbContext db = new AppDbContext())
                {
                    // Lista artigos com o nome do tipo associado
                    dgvArtigos.DataSource = db.Artigos
                        .Include(a => a.TipoArtigo)
                        .Select(a => new
                        {
                            a.Id,
                            a.Nome,
                            Tipo = a.TipoArtigo.Nome
                        })
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                // Mostra erro caso algo falhe
                MessageBox.Show(ex.Message);
            }
        }

        // Método alternativo de carregamento (sem Include)
        private void CarregarTabela()
        {
            using (var db = new AppDbContext())
            {
                dgvArtigos.DataSource = db.Artigos.Select(a => new
                {
                    a.Id,
                    a.Nome,
                    Tipo = a.TipoArtigo.Nome
                }).ToList();
            }
        }

        // =====================================================
        // GRAVAR (INSERIR OU ATUALIZAR)
        // =====================================================
        private void btnGravar_Click(object sender, EventArgs e)
        {
            int tipoId = (int)cbTipos.SelectedValue;

            // Se não há artigo selecionado, insere
            if (idSelecionado == -1)
                controller.Inserir(txtNome.Text, tipoId);
            else
                controller.Atualizar(idSelecionado, txtNome.Text, tipoId);

            CarregarTabela();
        }

        // =====================================================
        // ELIMINAR ARTIGO
        // =====================================================
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica se existe linha selecionada
                if (dgvArtigos.CurrentRow == null)
                {
                    MessageBox.Show("Seleciona um artigo.");
                    return;
                }

                // Obtém ID do artigo selecionado
                int id = Convert.ToInt32(
                    dgvArtigos.CurrentRow.Cells["Id"].Value);

                using (AppDbContext db = new AppDbContext())
                {
                    // Procura artigo na BD
                    Artigo artigo =
                        db.Artigos.Find(id);

                    // Remove se existir
                    if (artigo != null)
                    {
                        db.Artigos.Remove(artigo);
                        db.SaveChanges();
                    }
                }

                // Atualiza grid
                CarregarArtigos();

                MessageBox.Show("Artigo eliminado.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Não foi possível eliminar.\n\n" +
                    ex.Message);
            }
        }

        // =====================================================
        // SELEÇÃO NA GRID
        // =====================================================
        private void dgvArtigos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Guarda ID selecionado
            idSelecionado = Convert.ToInt32(
                dgvArtigos.Rows[e.RowIndex].Cells["Id"].Value);

            // Preenche textbox com nome do artigo
            txtNome.Text =
                dgvArtigos.Rows[e.RowIndex].Cells["Nome"].Value.ToString();
        }

        // =====================================================
        // ADICIONAR ARTIGO
        // =====================================================
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validação simples
                if (string.IsNullOrWhiteSpace(txtNome.Text))
                {
                    MessageBox.Show("Preenche o nome.");
                    return;
                }

                using (AppDbContext db = new AppDbContext())
                {
                    // Cria novo artigo
                    Artigo artigo = new Artigo()
                    {
                        Nome = txtNome.Text.Trim(),
                        TipoArtigoId =
                            (int)cbTipos.SelectedValue
                    };

                    // Adiciona à base de dados
                    db.Artigos.Add(artigo);
                    db.SaveChanges();
                }

                txtNome.Clear();

                CarregarArtigos();

                MessageBox.Show("Artigo adicionado.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // =====================================================
        // FILTRAR POR TIPO
        // =====================================================
        private void cbTipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbTipos.SelectedValue == null)
                    return;

                int tipoId =
                    Convert.ToInt32(cbTipos.SelectedValue);

                using (AppDbContext db = new AppDbContext())
                {
                    dgvArtigos.DataSource = db.Artigos
                        .Where(a => a.TipoArtigoId == tipoId)
                        .Select(a => new
                        {
                            a.Id,
                            a.Nome,
                            Tipo = a.TipoArtigo.Nome
                        })
                        .ToList();
                }
            }
            catch
            {
                // silencioso (evita crash)
            }
        }

        // =====================================================
        // MOSTRAR TODOS OS ARTIGOS
        // =====================================================
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            CarregarArtigos();
        }

        // =====================================================
        // EDITAR ARTIGO
        // =====================================================
        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idSelecionado == -1)
                {
                    MessageBox.Show("Seleciona um artigo.");
                    return;
                }

                int tipoId = (int)cbTipos.SelectedValue;

                controller.Atualizar(idSelecionado, txtNome.Text, tipoId);

                txtNome.Clear();
                idSelecionado = -1;

                CarregarArtigos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}