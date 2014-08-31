using ProjetoFinal.SistemaLocadora.BancoDados;
using ProjetoFinal.SistemaLocadora.Dominio;
using ProjetoFinal.SistemaLocadora.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProjetoFinal.SistemaLocadora.Web.Controllers
{
    [Authorize]
    public class AcervosController : Controller
    {
        private Contexto _contexto;
        private AcervoBancoDados _bd;

        public AcervosController()
        {
            this._contexto = new Contexto("SistemaLocadora");
            this._bd = new AcervoBancoDados(this._contexto);
        }
        //
        // GET: /Acervos/
        public ActionResult Index()
        {
            var lista = this._bd.ListarProdutosIndex();
            AcervoBancoDados produtos = new AcervoBancoDados(this._contexto);
            foreach (var item in lista)
            {
                Produto model = produtos.LocalizarId(item.id);
                item.Nome = model.Nome;
            }
            return View(lista);
        }

        public ActionResult DanosView()
        {
            var lista = this._bd.ListarDanosIndex();
            AcervoBancoDados produtos = new AcervoBancoDados(this._contexto);
            foreach (var item in lista)
            {
                Produto model = produtos.LocalizarId(item.id);
                item.Nome = model.Nome;
            }
            ViewBag.Motivo = "S";
            return View("Index", lista);
        }
        public ActionResult Cadastrar()
        {
            var produtos = (from p in this._contexto.TabelaProdutos
                            select p).ToList();

            ViewBag.produtos = new SelectList(produtos, "Id", "Nome");

            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Acervo acervo, int quantidade)
        {

            AcervoBancoDados banco = new AcervoBancoDados(this._contexto);
            Produto produto = new Produto();
            produto = banco.LocalizarId(acervo.Produto.Id);

            acervo.Produto = produto;
            for (int i = 0; i < quantidade; i++)
            {
                this._bd.Inserir(acervo);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Dano(int id)
        {
            AcervoBancoDados banco = new AcervoBancoDados(this._contexto);

            var produto = banco.LocalizarId(id);

            return View(produto);
        }
        [HttpPost]
        public ActionResult Dano(int id, int Quantidade, string Motivo)
        {
            for (int i = 0; i < Quantidade; i++)
            {
                AcervoBancoDados banco = new AcervoBancoDados(this._contexto);
                var Acervo = (from a in this._contexto.TabelaAcervos
                              where a.Produto.Id == id && a.Dano == null
                              select a).FirstOrDefault();

                Acervo.MotivoDano = Motivo;
                Acervo.Dano = "S";

                this._bd.Editar(Acervo);
            }

            return RedirectToAction("Index");
        }

    }
}
