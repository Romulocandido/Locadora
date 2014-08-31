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
    public class AccountController : Controller
    {
        private Contexto _contexto;
        private UserApplication _bd;

        public AccountController()
        {
            this._contexto = new Contexto("SistemaLocadora");
            this._bd = new UserApplication(this._contexto);
        }
        //
        // GET: /AccountController/
        
        SessionContext context = new SessionContext();
        public ActionResult Login()
        {
            SessionContext login = new SessionContext();

            if (login.logado() == true)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
        [HttpPost]
        public ActionResult Login(Usuario user)
        {
            UserApplication userApp = new UserApplication(this._contexto);
            var authenticatedUser = userApp.GetByUsernameAndPassword(user);

            SessionContext login = new SessionContext();

            Usuario usuario = (from p in this._contexto.TabelaUsuarios
                            where p.Username == user.Username
                            select p).FirstOrDefault();
       
            if ((authenticatedUser != null) & (login.logado() == false))
            {
                context.SetAuthenticationToken(authenticatedUser.Name, false, authenticatedUser);
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Error = "Login inválido, tente novamente!";
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}
