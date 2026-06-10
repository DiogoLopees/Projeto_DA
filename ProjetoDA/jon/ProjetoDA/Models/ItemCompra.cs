using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDA.Models
{
    public class ItemCompra
    {
        public int Id { get; set; }
        public int CompraId { get; set; }
        public Compras Compra { get; set; }
        public int ArtigoId { get; set; }
        public Artigo Artigo { get; set; }
        public int QuantidadePrevista { get; set; }
        public int? QuantidadeAdquirida { get; set; }
        public decimal? PrecoUnitario { get; set; }
        public bool Previsto { get; set; }          // true = previsto, false = não previsto
        public string Observacoes { get; set; }     // só para não previstos
        public int CriadoPorId { get; set; }
        public Utilizadores CriadoPor { get; set; }
        public DateTime DataCriacao { get; set; }
        public int? AlteradoPorId { get; set; }
        public Utilizadores AlteradoPor { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}
