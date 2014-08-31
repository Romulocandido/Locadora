using ProjetoFinal.SistemaLocadora.BancoDados;
using ProjetoFinal.SistemaLocadora.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoFinal.SistemaLocadora.Web.Controllers
{
    [Authorize]
    public class PlataformasController : Controller
    {
        private Contexto _contexto;
        private PlataformaBancoDados _bd;

        public PlataformasController()
        {
            this._contexto = new Contexto("SistemaLocadora");
            this._bd = new PlataformaBancoDados(this._contexto);
        }
        //
        // GET: /Plataformas/

        public ActionResult Index()
        {
            var lista = this._bd.LocalizarTodas();
            return View(lista);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Cadastrar(Plataforma novaPlataforma)
        {
            this._bd.Inserir(novaPlataforma);
            return RedirectToAction("Index");
        }
        public ActionResult Editar(int id)
        {
            var resultado = this._bd.LocalizarId(id);
            return View(resultado);
        }
        [HttpPost]
        public ActionResult Editar(Plataforma plataformaEditada)
        {
            this._bd.Editar(plataformaEditada);
            return RedirectToAction("Index");
        }
        public ActionResult Deletar(int id)
        {
            this._bd.Deletar(id);
            return RedirectToAction("Index");
        }

    }
}
