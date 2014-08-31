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
    public class CategoriasController : Controller
    {

        private Contexto _contexto;
        private CategoriaBancoDados _bd;

        public CategoriasController()
        {
            this._contexto = new Contexto("SistemaLocadora");
            this._bd = new CategoriaBancoDados(this._contexto);
        }
        //
        // GET: /Categorias/
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
        public ActionResult Cadastrar(Categoria novaCategoria)
        {
            this._bd.Inserir(novaCategoria);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            var resultado = this._bd.LocalizarId(id);
            return View(resultado);
        }
        [HttpPost]
        public ActionResult Editar(Categoria categoriaEditada)
        {
            this._bd.Editar(categoriaEditada);
            return RedirectToAction("Index");
        }
        public ActionResult Deletar(int id)
        {
            this._bd.Deletar(id);
            return RedirectToAction("Index");
        }


    }
}
