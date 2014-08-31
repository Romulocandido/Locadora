using ProjetoFinal.SistemaLocadora.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.SistemaLocadora.BancoDados
{
    public class UserBancoDados
    {

        private Contexto _contexto;

        public UserBancoDados(Contexto contexto)
        {
            this._contexto = contexto;
        }

        public IQueryable<Usuario> LocalizarTodas()
        {
            return (from c in this._contexto.TabelaUsuarios
                    select c);
        }
        public void Inserir(Usuario novoUsuario)
        {
            this._contexto.TabelaUsuarios.Add(novoUsuario);
            this._contexto.SaveChanges();
        }

        public void Editar(Usuario usuarioEditado)
        {
            this._contexto.Entry(usuarioEditado).State = System.Data.Entity.EntityState.Modified;
            this._contexto.SaveChanges();
        }
        public Usuario LocalizarId(int id)
        {
            return (from c in this._contexto.TabelaUsuarios
                    where c.Id == id
                    select c).FirstOrDefault();
        }
        public void Deletar(int id)
        {
            Usuario resultado = this.LocalizarId(id);
            this._contexto.TabelaUsuarios.Remove(resultado);
            this._contexto.SaveChanges();
        }
    }
}
