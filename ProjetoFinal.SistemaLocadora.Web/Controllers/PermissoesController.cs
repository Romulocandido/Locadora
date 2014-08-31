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
    public class PermissoesController : Controller
    {
        private Contexto _contexto;
        private PermissaoBancoDados _bd;

        public PermissoesController()
        {
            this._contexto = new Contexto("SistemaLocadora");
            this._bd = new PermissaoBancoDados(this._contexto);
        }
        //
        // GET: /Permissoes/

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
        public ActionResult Cadastrar(Permissao novaPermissao)
        {
            this._bd.Inserir(novaPermissao );
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            var resultado = this._bd.LocalizarId(id);
            return View(resultado);
        }
        [HttpPost]
        public ActionResult Editar(Permissao permissaoEditada)
        {
            this._bd.Editar(permissaoEditada);
            return RedirectToAction("Index");
        }
        public ActionResult Deletar(int id)
        {
            this._bd.Deletar(id);
            return RedirectToAction("Index");
        }

    }
}
