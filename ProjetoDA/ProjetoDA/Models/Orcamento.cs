using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDA.Models
{
    // Classe que representa um Orçamento no sistema
    public class Orcamento
    {
        // Identificador único do orçamento (chave primária)
        public int Id { get; set; }

        // Valor máximo permitido para o orçamento
        [Required]
        public decimal ValorMaximo { get; set; }

        // Mês de referência do orçamento (ex: janeiro 2026)
        public DateTime MesReferencia { get; set; }

        // ID do utilizador que criou o orçamento
        public int CriadoPorId { get; set; }

        // ID do utilizador que alterou o orçamento (nullable porque pode nunca ter sido alterado)
        public int? AlteradoPorId { get; set; }

        // Data em que o orçamento foi criado
        public DateTime DataCriacao { get; set; }

        // Data da última alteração (nullable porque pode nunca ter sido alterado)
        public DateTime? DataAlteracao { get; set; }
    }
}