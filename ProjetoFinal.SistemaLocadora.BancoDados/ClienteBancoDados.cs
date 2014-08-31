using ProjetoFinal.SistemaLocadora.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.SistemaLocadora.BancoDados
{
    public class ClienteBancoDados
    {
        private Contexto _contexto;

        public ClienteBancoDados(Contexto contexto)
        {
            this._contexto = contexto;
        }

        public IQueryable<Cliente> LocalizarTodas()
        {
            return (from c in this._contexto.TabelaClientes
                    select c);
        }
        public void Inserir(Cliente novoCliente)
        {
            this._contexto.TabelaClientes.Add(novoCliente);
            this._contexto.SaveChanges();
        }

        public void Editar(Cliente clienteEditado)
        {
            this._contexto.Entry(clienteEditado).State = System.Data.Entity.EntityState.Modified;
            this._contexto.SaveChanges();
        }
        public Cliente LocalizarId(int id)
        {
            return (from c in this._contexto.TabelaClientes
                    where c.Id == id
                    select c).FirstOrDefault();
        }
        public void Deletar(int id)
        {
            Cliente resultado = this.LocalizarId(id);
            this._contexto.TabelaClientes.Remove(resultado);
            this._contexto.SaveChanges();
        }
    }
}
