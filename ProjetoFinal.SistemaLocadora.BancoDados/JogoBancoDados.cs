using ProjetoFinal.SistemaLocadora.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ProjetoFinal.SistemaLocadora.BancoDados
{
    public class JogoBancoDados
    {
        private Contexto _contexto;

        public JogoBancoDados(Contexto contexto)
        {
            this._contexto = contexto;
        }

        public IQueryable<Jogo> LocalizarTodas()
        {
            return (from c in this._contexto.TabelaJogos.Include(p => p.Categoria).Include(t => t.Console)
                    select c);
        }
        public void Inserir(Jogo novoJogo)
        {
            this._contexto.TabelaJogos.Add(novoJogo);
            this._contexto.SaveChanges();
        }
        public void Editar(Jogo jogoEditado)
        {
            this._contexto.Entry(jogoEditado).State = System.Data.Entity.EntityState.Modified;
            this._contexto.SaveChanges();
        }
        public Jogo LocalizarId(int id)
        {
            return (from c in this._contexto.TabelaJogos
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
