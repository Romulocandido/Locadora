using ProjetoFinal.SistemaLocadora.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.SistemaLocadora.BancoDados
{
    public class Contexto : DbContext
    {
        public Contexto(string nomeConexao)
            : base(nomeConexao)
        {
            //migrations
            Database.SetInitializer<Contexto>(new DropCreateDatabaseIfModelChanges<Contexto>());
        }

        public DbSet<Categoria> TabelaCategorias { get; set; }
        public DbSet<Cliente> TabelaClientes { get; set; }
        public DbSet<Produto> TabelaProdutos { get; set; }
        public DbSet<Filme> TabelaFilmes { get; set; }
        public DbSet<Jogo> TabelaJogos { get; set; }
        public DbSet<Plataforma> TabelaPlataformas { get; set; }
        public DbSet<Acervo> TabelaAcervos { get; set; }
        public DbSet<Usuario> TabelaUsuarios { get; set; }
        public DbSet<Permissao> TabelaPermissoes { get; set; }   
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove();
            modelBuilder.Entity<Categoria>().ToTable("Categorias");
            modelBuilder.Entity<Cliente>().ToTable("Clientes");
            modelBuilder.Entity<Produto>().ToTable("Produtos");
            modelBuilder.Entity<Filme>().ToTable("Filmes");
            modelBuilder.Entity<Jogo>().ToTable("Jogos");
            modelBuilder.Entity<Plataforma>().ToTable("Plataformas");
            modelBuilder.Entity<Acervo>().ToTable("Acervos");
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<Permissao>().ToTable("Permissoes");
            base.OnModelCreating(modelBuilder);
        }

    }
}
