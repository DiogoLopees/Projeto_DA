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
    // Formulário responsável pela gestão de utilizadores
    public partial class FormUtilizadores : Form
    {
        // Guarda o ID do utilizador selecionado (-1 = nenhum)
        private int idSelecionado = -1;

        // Construtor do formulário
        public FormUtilizadores()
        {
            InitializeComponent();
        }

        // Evento de carregamento do formulário
        private void FormUtilizadores_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();       // configura a tabela
            CarregarUtilizadores(); // carrega dados da BD
        }

        // =====================================================
        // CONFIGURAÇÃO DA GRID
        // =====================================================
        private void ConfigurarGrid()
        {
            dgvUtilizadores.AutoGenerateColumns = false;
            dgvUtilizadores.Columns.Clear();
            dgvUtilizadores.RowHeadersVisible = false;

            dgvUtilizadores.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvUtilizadores.MultiSelect = false;

            dgvUtilizadores.ReadOnly = true;

            dgvUtilizadores.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            // Coluna Id (oculta)
            dgvUtilizadores.Columns.Add(
                new DataGridViewTextBoxColumn()
                {
                    Name = "Id",
                    DataPropertyName = "Id",
                    Visible = false
                });

            // Coluna Nome
            dgvUtilizadores.Columns.Add(
                new DataGridViewTextBoxColumn()
                {
                    Name = "Nome",
                    HeaderText = "Nome",
                    DataPropertyName = "Nome"
                });
        }

        // =====================================================
        // CARREGAR UTILIZADORES
        // =====================================================
        private void CarregarUtilizadores()
        {
            try
            {
                using (AppDbContext db =
                    new AppDbContext())
                {
                    dgvUtilizadores.DataSource =
                        db.Utilizadores
                        .Select(u => new
                        {
                            u.Id,
                            u.Nome
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
        // ELIMINAR UTILIZADOR
        // =====================================================
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica se há linha selecionada
                if (dgvUtilizadores.CurrentRow == null)
                {
                    MessageBox.Show(
                        "Seleciona um utilizador.");

                    return;
                }

                // Obtém ID selecionado
                int id = Convert.ToInt32(
                    dgvUtilizadores.CurrentRow.Cells["Id"].Value);

                using (AppDbContext db =
                    new AppDbContext())
                {
                    // Procura utilizador na base de dados
                    Utilizadores utilizador =
                        db.Utilizadores.Find(id);

                    // Remove se existir
                    if (utilizador != null)
                    {
                        db.Utilizadores.Remove(utilizador);
                        db.SaveChanges();
                    }
                }

                // Atualiza grid
                CarregarUtilizadores();

                MessageBox.Show(
                    "Utilizador eliminado.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Evento vazio (não utilizado)
        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        // =====================================================
        // ADICIONAR UTILIZADOR
        // =====================================================
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validação básica
                if (string.IsNullOrWhiteSpace(txtNome.Text) ||
                    string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show(
                        "Preenche todos os campos.");

                    return;
                }

                using (AppDbContext db =
                    new AppDbContext())
                {
                    // Verifica se já existe utilizador com o mesmo nome
                    bool existe =
                        db.Utilizadores.Any(u =>
                            u.Nome == txtNome.Text.Trim());

                    if (existe)
                    {
                        MessageBox.Show(
                            "Esse utilizador já existe.");

                        return;
                    }

                    // Criação de novo utilizador
                    Utilizadores utilizador =
                        new Utilizadores()
                        {
                            Nome =
                                txtNome.Text.Trim(),

                            Password =
                                txtPassword.Text.Trim()
                        };

                    // Adiciona à base de dados
                    db.Utilizadores.Add(utilizador);

                    db.SaveChanges();
                }

                // Limpa campos
                txtNome.Clear();
                txtPassword.Clear();

                // Atualiza grid
                CarregarUtilizadores();

                MessageBox.Show(
                    "Utilizador criado.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // =====================================================
        // SELEÇÃO NA GRID
        // =====================================================
        private void dgvUtilizadores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Guarda ID selecionado
            idSelecionado = Convert.ToInt32(
                dgvUtilizadores.Rows[e.RowIndex].Cells["Id"].Value);

            // Preenche textbox com nome
            txtNome.Text =
                dgvUtilizadores.Rows[e.RowIndex].Cells["Nome"].Value.ToString();
        }

        // =====================================================
        // EDITAR UTILIZADOR
        // =====================================================
        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idSelecionado == -1)
                {
                    MessageBox.Show("Seleciona um utilizador.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtNome.Text) ||
                    string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Preenche todos os campos.");
                    return;
                }

                using (AppDbContext db = new AppDbContext())
                {
                    // Procura utilizador na base de dados
                    var user = db.Utilizadores.Find(idSelecionado);

                    if (user == null) return;

                    // Atualiza dados
                    user.Nome = txtNome.Text.Trim();
                    user.Password = txtPassword.Text.Trim();

                    db.SaveChanges();
                }

                // Limpa estado
                txtNome.Clear();
                txtPassword.Clear();
                idSelecionado = -1;

                // Atualiza grid
                CarregarUtilizadores();

                MessageBox.Show("Utilizador atualizado.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}