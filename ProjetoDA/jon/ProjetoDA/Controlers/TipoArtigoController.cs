using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoDA.Data;
using ProjetoDA.Models;

namespace ProjetoDA.Controlers
{
    public class TipoArtigoController
    {
        private AppDbContext db = new AppDbContext();

        public List<TipoArtigo> GetTodos()
        {
            return db.TiposArtigo.ToList();
        }

        public TipoArtigo GetPorId(int id)
        {
            return db.TiposArtigo.Find(id);
        }

        public bool Inserir(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome)) return false;

            bool existe = db.TiposArtigo.Any(t => t.Nome == nome);
            if (existe) return false;

            db.TiposArtigo.Add(new TipoArtigo { Nome = nome });
            db.SaveChanges();
            return true;
        }
        public bool Atualizar(int id, string nome)
        {
            if (string.IsNullOrWhiteSpace(nome)) return false;

            var tipo = db.TiposArtigo.Find(id);
            if (tipo == null) return false;

            tipo.Nome = nome;
            db.SaveChanges();
            return true;
        }

        public bool Eliminar(int id)
        {
            var tipo = db.TiposArtigo.Find(id);
            if (tipo == null) return false;

            // Verifica se tem artigos associados
            bool temArtigos = db.Artigos.Any(a => a.TipoArtigoId == id);
            if (temArtigos) return false;

            db.TiposArtigo.Remove(tipo);
            db.SaveChanges();
            return true;
        }
    }
}
