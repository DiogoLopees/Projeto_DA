using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoDA.Data;
using ProjetoDA.Models;

namespace ProjetoDA.Controlers
{
    // Controller responsável pelas operações CRUD de Artigos
    public class TipoArtigoController
    {
        // Contexto da base de dados (Entity Framework)
        private AppDbContext db = new AppDbContext();

        // =====================================================
        // OBTER TODOS OS ARTIGOS
        // =====================================================
        public List<Artigo> GetTodos()
        {
            // Inclui o TipoArtigo associado para evitar lazy loading
            return db.Artigos.Include("TipoArtigo").ToList();
        }

        // =====================================================
        // INSERIR ARTIGO
        // =====================================================
        public bool Inserir(string nome, int tipoId)
        {
            // Validação básica do nome
            if (string.IsNullOrWhiteSpace(nome)) return false;

            // Criação de novo artigo
            db.Artigos.Add(new Artigo
            {
                Nome = nome,
                TipoArtigoId = tipoId
            });

            // Guarda na base de dados
            db.SaveChanges();
            return true;
        }

        // =====================================================
        // ATUALIZAR ARTIGO
        // =====================================================
        public bool Atualizar(int id, string nome, int tipoId)
        {
            // Procura artigo pelo ID
            var art = db.Artigos.Find(id);

            // Se não existir, falha
            if (art == null) return false;

            // Atualiza dados
            art.Nome = nome;
            art.TipoArtigoId = tipoId;

            db.SaveChanges();
            return true;
        }

        // =====================================================
        // ELIMINAR ARTIGO
        // =====================================================
        public bool Eliminar(int id)
        {
            // Procura artigo
            var art = db.Artigos.Find(id);

            // Se não existir, falha
            if (art == null) return false;

            // Remove da base de dados
            db.Artigos.Remove(art);
            db.SaveChanges();
            return true;
        }

        // =====================================================
        // MÉTODOS NÃO IMPLEMENTADOS (OVERLOADS)
        // =====================================================
        internal bool Inserir(string nome)
        {
            throw new NotImplementedException();
        }

        internal bool Atualizar(int idSelecionado, string nome)
        {
            throw new NotImplementedException();
        }
    }
}