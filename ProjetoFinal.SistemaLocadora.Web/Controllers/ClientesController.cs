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
    public class ClientesController : Controller
    {
        //
        // GET: /Clientes/
        private Contexto _contexto;
        private ClienteBancoDados _bd;

        public ClientesController()
        {
            this._contexto = new Contexto("SistemaLocadora");
            this._bd = new ClienteBancoDados(this._contexto);
        }

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
        public ActionResult Cadastrar(Cliente novoCliente)
        {
            this._bd.Inserir(novoCliente);
            return RedirectToAction("Index");
        }
        public ActionResult Editar(int id)
        {
            var resultado = this._bd.LocalizarId(id);
            return View(resultado);
        }
        [HttpPost]
        public ActionResult Editar(Cliente clienteEditado)
        {
            this._bd.Editar(clienteEditado);
            return RedirectToAction("Index");
        }

        public ActionResult Deletar(int id)
        {
            this._bd.Deletar(id);
            return RedirectToAction("Index");
        }

    }
}
