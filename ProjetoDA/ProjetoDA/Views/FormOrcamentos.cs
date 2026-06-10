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
    // Formulário responsável pela gestão de orçamentos
    public partial class FormOrcamentos : Form
    {
        // Guarda o ID do orçamento selecionado na grid (-1 = nenhum)
        private int idSelecionado = -1;

        // Construtor do formulário
        public FormOrcamentos()
        {
            InitializeComponent();
        }

        // Evento de carregamento do formulário
        private void FormOrcamentos_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();     // configura a tabela
            CarregarOrcamentos(); // carrega dados da BD
        }

        // =====================================================
        // CONFIGURAÇÃO DA GRID
        // =====================================================
        private void ConfigurarGrid()
        {
            dgvOrcamentos.AutoGenerateColumns = false;
            dgvOrcamentos.Columns.Clear();
            dgvOrcamentos.RowHeadersVisible = false;

            dgvOrcamentos.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvOrcamentos.MultiSelect = false;

            dgvOrcamentos.ReadOnly = true;

            dgvOrcamentos.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            // Coluna ID (oculta)
            dgvOrcamentos.Columns.Add(
                new DataGridViewTextBoxColumn()
                {
                    Name = "Id",
                    DataPropertyName = "Id",
                    Visible = false
                });

            // Coluna Mês/Ano
            dgvOrcamentos.Columns.Add(
                new DataGridViewTextBoxColumn()
                {
                    Name = "Mes",
                    HeaderText = "Mês",
                    DataPropertyName = "Mes"
                });

            // Coluna Valor do orçamento
            dgvOrcamentos.Columns.Add(
                new DataGridViewTextBoxColumn()
                {
                    Name = "Valor",
                    HeaderText = "Valor",
                    DataPropertyName = "Valor"
                });
        }

        // =====================================================
        // CARREGAR ORÇAMENTOS
        // =====================================================
        private void CarregarOrcamentos()
        {
            try
            {
                using (AppDbContext db = new AppDbContext())
                {
                    // Vai buscar todos os orçamentos e projeta para a grid
                    dgvOrcamentos.DataSource =
                        db.Orcamentos
                        .ToList()
                        .Select(o => new
                        {
                            o.Id,

                            // Formata mês/ano
                            Mes =
                                o.MesReferencia.Month +
                                "/" +
                                o.MesReferencia.Year,

                            // Valor máximo definido
                            Valor =
                                o.ValorMaximo
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

        // =====================================================
        // ELIMINAR ORÇAMENTO
        // =====================================================
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica se há linha selecionada
                if (dgvOrcamentos.CurrentRow == null)
                {
                    MessageBox.Show("Seleciona um orçamento.");
                    return;
                }

                // Obtém ID selecionado
                int id = Convert.ToInt32(
                    dgvOrcamentos.CurrentRow.Cells["Id"].Value);

                using (AppDbContext db = new AppDbContext())
                {
                    // Procura orçamento na BD
                    Orcamento orcamento =
                        db.Orcamentos.Find(id);

                    // Remove se existir
                    if (orcamento != null)
                    {
                        db.Orcamentos.Remove(orcamento);
                        db.SaveChanges();
                    }
                }

                // Atualiza grid
                CarregarOrcamentos();

                MessageBox.Show("Orçamento eliminado.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Evento (não utilizado)
        private void nudValor_ValueChanged(object sender, EventArgs e)
        {

        }

        // Evento (não utilizado)
        private void cboMes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // Evento (não utilizado)
        private void nudAno_ValueChanged(object sender, EventArgs e)
        {

        }

        // =====================================================
        // SELEÇÃO NA GRID
        // =====================================================
        private void dgvOrcamentos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Guarda ID selecionado
            idSelecionado = Convert.ToInt32(
                dgvOrcamentos.Rows[e.RowIndex].Cells["Id"].Value);

            // Preenche valor no NumericUpDown
            nudValor.Value = Convert.ToDecimal(
                dgvOrcamentos.Rows[e.RowIndex].Cells["Valor"].Value);
        }

        // =====================================================
        // ADICIONAR ORÇAMENTO
        // =====================================================
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                // Valor do orçamento
                decimal valor = nudValor.Value;

                // Data de referência selecionada
                DateTime data =
                    dtMesReferencia.Value;

                using (AppDbContext db =
                    new AppDbContext())
                {
                    // Verifica se já existe orçamento para o mesmo mês/ano
                    bool existe =
                        db.Orcamentos.Any(o =>
                            o.MesReferencia.Month ==
                            data.Month &&

                            o.MesReferencia.Year ==
                            data.Year);

                    if (existe)
                    {
                        MessageBox.Show(
                            "Já existe orçamento para este mês.");

                        return;
                    }

                    // Criação de novo orçamento
                    Orcamento orcamento =
                        new Orcamento()
                        {
                            ValorMaximo = valor,

                            MesReferencia =
                                data,

                            CriadoPorId =
                                Sessao.UtilizadorId,

                            DataCriacao =
                                DateTime.Now
                        };

                    // Adiciona à base de dados
                    db.Orcamentos.Add(orcamento);

                    db.SaveChanges();
                }

                // Atualiza grid
                CarregarOrcamentos();

                MessageBox.Show(
                    "Orçamento criado.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // =====================================================
        // EDITAR ORÇAMENTO
        // =====================================================
        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idSelecionado == -1)
                {
                    MessageBox.Show("Seleciona um orçamento.");
                    return;
                }

                using (AppDbContext db = new AppDbContext())
                {
                    // Procura orçamento na base de dados
                    var orc = db.Orcamentos.Find(idSelecionado);

                    if (orc == null) return;

                    // Atualiza valor máximo
                    orc.ValorMaximo = nudValor.Value;

                    db.SaveChanges();
                }

                // Atualiza grid e limpa seleção
                CarregarOrcamentos();
                idSelecionado = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}