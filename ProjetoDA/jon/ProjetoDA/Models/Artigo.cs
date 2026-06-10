using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDA.Models
{
    public class Artigo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int TipoArtigoId { get; set; }
        public TipoArtigo TipoArtigo { get; set; }
    }
}
