using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApp.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Listado()
        {
            //esto lo ve solo el OPERADOR
            if (Session["LoggedIn"] == null || !(bool)Session["LoggedIn"])
            {
                return Redirect("/login/index");
            }

            //si el usuario no es operador, NO DEBERIA VERLO, aunque si lo hace, se ve una lista VACIA
            if (Session["LoggedIn"] != null && (string)Session["UserRol"] != Dominio.User.ROL_OPERADOR)
            {
                ViewBag.usuarios = new List<User>();
                Session["error"] = "ERROR: Usuario no tiene permisos para acceder";
                return RedirectToAction("Error", "Error");
            }

            ViewBag.usuarios= Empresa.Instancia.ListaUsuariosClientes();

            return View();
        }

        public ActionResult ComprasFilter(int ultimosDias)
        {
            ViewBag.usuarios = Empresa.Instancia.ListaClientesCompraPorDias(ultimosDias);

            return View("Listado");
        }

        public ActionResult Registrar(User user)
        {
            //si el usuario ya esta logueado, va hacia el listado
            if (Session["LoggedIn"] != null && (bool)Session["LoggedIn"])
            {
                return Redirect("/paquete/index");
            }

            ViewBag.ErrorMessage = null;
            ViewBag.Message = null;
            if (user!= null && user.Rol!=null)
            {
                User userExistente = Empresa.Instancia.BuscarUsuario(user.NombreUsuario, user.Password);
                string err = "";
                if (userExistente != null)
                {
                     ViewBag.ErrorMessage="Usuario ya existe";
                }
                else if(!Empresa.Instancia.AltaUsuario(user,out err))
                {
                       ViewBag.ErrorMessage = err;
                }
                else
                {
                    ViewBag.Message = "Usuario dado de alta exitosamente";
                }

            }
            return View(user);
        }

    }
}