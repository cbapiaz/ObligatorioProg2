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
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            Session["UserName"] = null;
            Session["UserRol"] = null;
            Session["LoggedIn"] = false;
            return View();
        }

        //ingresar usuario existente al sistema
        public ActionResult Ingresar(string username, string pass)
        {
            User user = Empresa.Instancia.BuscarUsuario(username, pass);
            if (user != null)
            {

                Session["UserName"] = user.NombreUsuario;
                Session["UserRol"] = user.Rol;
                Session["LoggedIn"] = true;
                //todo: check this redirection
                return RedirectToAction("Index", "Canal");
            }
            else
            {
                ViewBag.MensajeError = "Error de Login";
                return View("Index");
            }
        }

    }
}