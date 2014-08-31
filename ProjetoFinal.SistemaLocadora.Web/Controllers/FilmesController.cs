using ProjetoFinal.SistemaLocadora.BancoDados;
using ProjetoFinal.SistemaLocadora.Dominio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoFinal.SistemaLocadora.Web.Controllers
{
    [Authorize]
    public class FilmesController : Controller
    {
        //
        // GET: /Filme/
        private Contexto _contexto;
        private FilmeBancoDados _bd;

        public FilmesController()
        {
            this._contexto = new Contexto("SistemaLocadora");
            this._bd = new FilmeBancoDados(this._contexto);
        }
        public ActionResult Index()
        {
            var lista = this._bd.LocalizarTodas();
            return View(lista);
        }
        public ActionResult Cadastrar()
        {
            var lista = (from c in this._contexto.TabelaCategorias
                         select c).ToList();

            ViewBag.Categoria = new SelectList(lista, "Id", "Nome");
            return View();
        }
        [HttpPost]
        public ActionResult Cadastrar(Filme novoFilme, HttpPostedFileBase arquivo)
        {
            CategoriaBancoDados banco = new CategoriaBancoDados(this._contexto);
            Categoria c = new Categoria();
            c = banco.LocalizarId(novoFilme.Categoria.Id);

            novoFilme.Categoria = c;
            novoFilme.Imagem = "#";

            if (arquivo != null && arquivo.ContentLength > 0)
            {
                var nomeArquivo = Path.GetFileName(arquivo.FileName);
                var caminho = Path.Combine(Server.MapPath("~/Content/images"), nomeArquivo);
                arquivo.SaveAs(caminho);
                novoFilme.Imagem = "~/Content/images/" + nomeArquivo ;
            }
           

            this._bd.Inserir(novoFilme);

            return RedirectToAction("Index");
        }
        public ActionResult Editar(int id)
        {
            var resultado = this._bd.LocalizarId(id);
            var lista = (from c in this._contexto.TabelaCategorias
                         select c).ToList();
            ViewBag.Categoria = new SelectList(lista, "Id", "Nome", resultado.Categoria.Id);

            return View(resultado);
        }
        [HttpPost]
        public ActionResult Editar(Filme filmeEditado, HttpPostedFileBase arquivo)
        {
            CategoriaBancoDados banco = new CategoriaBancoDados(this._contexto);
            Categoria c = new Categoria();
            c = banco.LocalizarId(filmeEditado.Categoria.Id);

            Filme filme = this._bd.LocalizarId(filmeEditado.Id);
            filme.Categoria = c;
            filme.Atores = filmeEditado.Atores;
            filme.Diretor = filmeEditado.Diretor;
            filme.Id = filmeEditado.Id;
            filme.Nome = filmeEditado.Nome;
            filme.Valor = filmeEditado.Valor;

            if (arquivo != null && arquivo.ContentLength > 0)
            {
                var nomeArquivo = Path.GetFileName(arquivo.FileName);
                var caminho = Path.Combine(Server.MapPath("~/Content/images"), nomeArquivo);
                arquivo.SaveAs(caminho);
                filme.Imagem = "~/Content/images/" + nomeArquivo;
            }

            this._bd.Editar(filme);
            return RedirectToAction("Index");
        }

        public ActionResult Deletar(int id)
        {
            this._bd.Deletar(id);
            return RedirectToAction("Index");
        }       

    }
}
