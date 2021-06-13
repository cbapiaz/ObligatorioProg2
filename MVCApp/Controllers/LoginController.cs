using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApp.Controllers
{
    //manejo de usuarios....
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            ViewBag.usuarioLogin = Empresa.Instancia.LoggedIn;
            return View();
        }

        //ingresar usuario existente al sistema
        public ActionResult Ingresar(string user, string pass)
        {
            //implementar login por usuario o cliente
            Empresa.Instancia.LoggedIn = true;
            return RedirectToAction("Index", "Canal");
        }
    }
}