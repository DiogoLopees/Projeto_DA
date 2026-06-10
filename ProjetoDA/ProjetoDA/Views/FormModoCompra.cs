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
using System.Data.Entity;

namespace ProjetoDA.Views
{
    public partial class FormModoCompra : Form
    {
        // Guarda o ID da compra que está a ser gerida
        private int compraId;

        // Construtor que recebe o ID da compra
        public FormModoCompra(int id)
        {
            InitializeComponent();
            compraId = id;
        }

        // =====================================================
        // CARREGAMENTO DO FORMULÁRIO
        // =====================================================
        private void FormModoCompra_Load(object sender, EventArgs e)
        {
            // Configura a DataGridView
            ConfigurarGrid();

            // Carrega os tipos de artigos
            CarregarTipos();

            // Seleciona automaticamente o primeiro tipo
            if (cbTipos.Items.Count > 0)
            {
                cbTipos.SelectedIndex = 0;
            }

            // Carrega os itens da compra
            CarregarItens();

            // Atualiza a informação do orçamento
            AtualizarOrcamento();
        }

        // =====================================================
        // CONFIGURAÇÃO DA GRID
        // =====================================================
        private void ConfigurarGrid()
        {
            // Desativa a geração automática de colunas
            dgvItens.AutoGenerateColumns = false;

            // Remove colunas existentes
            dgvItens.Columns.Clear();

            // Oculta os cabeçalhos das linhas
            dgvItens.RowHeadersVisible = false;

            // Permite selecionar linhas completas
            dgvItens.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            // Apenas uma linha pode ser selecionada
            dgvItens.MultiSelect = false;

            // Impede adicionar linhas manualmente
            dgvItens.AllowUserToAddRows = false;

            // Apenas leitura
            dgvItens.ReadOnly = true;

            // Ajusta automaticamente a largura das colunas
            dgvItens.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            // Define a cor de fundo da grelha
            dgvItens.BackgroundColor = Color.White;

            // Coluna oculta para guardar o ID
            dgvItens.Columns.Add(
                new DataGridViewTextBoxColumn()
                {
                    Name = "Id",
                    DataPropertyName = "Id",
                    Visible = false
                });

            // Coluna do artigo
            dgvItens.Columns.Add(
                new DataGridViewTextBoxColumn()
                {
                    Name = "Artigo",
                    HeaderText = "Artigo",
                    DataPropertyName = "Artigo"
                });

            // Coluna da quantidade
            dgvItens.Columns.Add(
                new DataGridViewTextBoxColumn()
                {
                    Name = "Quantidade",
                    HeaderText = "Quantidade",
                    DataPropertyName = "Quantidade"
                });

            // Coluna do preço
            dgvItens.Columns.Add(
                new DataGridViewTextBoxColumn()
                {
                    Name = "Preco",
                    HeaderText = "Preço",
                    DataPropertyName = "Preco"
                });

            // Coluna que indica se o item era previsto
            dgvItens.Columns.Add(
                new DataGridViewTextBoxColumn()
                {
                    Name = "Previsto",
                    HeaderText = "Previsto",
                    DataPropertyName = "Previsto"
                });
        }

