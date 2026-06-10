using ProjetoDA.Data;
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
    // Formulário responsável por apresentar estatísticas do sistema
    public partial class FormEstatisticas : Form
    {
        // Construtor do formulário
        public FormEstatisticas()
        {
            InitializeComponent();
        }

        // Evento de carregamento do formulário
        private void FormEstatisticas_Load(object sender, EventArgs e)
        {
            CarregarResumoMensal();      // carrega resumo por mês
            CarregarPercentagens();      // carrega percentagens de previsão
            GerarSugestaoOrcamento();    // gera sugestão de orçamento
        }

        // =====================================================
        // RESUMO MENSAL
        // =====================================================
        private void CarregarResumoMensal()
        {
            try
            {
                using (AppDbContext db = new AppDbContext())
                {
                    // Cria um resumo por orçamento mensal
                    dgvResumo.DataSource = db.Orcamentos
                        .Select(o => new
                        {
                            // Formata mês/ano
                            Mes = o.MesReferencia.Month + "/" + o.MesReferencia.Year,

                            // Valor máximo definido no orçamento
                            Orcamento = o.ValorMaximo,

                            // Soma total das compras no mês correspondente
                            TotalCompras =
                                db.ItensCompra
                                .Where(i =>
                                    i.Compra.DataCriacao.Month == o.MesReferencia.Month &&
                                    i.Compra.DataCriacao.Year == o.MesReferencia.Year)
                                .Sum(i =>
                                    (decimal?)(i.PrecoUnitario * i.QuantidadeComprada)) ?? 0
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
        // PERCENTAGEM DE ITENS PREVISTOS/NÃO PREVISTOS
        // =====================================================
        private void CarregarPercentagens()
        {
            try
            {
                using (AppDbContext db = new AppDbContext())
                {
                    // Analisa compras fechadas
                    dgvPercentagens.DataSource = db.Compras
                        .Where(c => c.Fechada)
                        .Select(c => new
                        {
                            c.NomeCompra,

                            // Total de itens na compra
                            TotalItens = c.Itens.Count(),

                            // Itens marcados como previstos
                            Previstos = c.Itens.Count(i => i.Previsto),

                            // Itens não previstos
                            NaoPrevistos = c.Itens.Count(i => !i.Previsto),

                            // Percentagem de previstos
                            PercentPrevistos =
                                c.Itens.Count() == 0 ? 0 :
                                (c.Itens.Count(i => i.Previsto) * 100) / c.Itens.Count(),

                            // Percentagem de não previstos
                            PercentNaoPrevistos =
                                c.Itens.Count() == 0 ? 0 :
                                (c.Itens.Count(i => !i.Previsto) * 100) / c.Itens.Count()
                        })
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                // Mostra erro caso falhe
                MessageBox.Show(ex.Message);
            }
        }

        // =====================================================
        // SUGESTÃO DE ORÇAMENTO
        // =====================================================
        private void GerarSugestaoOrcamento()
        {
            try
            {
                using (AppDbContext db = new AppDbContext())
                {
                    // Data atual
                    DateTime hoje = DateTime.Now;

                    // Soma total gasto no mês atual com compras efetuadas
                    decimal totalGasto =
                        db.ItensCompra
                        .Where(i =>
                            i.Comprado &&
                            i.Compra.DataCriacao.Month == hoje.Month &&
                            i.Compra.DataCriacao.Year == hoje.Year)
                        .Sum(i =>
                            (decimal?)(i.PrecoUnitario * i.QuantidadeComprada)) ?? 0;

                    // Mostra sugestão no label
                    lblSugestao.Text =
                        $"Para o próximo mês deves ter: {totalGasto:C}";

                    // Muda cor dependendo se há gastos
                    lblSugestao.ForeColor =
                        totalGasto > 0
                            ? System.Drawing.Color.DarkBlue
                            : System.Drawing.Color.Gray;
                }
            }
            catch (Exception ex)
            {
                // Mostra erro caso algo falhe
                MessageBox.Show(ex.Message);
            }
        }

        // Evento (não utilizado)
        private void dgvPercentagens_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}