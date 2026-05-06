using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ProjetoDA.Models;

namespace ProjetoDA.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=iShoppingDB") { }

        public DbSet<Utilizadores> Utilizadores { get; set; }
        public DbSet<TipoArtigo> TiposArtigo { get; set; }
        public DbSet<Artigo> Artigos { get; set; }
        public DbSet<Orcamento> Orcamentos { get; set; }
        public DbSet<Compras> Compras { get; set; }
        public DbSet<ItemCompra> ItensCompra { get; set; }
    }
}
