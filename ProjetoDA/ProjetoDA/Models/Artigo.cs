using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDA.Models
{
    // Classe que representa a entidade Artigo na base de dados
    public class Artigo
    {
        // Chave primária da tabela Artigo
        public int Id { get; set; }

        // Propriedade Nome do artigo
        // [Required] -> campo obrigatório (não pode ser null ou vazio)
        // [StringLength(100)] -> limita o tamanho máximo a 100 caracteres
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        // Chave estrangeira para o TipoArtigo
        public int TipoArtigoId { get; set; }

        // Relação de navegação com a entidade TipoArtigo
        [ForeignKey(nameof(TipoArtigoId))] // -> indica que esta propriedade está ligada à chave estrangeira TipoArtigoId
        public virtual TipoArtigo TipoArtigo { get; set; }
    }
}