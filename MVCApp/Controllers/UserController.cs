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

        /**ABM - Usuario**/

        //listado usuario
        //alta usuario
        //modificacion usuario
        //borrado usuario

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
                Session["error"] = "ERROR: Rol no valido por favor loguearse nuevamente";
                return RedirectToAction("Error", "Error");
            }

            //aun falta el viewbag con la lista en si
            //TODO: List

            return View();
        }


        //alta
       /* [HttpGet]
        [HttpPost]*/
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

                if (userExistente != null)
                {
                     ViewBag.ErrorMessage="Usuario ya existe";
                }
                else if(!Empresa.Instancia.AltaUsuario(user))
                {
                       ViewBag.ErrorMessage = "Error al dar de alta el usuario";
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