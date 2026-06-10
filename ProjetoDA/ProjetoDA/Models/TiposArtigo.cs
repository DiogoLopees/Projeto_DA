using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDA.Models
{
    // Classe que representa o Tipo de Artigo no sistema
    public class TipoArtigo
    {
        // Identificador único do tipo de artigo (chave primária)
        public int Id { get; set; }

        // Nome do tipo de artigo
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        // Relação 1-N: um TipoArtigo pode ter vários Artigos associados
        public virtual ICollection<Artigo> Artigos { get; set; }
    }
}