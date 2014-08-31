using ProjetoFinal.SistemaLocadora.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.SistemaLocadora.BancoDados
{
    public class UserApplication
    {
        private Contexto _contexto;

        public UserApplication(Contexto contexto)
        {
            this._contexto = contexto;
        }
        
        public Usuario GetByUsernameAndPassword(Usuario user)
        {
            UserRepository userRepo = new UserRepository(_contexto);
            return userRepo.GetByUsernameAndPassword(user);
        }

    }
}