        // =====================================================
        // CARREGAR TIPOS DE ARTIGO
        // =====================================================
        private void CarregarTipos()
        {
            try
            {
                using (AppDbContext db =
                    new AppDbContext())
                {
                    // Carrega todos os tipos de artigo ordenados por nome
                    cbTipos.DataSource =
                        db.TiposArtigo
                        .OrderBy(t => t.Nome)
                        .ToList();

                    // Campo apresentado ao utilizador
                    cbTipos.DisplayMember = "Nome";

                    // Valor interno do ComboBox
                    cbTipos.ValueMember = "Id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // =====================================================
        // CARREGAR ITENS DA COMPRA
        // =====================================================
        private void CarregarItens()
        {
            try
            {
                using (AppDbContext db =
                    new AppDbContext())
                {
                    // Carrega todos os itens associados à compra
                    dgvItens.DataSource =
                        db.ItensCompra
                        .Include(i => i.Artigo)
                        .Where(i =>
                            i.CompraId == compraId)
                        .Select(i => new
                        {
                            i.Id,

                            Artigo =
                                i.Artigo.Nome,

                            Quantidade =
                                i.QuantidadeComprada,

                            Preco =
                                i.PrecoUnitario,

                            Previsto =
                                i.Previsto
                                    ? "Sim"
                                    : "Não"
                        })
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // =====================================================
        // ADICIONAR ITEM À COMPRA
        // =====================================================
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica se existe um artigo selecionado
                if (cbArtigos.SelectedValue == null)
                {
                    MessageBox.Show(
                        "Seleciona um artigo.");

                    return;
                }

                // Valida a quantidade
                if (nudQuantidade.Value <= 0)
                {
                    MessageBox.Show(
                        "Quantidade inválida.");

                    return;
                }

                // Valida o preço
                if (nudPreco.Value <= 0)
                {
                    MessageBox.Show(
                        "Preço inválido.");

                    return;
                }

                using (AppDbContext db =
                    new AppDbContext())
                {
                    // Cria um novo item de compra
                    ItemCompra item =
                        new ItemCompra()
                        {
                            CompraId = compraId,

                            ArtigoId =
                                Convert.ToInt32(
                                    cbArtigos.SelectedValue),

                            QuantidadeComprada =
                                Convert.ToInt32(
                                    nudQuantidade.Value),

                            QuantidadePrevista =
                                Convert.ToInt32(
                                    nudQuantidade.Value),

                            PrecoUnitario =
                                nudPreco.Value,

                            Comprado = true,

                            Previsto =
                                chkPrevisto.Checked,

                            Observacoes =
                                txtObservacoes.Text.Trim()
                        };

                    // Adiciona o item à base de dados
                    db.ItensCompra.Add(item);

                    // Guarda as alterações
                    db.SaveChanges();
                }

                // Limpa os campos após a inserção
                txtObservacoes.Clear();

                nudQuantidade.Value = 1;

                nudPreco.Value = 1;

                // Atualiza a lista de itens
                CarregarItens();

                // Atualiza o orçamento
                AtualizarOrcamento();

                MessageBox.Show(
                    "Item adicionado.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // =====================================================
        // ELIMINAR ITEM
        // =====================================================
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica se existe um item selecionado
                if (dgvItens.CurrentRow == null)
                {
                    MessageBox.Show(
                        "Seleciona um item.");

                    return;
                }

                // Obtém o ID do item selecionado
                int id = Convert.ToInt32(
                    dgvItens.CurrentRow.Cells["Id"].Value);

                using (AppDbContext db =
                    new AppDbContext())
                {
                    // Procura o item na base de dados
                    ItemCompra item =
                        db.ItensCompra.Find(id);

                    if (item != null)
                    {
                        // Remove o item
                        db.ItensCompra.Remove(item);

                        db.SaveChanges();
                    }
                }

                // Atualiza os dados apresentados
                CarregarItens();

                AtualizarOrcamento();

                MessageBox.Show(
                    "Item removido.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // =====================================================
        // ATUALIZAR ORÇAMENTO
        // =====================================================
        private void AtualizarOrcamento()
        {
            try
            {
                using (AppDbContext db =
                    new AppDbContext())
                {
                    DateTime hoje = DateTime.Now;

                    // Calcula o valor total gasto no mês atual
                    decimal total =
                        db.ItensCompra
                        .Where(i =>
                            i.Comprado &&
                            i.Compra.DataCriacao.Month == hoje.Month &&
                            i.Compra.DataCriacao.Year == hoje.Year)
                        .Sum(i =>
                            (decimal?)
                            i.PrecoUnitario *
                            i.QuantidadeComprada)
                        ?? 0;

                    // Procura o orçamento do mês atual
                    var orcamento =
                        db.Orcamentos
                        .FirstOrDefault(o =>
                            o.MesReferencia.Month == hoje.Month &&
                            o.MesReferencia.Year == hoje.Year);

                    // Caso não exista orçamento definido
                    if (orcamento == null)
                    {
                        lblOrcamento.Text =
                            "Orçamento Total: Não definido";

                        lblOrcamentoDisponivel.Text =
                            "Disponível: Não definido";

                        return;
                    }

                    // Calcula o valor restante
                    decimal restante =
                    orcamento.ValorMaximo - total;

                    // Mostra o orçamento total
                    lblOrcamento.Text =
                        $"Orçamento Total: {orcamento.ValorMaximo:C}";

                    // Mostra o valor ainda disponível
                    lblOrcamentoDisponivel.Text =
                        $"Disponível: {restante:C}";

                    // Caso o orçamento tenha sido ultrapassado
                    if (restante < 0)
                    {
                        lblOrcamentoDisponivel.ForeColor =
                            Color.Red;

                        MessageBox.Show(
                            "ORÇAMENTO ULTRAPASSADO!",
                            "ALERTA",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                    else
                    {
                        lblOrcamentoDisponivel.ForeColor =
                            Color.DarkGreen;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // =====================================================
        // FECHAR COMPRA
        // =====================================================
        private void btnFecharCompra_Click(object sender, EventArgs e)
        {
            try
            {
                using (AppDbContext db =
                    new AppDbContext())
                {
                    // Procura a compra atual
                    Compras compra =
                        db.Compras.Find(compraId);

                    if (compra == null)
                        return;

                    // Verifica se já está fechada
                    if (compra.Fechada)
                    {
                        MessageBox.Show(
                            "Esta compra já está fechada.");

                        return;
                    }

                    // Marca a compra como fechada
                    compra.Fechada = true;

                    // Guarda a data de fecho
                    compra.DataFecho =
                        DateTime.Now;

                    db.SaveChanges();
                }

                MessageBox.Show(
                    "Compra fechada com sucesso.");

                // Fecha o formulário
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Evento da grelha (sem implementação)
        private void dgvItens_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // =====================================================
        // FILTRAR ARTIGOS PELO TIPO SELECIONADO
        // =====================================================
        private void cbTipos_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                // Verifica se existe um tipo selecionado
                if (cbTipos.SelectedValue == null)
                    return;

                int tipoId;

                // Converte o valor selecionado para inteiro
                if (!int.TryParse(
                    cbTipos.SelectedValue.ToString(),
                    out tipoId))
                    return;

                using (AppDbContext db =
                    new AppDbContext())
                {
                    // Obtém apenas os artigos do tipo selecionado
                    var artigos = db.Artigos
                        .Where(a => a.TipoArtigoId == tipoId)
                        .OrderBy(a => a.Nome)
                        .ToList();

                    // Carrega os artigos no ComboBox
                    cbArtigos.DataSource = artigos;

                    cbArtigos.DisplayMember = "Nome";

                    cbArtigos.ValueMember = "Id";
                }
            }
            catch
            {
                // Ignora eventuais erros
            }
        }
    }
}