using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDA.Models
{
    // Classe que representa um utilizador do sistema
    public class Utilizadores
    {
        // Identificador único do utilizador (chave primária)
        public int Id { get; set; }

        // Nome completo do utilizador
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        // Nome de utilizador (usado para login)
        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        // Palavra-passe do utilizador
        [Required] // -> campo obrigatório
        [StringLength(100)] // -> limita o tamanho máximo da password
        public string Password { get; set; }
    }
}