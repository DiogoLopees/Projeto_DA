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
        // Construtor do formulário principal
        public FormPrincipal()
        {
            InitializeComponent();
        }

        // =====================================================
        // CARREGAMENTO DO FORMULÁRIO
        // =====================================================
        public void FormPrincipal_Load(object sender, EventArgs e)
        {
            // Configura a interface inicial
            ConfigurarInterface();

            // Carrega as compras abertas
            CarregarComprasAbertas();
        }

        // =====================================================
        // CONFIGURAÇÃO VISUAL INICIAL
        // =====================================================
        private void ConfigurarInterface()
        {
            // Mostra o nome do utilizador autenticado
            lblUtilizador.Text =
                $"Utilizador : {Sessao.UtilizadorNome}";

            // Configuração da DataGridView
            dgvComprasAbertas.AutoGenerateColumns = false;

            dgvComprasAbertas.Columns.Clear();

            dgvComprasAbertas.RowHeadersVisible = false;

            dgvComprasAbertas.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvComprasAbertas.MultiSelect = false;

            dgvComprasAbertas.AllowUserToAddRows = false;

            dgvComprasAbertas.ReadOnly = true;

            dgvComprasAbertas.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            // Coluna oculta para o ID
            dgvComprasAbertas.Columns.Add(
                new DataGridViewTextBoxColumn()
                {
                    Name = "Id",
                    DataPropertyName = "Id",
                    Visible = false
                });

            // Coluna do nome da compra
            dgvComprasAbertas.Columns.Add(
                new DataGridViewTextBoxColumn()
                {
                    Name = "NomeCompra",
                    HeaderText = "Nome",
                    DataPropertyName = "NomeCompra"
                });

            // Coluna da data de criação
            dgvComprasAbertas.Columns.Add(
                new DataGridViewTextBoxColumn()
                {
                    Name = "DataCriacao",
                    HeaderText = "Data",
                    DataPropertyName = "DataCriacao"
                });

            // Coluna da quantidade de itens
            dgvComprasAbertas.Columns.Add(
                new DataGridViewTextBoxColumn()
                {
                    Name = "Itens",
                    HeaderText = "Itens",
                    DataPropertyName = "Itens"
                });
        }

        // =====================================================
        // CARREGAR COMPRAS ABERTAS
        // =====================================================
        private void CarregarComprasAbertas()
        {
            try
            {
                using (AppDbContext db =
                    new AppDbContext())
                {
                    // Carrega apenas compras que ainda não foram fechadas
                    dgvComprasAbertas.DataSource =
                        db.Compras
                        .Where(c => !c.Fechada)
                        .ToList()
                        .Select(c => new
                        {
                            c.Id,

                            c.NomeCompra,

                            // Formata a data para dia/mês/ano
                            DataCriacao =
                                c.DataCriacao.ToString("dd/MM/yyyy"),

                            // Conta quantos itens existem na compra
                            Itens =
                                c.Itens.Count()
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
        // BOTÃO UTILIZADORES
        // =====================================================
        private void btnUtilizadores_Click_1(object sender, EventArgs e)
        {
            // Abre o formulário de gestão de utilizadores
            FormUtilizadores frm =
                new FormUtilizadores();

            frm.ShowDialog();
        }

        // =====================================================
        // BOTÃO TIPOS DE ARTIGO
        // =====================================================
        private void btnTiposArtigo_Click(object sender, EventArgs e)
        {
            FormTipoArtigo frm =
                new FormTipoArtigo();

            frm.ShowDialog();
        }

        // =====================================================
        // BOTÃO ARTIGOS
        // =====================================================
        private void btnArtigos_Click(object sender, EventArgs e)
        {
            FormArtigos frm =
                new FormArtigos();

            frm.ShowDialog();
        }

        // =====================================================
        // BOTÃO ORÇAMENTOS
        // =====================================================
        private void btnOrcamentos_Click(object sender, EventArgs e)
        {
            FormOrcamentos frm =
                new FormOrcamentos();

            frm.ShowDialog();
        }

        // =====================================================
        // BOTÃO COMPRAS
        // =====================================================
        private void btnCompras_Click(object sender, EventArgs e)
        {
            FormCompras frm =
               new FormCompras();

            frm.ShowDialog();

            // Atualiza a lista após fechar o formulário
            CarregarComprasAbertas();
        }

        // =====================================================
        // BOTÃO ESTATÍSTICAS
        // =====================================================
        private void btnEstatisticas_Click(object sender, EventArgs e)
        {
            FormEstatisticas frm =
                new FormEstatisticas();

            frm.ShowDialog();
        }

        // =====================================================
        // INICIAR COMPRA
        // =====================================================
        private void btnIniciarCompra_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica se existe uma compra selecionada
                if (dgvComprasAbertas.CurrentRow == null)
                {
                    MessageBox.Show(
                        "Seleciona uma compra.");

                    return;
                }

                // Obtém o ID da compra selecionada
                int compraId = Convert.ToInt32(
                    dgvComprasAbertas.CurrentRow.Cells["Id"].Value);

                // Abre o modo de gestão da compra
                FormModoCompra frm =
                    new FormModoCompra(compraId);

                frm.ShowDialog();

                // Atualiza a lista após alterações
                CarregarComprasAbertas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // =====================================================
        // SAIR DA APLICAÇÃO
        // =====================================================
        private void btnSair_Click(object sender, EventArgs e)
        {
            // Limpa os dados da sessão
            Sessao.UtilizadorId = 0;
            Sessao.UtilizadorNome = string.Empty;

            // Reabre o formulário de login
            new FormLogin().Show();

            // Fecha o formulário atual
            this.Close();
        }

        // =====================================================
        // ATUALIZAÇÃO AUTOMÁTICA
        // =====================================================
        // Atualiza a lista sempre que o formulário volta a ficar ativo
        private void FormPrincipal_Activated(object sender, EventArgs e)
        {
            CarregarComprasAbertas();
        }

        // Evento do label (sem implementação)
        private void label2_Click(object sender, EventArgs e)
        {

        }

        // =====================================================
        // BOTÃO TIPOS DE ARTIGO
        // =====================================================
        private void btnTiposArtigo_Click_1(object sender, EventArgs e)
        {
            FormTipoArtigo frm =
                new FormTipoArtigo();

            frm.ShowDialog();
        }

        // =====================================================
        // BOTÃO ARTIGOS
        // =====================================================
        private void btnArtigos_Click_1(object sender, EventArgs e)
        {
            FormArtigos frm =
                new FormArtigos();

            frm.ShowDialog();
        }

        // =====================================================
        // BOTÃO ORÇAMENTOS
        // =====================================================
        private void btnOrcamentos_Click_1(object sender, EventArgs e)
        {
            FormOrcamentos frm =
                new FormOrcamentos();

            frm.ShowDialog();
        }

        // =====================================================
        // BOTÃO COMPRAS
        // =====================================================
        private void btnCompras_Click_1(object sender, EventArgs e)
        {
            FormCompras frm =
                new FormCompras();

            frm.ShowDialog();

            // Atualiza a lista após fechar o formulário
            CarregarComprasAbertas();
        }

        // =====================================================
        // BOTÃO ESTATÍSTICAS
        // =====================================================
        private void btnEstatisticas_Click_1(object sender, EventArgs e)
        {
            FormEstatisticas frm =
                new FormEstatisticas();

            frm.ShowDialog();
        }

        // =====================================================
        // BOTÃO INICIAR COMPRA
        // =====================================================
        private void btnIniciarCompra_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Verifica se existe uma compra selecionada
                if (dgvComprasAbertas.CurrentRow == null)
                {
                    MessageBox.Show(
                        "Seleciona uma compra.",
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                // Obtém o ID da compra selecionada
                int compraId = Convert.ToInt32(
                    dgvComprasAbertas.CurrentRow.Cells["Id"].Value);

                // Abre o formulário de gestão da compra
                FormModoCompra frm =
                    new FormModoCompra(compraId);

                frm.ShowDialog();

                // Atualiza a lista após alterações
                CarregarComprasAbertas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =====================================================
        // BOTÃO SAIR
        // =====================================================
        private void btnSair_Click_1(object sender, EventArgs e)
        {
            // Limpa os dados da sessão
            Sessao.UtilizadorId = 0;
            Sessao.UtilizadorNome = string.Empty;

            // Volta ao login
            new FormLogin().Show();

            // Fecha o formulário principal
            this.Close();
        }

        // Evento da DataGridView (sem implementação)
        private void dgvComprasAbertas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}