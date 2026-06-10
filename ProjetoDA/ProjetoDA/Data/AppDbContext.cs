using ProjetoDA.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDA.Data
{
    // Classe de contexto da base de dados (Entity Framework)
    // Responsável por mapear as entidades para tabelas
    public class AppDbContext : DbContext
    {
        // Construtor que indica qual a connection string a usar
        public AppDbContext() : base("name=ProjetoDA")
        {
            // Cria a base de dados caso ainda não exista
            Database.SetInitializer(new CreateDatabaseIfNotExists<AppDbContext>());
        }

        // Tabela de Utilizadores
        public DbSet<Utilizadores> Utilizadores { get; set; }

        // Tabela de Tipos de Artigo
        public DbSet<TipoArtigo> TiposArtigo { get; set; }

        // Tabela de Artigos
        public DbSet<Artigo> Artigos { get; set; }

        // Tabela de Orçamentos
        public DbSet<Orcamento> Orcamentos { get; set; }

        // Tabela de Compras
        public DbSet<Compras> Compras { get; set; }

        // Tabela de Itens de Compra
        public DbSet<ItemCompra> ItensCompra { get; set; }

        // Configuração do modelo (regras adicionais de base de dados)
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Username único
            modelBuilder.Entity<Utilizadores>()
                .Property(u => u.Username)
                .HasColumnAnnotation(
                    "Index",
                    new IndexAnnotation(
                        new IndexAttribute("IX_USERNAME")
                        {
                            IsUnique = true
                        }));

            // Chama o comportamento base do Entity Framework
            base.OnModelCreating(modelBuilder);
        }
    }
}