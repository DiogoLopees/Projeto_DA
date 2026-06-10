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
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Preenche o username e a password.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var db = new AppDbContext())
            {
                var utilizador = db.Utilizadores
                    .FirstOrDefault(u => u.Username == username && u.Password == password);

                if (utilizador == null)
                {
                    MessageBox.Show("Credenciais inválidas.", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Guarda o utilizador na sessão
                Sessao.UtilizadorId = utilizador.Id;
                Sessao.UtilizadorNome = utilizador.Username;

                // Abre o formulário principal e fecha o login
                var formPrincipal = new Form1();
                formPrincipal.Show();
                this.Hide();
            }
        }

        private void btnRegistar_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Preenche o username e a password para registar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var db = new AppDbContext())
            {
                bool existe = db.Utilizadores.Any(u => u.Username == username);
                if (existe)
                {
                    MessageBox.Show("Este username já existe.", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var novo = new Utilizadores { Username = username, Password = password };
                db.Utilizadores.Add(novo);
                db.SaveChanges();

                MessageBox.Show("Utilizador registado com sucesso! Podes fazer login.", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
