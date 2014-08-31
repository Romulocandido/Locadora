using ProjetoFinal.SistemaLocadora.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace ProjetoFinal.SistemaLocadora.BancoDados
{
    public class FilmeBancoDados
    {
        private Contexto _contexto;

        public FilmeBancoDados(Contexto contexto)
        {
            this._contexto = contexto;
        }
        public IQueryable<Filme> LocalizarTodas()
        {
            return (from c in this._contexto.TabelaFilmes.Include(p => p.Categoria)
                    select c);
        }
        public void Inserir(Filme novoFilme)
        {
            this._contexto.TabelaFilmes.Add(novoFilme);
            this._contexto.SaveChanges();
        }
        public void Editar(Filme filmeEditado)
        {
            this._contexto.Entry(filmeEditado).State = System.Data.Entity.EntityState.Modified;
            this._contexto.SaveChanges();
        }
        public Filme LocalizarId(int id)
        {
            return (from c in this._contexto.TabelaFilmes
                    where c.Id == id
                    select c).FirstOrDefault();
        }
        public void Deletar(int id)
        {
            Produto resultado = this.LocalizarId(id);
            this._contexto.TabelaProdutos.Remove(resultado);
            this._contexto.SaveChanges();
        }
    }
   
}
