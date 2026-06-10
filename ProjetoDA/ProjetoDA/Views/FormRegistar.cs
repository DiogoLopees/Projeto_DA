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
    // Formulário responsável pelo registo de novos utilizadores
    public partial class FormRegistar : Form
    {
        // Construtor do formulário
        public FormRegistar()
        {
            InitializeComponent();

            // Oculta a password com caracteres mascarados
            txtPassword.UseSystemPasswordChar = true;
        }

        // Evento de carregamento do formulário (não usado)
        private void FormRegistrar_Load(object sender, EventArgs e)
        {

        }

        // Evento do botão "Criar Conta"
        private void btnCriarConta_Click(object sender, EventArgs e)
        {
            try
            {
                // Recolha e limpeza dos campos
                string nome = txtNome.Text.Trim();
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();

                // =========================
                // VALIDAÇÃO DE CAMPOS
                // =========================

                // Verifica se algum campo está vazio
                if (string.IsNullOrWhiteSpace(nome) ||
                    string.IsNullOrWhiteSpace(username) ||
                    string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show(
                        "Preenche todos os campos.",
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return; // interrompe execução
                }

                // Ligação à base de dados
                using (AppDbContext db = new AppDbContext())
                {
                    // Verifica se o username já existe
                    bool existe = db.Utilizadores
                        .Any(u => u.Username == username);

                    if (existe)
                    {
                        MessageBox.Show(
                            "Esse username já existe.",
                            "Erro",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                        return;
                    }

                    // Criação de novo utilizador
                    Utilizadores utilizador = new Utilizadores()
                    {
                        Nome = nome,
                        Username = username,
                        Password = password
                    };

                    // Adiciona à base de dados
                    db.Utilizadores.Add(utilizador);

                    // Guarda alterações
                    db.SaveChanges();

                    // Mensagem de sucesso
                    MessageBox.Show(
                        "Conta criada com sucesso!");

                    // Fecha o formulário
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                // Tratamento de erros inesperados
                MessageBox.Show(
                    ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}