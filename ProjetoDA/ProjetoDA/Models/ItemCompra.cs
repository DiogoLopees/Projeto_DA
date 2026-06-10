using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDA.Models
{
    // Classe que representa um item dentro de uma compra
    public class ItemCompra
    {
        // Identificador único do item de compra (chave primária)
        public int Id { get; set; }

        // Chave estrangeira para a compra associada
        public int CompraId { get; set; }

        // Propriedade de navegação para a entidade Compras
        public virtual Compras Compra { get; set; }

        // Chave estrangeira para o artigo associado
        public int ArtigoId { get; set; }

        // Propriedade de navegação para a entidade Artigo
        public virtual Artigo Artigo { get; set; }

        // Quantidade planeada/prevista para compra
        public int QuantidadePrevista { get; set; }

        // Quantidade efetivamente comprada
        public int QuantidadeComprada { get; set; }

        // Preço unitário do artigo
        public decimal PrecoUnitario { get; set; }

        // TRUE = item previsto na compra
        // FALSE = item não previsto
        public bool Previsto { get; set; }

        // Indica se o item já foi comprado
        public bool Comprado { get; set; }

        // Observações adicionais sobre o item
        public string Observacoes { get; set; }
    }
}