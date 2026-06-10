using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDA.Models
{
    public class TipoArtigo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Artigo> Artigos { get; set; }
    }
}
