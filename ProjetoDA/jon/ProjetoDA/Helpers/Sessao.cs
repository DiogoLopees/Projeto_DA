using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoDA.Models;

namespace ProjetoDA.Helpers
{
    public static class Sessao
    {
        // Dados do utilizador logado
        public static int UtilizadorId { get; set; }
        public static string UtilizadorNome { get; set; }

        // Verifica se há alguém logado
        public static bool EstaLogado => UtilizadorId > 0;

        // Limpa a sessão (usado no logout)
        public static void Terminar()
        {
            UtilizadorId = 0;
            UtilizadorNome = string.Empty;
        }
    }
}
