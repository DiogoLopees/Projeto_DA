using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDA.Models
{
    // Classe que representa uma Compra no sistema
    public class Compras
    {
        // Construtor da classe
        // Inicializa a lista de itens para evitar null reference exceptions
        public Compras()
        {
            Itens = new List<ItemCompra>();
        }

        // Identificador único da compra (chave primária)
        public int Id { get; set; }

        // Nome ou descrição da compra
        [Required]
        [StringLength(100)]
        public string NomeCompra { get; set; }

        // Data em que a compra foi criada
        public DateTime DataCriacao { get; set; }

        // Indica se a compra está fechada ou ainda em aberto
        public bool Fechada { get; set; }

        // Data em que a compra foi fechada (nullable porque pode ainda não estar fechada)
        public DateTime? DataFecho { get; set; }

        // ID do utilizador que criou a compra (chave estrangeira)
        public int CriadoPorId { get; set; }

        // Relação com o utilizador que criou a compra
        public virtual Utilizadores CriadoPor { get; set; }

        // ID do utilizador que alterou a compra pela última vez (opcional)
        public int? AlteradoPorId { get; set; }

        // Relação com o utilizador que fez alterações na compra
        public virtual Utilizadores AlteradoPor { get; set; }

        // ID do utilizador que fechou a compra (opcional)
        public int? FechadoPorId { get; set; }

        // Relação com o utilizador que fechou a compra
        public virtual Utilizadores FechadoPor { get; set; }

        // Coleção de itens pertencentes a esta compra (relação 1-N)
        public virtual ICollection<ItemCompra> Itens { get; set; }
    }
}