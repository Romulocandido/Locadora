using ProjetoFinal.SistemaLocadora.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ProjetoFinal.SistemaLocadora.BancoDados
{
    public class AcervoBancoDados
    {
        private Contexto _contexto;

        public AcervoBancoDados(Contexto contexto)
        {
            this._contexto = contexto;
        }

        public IList<ProdutoExibir> ListarProdutosIndex()
        {
            return (from p in this._contexto.TabelaAcervos                    
                     join ac in this._contexto.TabelaCategorias on p.Produto.Categoria.Id equals ac.Id                     
                     where p.Dano == null
                     group p by new
                     {
                        id = p.Produto.Id,
                        categoria = ac.Nome
                     } into g
                     select new ProdutoExibir() { id = g.Key.id, Categoria = g.Key.categoria,
                         Quantidade = g.Count() }).ToList();
        }
        public IList<ProdutoExibir> ListarDanosIndex()
        {
            return (from p in this._contexto.TabelaAcervos
                    join ac in this._contexto.TabelaCategorias on p.Produto.Categoria.Id equals ac.Id
                    where p.Dano != null
                    group p by new
                    {
                        id = p.Produto.Id,
                        categoria = ac.Nome,
                        motivo = p.MotivoDano
                    } into g
                    select new ProdutoExibir()
                    {
                        id = g.Key.id,
                        Categoria = g.Key.categoria,
                        Quantidade = g.Count(),
                        Motivo = g.Key.motivo
                    }).ToList();
        }
    
        public void Inserir(Acervo novoAcervo)
        {
            this._contexto.TabelaAcervos.Add(novoAcervo);
            this._contexto.SaveChanges();
        }
        public Produto LocalizarId(int id)
        {
            return (from c in this._contexto.TabelaProdutos
                    where c.Id == id
                    select c).FirstOrDefault();
        }
        public Acervo LocalizarAcervoId(int id)
        {
            return (from c in this._contexto.TabelaAcervos
                    join p in this._contexto.TabelaProdutos on c.Produto.Id equals p.Id
                    where p.Id == id
                    select c).FirstOrDefault();
        }
        public void Editar(Acervo acervo)
        {
            this._contexto.Entry(acervo).State = System.Data.Entity.EntityState.Modified;
            this._contexto.SaveChanges();
        }
    }
}
