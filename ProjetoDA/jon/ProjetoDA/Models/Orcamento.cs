using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDA.Models
{
    public class Orcamento
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public int CriadoPorId { get; set; }
        public Utilizadores CriadoPor { get; set; }
        public int? AlteradoPorId { get; set; }
        public Utilizadores AlteradoPor { get; set; }
    }
}
