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
    public partial class FormLogin : Form
    {
        // Construtor do formulário de login
        public FormLogin()
        {
            InitializeComponent();
        }

        // =====================================================
        // CARREGAMENTO DO FORMULÁRIO
        // =====================================================
        private void FormLogin_Load(object sender, EventArgs e)
        {
            // Oculta os caracteres da password
            txtPassword.UseSystemPasswordChar = true;

            try
            {
                using (AppDbContext db =
                    new AppDbContext())
                {
                    // Inicializa a base de dados caso ainda não exista
                    db.Database.Initialize(false);
                }
            }
            catch (Exception ex)
            {
                // Mostra qualquer erro ocorrido
                MessageBox.Show(
                    ex.Message);
            }
        }

        // =====================================================
        // LOGIN
        // =====================================================
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtém o nome de utilizador introduzido
                string nome =
                    txtNome.Text.Trim();

                // Obtém a password introduzida
                string password =
                    txtPassword.Text.Trim();

                // Verifica se todos os campos foram preenchidos
                if (string.IsNullOrWhiteSpace(nome) ||
                    string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show(
                        "Preenche todos os campos.");

                    return;
                }

                using (AppDbContext db =
                    new AppDbContext())
                {
                    // Procura um utilizador com as credenciais fornecidas
                    var utilizador =
                            db.Utilizadores
                            .FirstOrDefault(u =>
                                u.Username == nome &&
                                u.Password == password);

                    // Se não encontrar o utilizador, mostra erro
                    if (utilizador == null)
                    {
                        MessageBox.Show(
                            "Credenciais inválidas.");

                        return;
                    }

                    // Guarda o ID do utilizador na sessão
                    Sessao.UtilizadorId =
                        utilizador.Id;

                    // Guarda o nome do utilizador na sessão
                    Sessao.UtilizadorNome =
                        utilizador.Nome;

                    // Cria uma instância do formulário principal
                    FormPrincipal frm =
                        new FormPrincipal();

                    // Esconde o formulário de login
                    this.Hide();

                    // Abre o formulário principal
                    frm.ShowDialog();

                    // Fecha o formulário de login após fechar o principal
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                // Mostra qualquer erro ocorrido
                MessageBox.Show(ex.Message);
            }
        }

        // =====================================================
        // ABRIR FORMULÁRIO DE REGISTO
        // =====================================================
        private void btnRegistar_Click(object sender, EventArgs e)
        {
            // Cria uma instância do formulário de registo
            FormRegistar frm = new FormRegistar();

            // Abre o formulário de registo
            frm.ShowDialog();
        }
    }
}