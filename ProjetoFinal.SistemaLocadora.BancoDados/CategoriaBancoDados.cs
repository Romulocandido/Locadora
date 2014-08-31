using ProjetoFinal.SistemaLocadora.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.SistemaLocadora.BancoDados
{
    public class CategoriaBancoDados
    {
        private Contexto _contexto;

        public CategoriaBancoDados(Contexto contexto)
        {
            this._contexto = contexto;
        }

        public IQueryable<Categoria> LocalizarTodas()
        {
            return (from c in this._contexto.TabelaCategorias
                    select c);
        }

        public void Inserir(Categoria novaCategoria)
        {
            this._contexto.TabelaCategorias.Add(novaCategoria);
            this._contexto.SaveChanges();
        }
        public void Editar(Categoria categoriaEditada)
        {
            this._contexto.Entry(categoriaEditada).State = System.Data.Entity.EntityState.Modified;
            this._contexto.SaveChanges();
        }
        public Categoria LocalizarId(int id)
        {
            return (from c in this._contexto.TabelaCategorias
                    where c.Id == id
                    select c).FirstOrDefault();
        }

        public void Deletar(int id)
        {
            Categoria resultado = this.LocalizarId(id);
            this._contexto.TabelaCategorias.Remove(resultado);
            this._contexto.SaveChanges();
        }

    }
}
