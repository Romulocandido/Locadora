using ProjetoFinal.SistemaLocadora.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.SistemaLocadora.BancoDados
{
    public class PermissaoBancoDados
    {
        private Contexto _contexto;

        public PermissaoBancoDados(Contexto contexto)
        {
            this._contexto = contexto;
        }
        public IQueryable<Permissao> LocalizarTodas()
        {
            return (from c in this._contexto.TabelaPermissoes 
                    select c);
        }

        public void Inserir(Permissao novaPermissao)
        {
            this._contexto.TabelaPermissoes.Add(novaPermissao );
            this._contexto.SaveChanges();
        }
        public void Editar(Permissao permissaoEditada)
        {
            this._contexto.Entry(permissaoEditada).State = System.Data.Entity.EntityState.Modified;
            this._contexto.SaveChanges();
        }
        public Permissao LocalizarId(int id)
        {
            return (from c in this._contexto.TabelaPermissoes 
                    where c.Id == id
                    select c).FirstOrDefault();
        }

        public void Deletar(int id)
        {
            Permissao resultado = this.LocalizarId(id);
            this._contexto.TabelaPermissoes .Remove(resultado);
            this._contexto.SaveChanges();
        }
    }
}
