using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDA.Models
{
    public class Compras
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Fechada { get; set; }
        public DateTime? DataFecho { get; set; }
        public int CriadoPorId { get; set; }
        public Utilizadores CriadoPor { get; set; }
        public int? FechadoPorId { get; set; }
        public Utilizadores FechadoPor { get; set; }
        public ICollection<ItemCompra> Itens { get; set; }
    }
}
