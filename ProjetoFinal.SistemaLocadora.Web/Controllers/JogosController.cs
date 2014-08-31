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
    public class JogosController : Controller
    {
        private Contexto _contexto;
        private JogoBancoDados _bd;

        public JogosController()
        {
            this._contexto = new Contexto("SistemaLocadora");
            this._bd = new JogoBancoDados(this._contexto);
        }
        //
        // GET: /Jogos/

        public ActionResult Index()
        {
            var lista = this._bd.LocalizarTodas();
            return View(lista);
        }
        public ActionResult Cadastrar()
        {
            var listaCateg = (from c in this._contexto.TabelaCategorias
                         select c).ToList();

            ViewBag.Categoria = new SelectList(listaCateg, "Id", "Nome");

            var listaConsole = (from c in this._contexto.TabelaPlataformas
                         select c).ToList();

            ViewBag.Console = new SelectList(listaConsole, "Id", "Console");
            return View();
        }
        [HttpPost]
        public ActionResult Cadastrar(Jogo novoJogo, HttpPostedFileBase arquivo)
        {
            CategoriaBancoDados bancoCateg = new CategoriaBancoDados(this._contexto);
            Categoria c = new Categoria();
            c = bancoCateg.LocalizarId(novoJogo.Categoria.Id);
            novoJogo.Categoria = c;

            PlataformaBancoDados bancoConsole = new PlataformaBancoDados(this._contexto);
            Plataforma d = new Plataforma();
            d = bancoConsole.LocalizarId(novoJogo.Console.Id);
            novoJogo.Console = d;

            if (arquivo != null && arquivo.ContentLength > 0)
            {
                var nomeArquivo = Path.GetFileName(arquivo.FileName);
                var caminho = Path.Combine(Server.MapPath("~/Content/images"), nomeArquivo);
                arquivo.SaveAs(caminho);
                novoJogo.Imagem = "~/Content/images/" + nomeArquivo;
            }
            else
            {
                novoJogo.Imagem = "#";
            }

            this._bd.Inserir(novoJogo);
            return RedirectToAction("Index");
        }
        public ActionResult Editar(int id)
        {
            var resultado = this._bd.LocalizarId(id);

            var listaCateg = (from c in this._contexto.TabelaCategorias
                         select c).ToList();
            ViewBag.Categoria = new SelectList(listaCateg, "Id", "Nome", resultado.Categoria.Id);

            var listaConsole = (from c in this._contexto.TabelaPlataformas
                         select c).ToList();
            ViewBag.Console = new SelectList(listaConsole, "Id", "Console", resultado.Console.Id);

            return View(resultado);
        }
        [HttpPost]
        public ActionResult Editar(Jogo jogoEditado, HttpPostedFileBase arquivo)
        {
            CategoriaBancoDados bancoCateg = new CategoriaBancoDados(this._contexto);
            Categoria c = new Categoria();
            c = bancoCateg.LocalizarId(jogoEditado.Categoria.Id);
            jogoEditado.Categoria = c;

            PlataformaBancoDados bancoConsole = new PlataformaBancoDados(this._contexto);
            Plataforma d = new Plataforma();
            d = bancoConsole.LocalizarId(jogoEditado.Console.Id);
            jogoEditado.Console = d;

            Jogo jogo = this._bd.LocalizarId(jogoEditado.Id);
            jogo.Categoria = c;
            jogo.Console = d;
            jogo.Desenvolvedora = jogoEditado.Desenvolvedora;
            jogo.Id = jogoEditado.Id;
            jogo.Nome = jogoEditado.Nome;
            jogo.Valor = jogoEditado.Valor;

            if (arquivo != null && arquivo.ContentLength > 0)
            {
                var nomeArquivo = Path.GetFileName(arquivo.FileName);
                var caminho = Path.Combine(Server.MapPath("~/Content/images"), nomeArquivo);
                arquivo.SaveAs(caminho);
                jogo.Imagem = "~/Content/images/" + nomeArquivo;
            }

            this._bd.Editar(jogo);
            return RedirectToAction("Index");
        }
        public ActionResult Deletar(int id)
        {
            this._bd.Deletar(id);
            return RedirectToAction("Index");
        }
    }
}
