using ProjetoFinal.SistemaLocadora.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ProjetoFinal.SistemaLocadora.BancoDados
{
    public class UserRepository
    {
        private Contexto _contexto;

        public UserRepository(Contexto contexto)
        {
            this._contexto = contexto;
        }
        public Usuario GetByUsernameAndPassword(Usuario  user)
        {
            return (from u in this._contexto.TabelaUsuarios
                    where u.Username == user.Username & u.Password == user.Password
                    select u).FirstOrDefault();
        }
        
    }
}
