using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoDA.Models;

namespace ProjetoDA.Helpers
{
    // Classe estática usada para guardar informação da sessão do utilizador
    // Funciona como uma "memória global" enquanto a aplicação está aberta
    public static class Sessao
    {
        // ID do utilizador atualmente autenticado
        public static int UtilizadorId { get; set; }

        // Nome do utilizador atualmente autenticado
        public static string UtilizadorNome { get; set; }
    }
}