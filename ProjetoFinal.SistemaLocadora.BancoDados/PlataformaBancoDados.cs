using ProjetoFinal.SistemaLocadora.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.SistemaLocadora.BancoDados
{
    public class PlataformaBancoDados
    {
        private Contexto _contexto;

        public PlataformaBancoDados(Contexto contexto)
        {
            this._contexto = contexto;
        }
        public IQueryable<Plataforma> LocalizarTodas()
        {
            return (from c in this._contexto.TabelaPlataformas
                    select c);
        }

        public void Inserir(Plataforma novaPlataforma)
        {
            this._contexto.TabelaPlataformas.Add(novaPlataforma);
            this._contexto.SaveChanges();
        }
        public void Editar(Plataforma plataformaEditada)
        {
            this._contexto.Entry(plataformaEditada).State = System.Data.Entity.EntityState.Modified;
            this._contexto.SaveChanges();
        }
        public Plataforma LocalizarId(int id)
        {
            return (from c in this._contexto.TabelaPlataformas
                    where c.Id == id
                    select c).FirstOrDefault();
        }

        public void Deletar(int id)
        {
            Plataforma resultado = this.LocalizarId(id);
            this._contexto.TabelaPlataformas.Remove(resultado);
            this._contexto.SaveChanges();
        }
    }
}
