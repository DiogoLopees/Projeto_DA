using ProjetoDA.Data;
using ProjetoDA.Helpers;
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
    public partial class FormCompras : Form
    {
        // Guarda o ID da compra atualmente selecionada
        private int idSelecionado = -1;

        public FormCompras()
        {
            InitializeComponent();
        }

        // Evento executado quando o formulário é carregado
        private void FormCompras_Load(object sender, EventArgs e)
        {
            // Configura a DataGridView
            ConfigurarGrid();

            // Carrega as compras existentes na base de dados
            CarregarCompras();
        }

        // =====================================================
        // CONFIGURAÇÃO DA GRID
        // =====================================================
        private void ConfigurarGrid()
        {
            // Desativa a criação automática de colunas
            dgvCompras.AutoGenerateColumns = false;

            // Remove todas as colunas existentes
            dgvCompras.Columns.Clear();

            // Esconde a coluna de cabeçalho das linhas
            dgvCompras.RowHeadersVisible = false;

            // Permite selecionar a linha inteira
            dgvCompras.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            // Permite apenas uma seleção de cada vez
            dgvCompras.MultiSelect = false;

            // Impede o utilizador de adicionar linhas manualmente
            dgvCompras.AllowUserToAddRows = false;

            // Torna a grelha apenas de leitura
            dgvCompras.ReadOnly = true;

            // Ajusta automaticamente a largura das colunas
            dgvCompras.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            // Coluna oculta que guarda o ID da compra
            dgvCompras.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Id",
                DataPropertyName = "Id",
                Visible = false
            });

            // Coluna que apresenta o nome da compra
            dgvCompras.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "NomeCompra",
                HeaderText = "Nome",
                DataPropertyName = "NomeCompra"
            });

            // Coluna que apresenta a data de criação
            dgvCompras.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "DataCriacao",
                HeaderText = "Data",
                DataPropertyName = "DataCriacao"
            });

            // Coluna que apresenta o estado da compra
            dgvCompras.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Estado",
                HeaderText = "Estado",
                DataPropertyName = "Estado"
            });
        }

        // =====================================================
        // CARREGAR COMPRAS
        // =====================================================
        private void CarregarCompras()
        {
            try
            {
                // Cria ligação à base de dados
                using (AppDbContext db = new AppDbContext())
                {
                    // Obtém todas as compras e prepara os dados para a grelha
                    dgvCompras.DataSource = db.Compras
                        .ToList()
                        .Select(c => new
                        {
                            c.Id,

                            c.NomeCompra,

                            // Formata a data para dia/mês/ano
                            DataCriacao =
                                c.DataCriacao.ToString("dd/MM/yyyy"),

                            // Converte o valor booleano para texto
                            Estado =
                                c.Fechada
                                    ? "Fechada"
                                    : "Aberta"
                        })
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
        // CRIAR NOVA COMPRA
        // =====================================================
        private void btnNovo_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica se o nome foi preenchido
                if (string.IsNullOrWhiteSpace(
                    txtNomeCompra.Text))
                {
                    MessageBox.Show(
                        "Preenche o nome da compra.");

                    return;
                }

                using (AppDbContext db = new AppDbContext())
                {
                    // Cria um novo objeto Compra
                    Compras compra = new Compras()
                    {
                        NomeCompra =
                            txtNomeCompra.Text.Trim(),

                        // Define a data atual
                        DataCriacao =
                            DateTime.Now,

                        // A compra começa aberta
                        Fechada = false,

                        // Guarda o utilizador que criou a compra
                        CriadoPorId =
                            Sessao.UtilizadorId
                    };

                    // Adiciona a compra à base de dados
                    db.Compras.Add(compra);

                    // Guarda as alterações
                    db.SaveChanges();
                }

                // Limpa a caixa de texto
                txtNomeCompra.Clear();

                // Atualiza a grelha
                CarregarCompras();

                MessageBox.Show("Compra criada.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // =====================================================
        // ELIMINAR COMPRA
        // =====================================================
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica se existe uma linha selecionada
                if (dgvCompras.CurrentRow == null)
                {
                    MessageBox.Show(
                        "Seleciona uma compra.");

                    return;
                }

                // Obtém o ID da compra selecionada
                int id = Convert.ToInt32(
                    dgvCompras.CurrentRow.Cells["Id"].Value);

                using (AppDbContext db = new AppDbContext())
                {
                    // Procura a compra na base de dados
                    Compras compra =
                        db.Compras.Find(id);

                    if (compra == null)
                        return;

                    // Não permite eliminar compras fechadas
                    if (compra.Fechada)
                    {
                        MessageBox.Show(
                            "Não podes eliminar compras fechadas.");

                        return;
                    }

                    // Remove a compra
                    db.Compras.Remove(compra);

                    // Guarda as alterações
                    db.SaveChanges();
                }

                // Atualiza a grelha
                CarregarCompras();

                MessageBox.Show("Compra eliminada.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // =====================================================
        // SELECIONAR COMPRA NA GRID
        // =====================================================
        private void dgvCompras_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignora cliques no cabeçalho
            if (e.RowIndex < 0) return;

            // Guarda o ID da compra selecionada
            idSelecionado = Convert.ToInt32(
                dgvCompras.Rows[e.RowIndex].Cells["Id"].Value);

            // Mostra o nome da compra na textbox
            txtNomeCompra.Text =
                dgvCompras.Rows[e.RowIndex].Cells["NomeCompra"].Value.ToString();
        }

        // =====================================================
        // ABRIR MODO COMPRA
        // =====================================================
        private void btnAbrirCompra_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica se existe uma compra selecionada
                if (dgvCompras.CurrentRow == null)
                {
                    MessageBox.Show(
                        "Seleciona uma compra.");

                    return;
                }

                // Obtém o ID da compra selecionada
                int compraId = Convert.ToInt32(
                    dgvCompras.CurrentRow.Cells["Id"].Value);

                // Abre o formulário de detalhes da compra
                FormModoCompra frm =
                    new FormModoCompra(compraId);

                frm.ShowDialog();

                // Atualiza a lista após fechar o formulário
                CarregarCompras();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // =====================================================
        // EDITAR COMPRA
        // =====================================================
        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica se existe uma compra selecionada
                if (idSelecionado == -1)
                {
                    MessageBox.Show("Seleciona uma compra.");
                    return;
                }

                using (AppDbContext db = new AppDbContext())
                {
                    // Procura a compra na base de dados
                    var compra = db.Compras.Find(idSelecionado);

                    if (compra == null) return;

                    // Não permite editar compras fechadas
                    if (compra.Fechada)
                    {
                        MessageBox.Show("Não podes editar compras fechadas.");
                        return;
                    }

                    // Atualiza o nome da compra
                    compra.NomeCompra = txtNomeCompra.Text.Trim();

                    // Guarda as alterações
                    db.SaveChanges();
                }

                // Limpa os campos após edição
                txtNomeCompra.Clear();
                idSelecionado = -1;

                // Atualiza a grelha
                CarregarCompras();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}