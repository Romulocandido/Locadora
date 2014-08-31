using ProjetoFinal.SistemaLocadora.BancoDados;
using ProjetoFinal.SistemaLocadora.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoFinal.SistemaLocadora.Web.Controllers
{
    public class HomeController : Controller
    {
        private Contexto _contexto;
        private AcervoBancoDados _bd;

        public HomeController()
        {
            this._contexto = new Contexto("SistemaLocadora");
            this._bd = new AcervoBancoDados(this._contexto);
        }
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var lista = this._bd.ListarProdutosIndex();
            AcervoBancoDados produtos = new AcervoBancoDados(this._contexto);
            foreach (var item in lista)
            {
                Produto model = produtos.LocalizarId(item.id);
                item.Nome = model.Nome;
                item.Valor = model.Valor;
                item.Imagem = model.Imagem;
            }
            return View(lista);
        }

    }
}
