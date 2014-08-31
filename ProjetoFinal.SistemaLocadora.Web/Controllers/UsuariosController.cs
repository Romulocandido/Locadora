using ProjetoFinal.SistemaLocadora.BancoDados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Providers.Entities;
using System.Data.Entity;
using ProjetoFinal.SistemaLocadora.Dominio;
using ProjetoFinal.SistemaLocadora.Web.Models;

namespace ProjetoFinal.SistemaLocadora.Web.Controllers
{
    [Authorize]
    public class UsuariosController : Controller
    {
        private Contexto _contexto;
        private UserBancoDados _bd;

        public UsuariosController()
        {
            this._contexto = new Contexto("SistemaLocadora");
            this._bd = new UserBancoDados(this._contexto);
        }

        public ActionResult Index()
        {
            var lista = this._bd.LocalizarTodas();
            return View(lista);
        }

        public ActionResult Cadastrar()
        {
            var lista = (from c in this._contexto.TabelaPermissoes
                         select c).ToList();

            ViewBag.Permissao = new SelectList(lista, "Id", "Nome");
            return View();
        }
        [HttpPost]
        public ActionResult Cadastrar(Usuario novoUsuario)
        {

            PermissaoBancoDados banco = new PermissaoBancoDados(this._contexto);
            Permissao p = new Permissao();
            p = banco.LocalizarId(novoUsuario.Permissao.Id);

            novoUsuario.Permissao = p;

            this._bd.Inserir(novoUsuario);
            return RedirectToAction("Index");
        }
        public ActionResult Editar(int id)
        {
            var resultado = this._bd.LocalizarId(id);
            var lista = (from c in this._contexto.TabelaPermissoes 
                         select c).ToList();
            ViewBag.Permissao = new SelectList(lista, "Id", "Nome", resultado.Permissao.Id);

            return View(resultado);
        }
        [HttpPost]
        public ActionResult Editar(Usuario UsuarioEditado)
        {
            PermissaoBancoDados banco = new PermissaoBancoDados(this._contexto);
            Permissao p = new Permissao();
            p = banco.LocalizarId(UsuarioEditado.Permissao.Id);

            Usuario user = this._bd.LocalizarId(UsuarioEditado.Id);
            user.Permissao = p;
            user.Id = UsuarioEditado.Id;
            user.Name = UsuarioEditado.Name;
            user.Username = UsuarioEditado.Username;
            user.Password = UsuarioEditado.Password;

            this._bd.Editar(UsuarioEditado);
            return RedirectToAction("Index");
        }

        public ActionResult Deletar(int id)
        {
            this._bd.Deletar(id);
            return RedirectToAction("Index");
        }

    }
}
