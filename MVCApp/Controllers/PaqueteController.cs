using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio;
namespace MVCApp.Controllers
{
    public class PaqueteController : Controller
    {
        Empresa unE = Empresa.Instancia;
        // GET: Paquete
        public ActionResult Index()
        {
            ViewBag.paquetes = unE.ListarPaquetes();
            ViewBag.usuarioLogin = unE.LoggedIn;
            ViewBag.rolUsuario = (string)Session["UserRol"];

            return View();
        }

        public ActionResult MayorPrecio(decimal paquetePrecio)
        {
            //esto lo ve solo el OPERADOR

            if (Session["LoggedIn"] == null || !(bool)Session["LoggedIn"])
            {
                return Redirect("/login/index");
            }

            //si el usuario no es operador, NO DEBERIA VERLO, aunque si lo hace, se ve una lista VACIA
            if (Session["LoggedIn"] != null && Session["UserRol"].ToString() != Dominio.User.ROL_OPERADOR)
            {
                Session["error"] = "ERROR: Rol no valido por favor loguearse nuevamente";
                return RedirectToAction("Error", "Error");
            }

            if ((string)Session["UserRol"] == Dominio.User.ROL_OPERADOR)
            {
                ViewBag.paquetes = unE.PaquetesMayorPrecio(paquetePrecio);
            }

            ViewBag.usuarioLogin = unE.LoggedIn;

            //Este viewbag sirve para mostrar en el HTML segun tipo de usuario diferenciado
            //lo que se muestra o no, segun el ron
            //!! luego de que este logueado!!
            ViewBag.usuarioRol = Session["UserRol"];

            return View("Index");
        }

        public ActionResult CanalesEnPaquete(string nombreCanal)
        {
            //esto lo ven todos

            if (Session["LoggedIn"] == null || !(bool)Session["LoggedIn"])
            {
                return Redirect("/login/index");
            }

            //si el usuario no es operador, NO DEBERIA VERLO, aunque si lo hace, se ve una lista VACIA
            if (Session["LoggedIn"] != null && Session["UserRol"].ToString() != Dominio.User.ROL_OPERADOR)
            {
                Session["error"] = "ERROR: Rol no valido por favor loguearse nuevamente";
                return RedirectToAction("Error", "Error");
            }
            //si es operador, ve los canales en paquetes
            if ((string)Session["UserRol"] == Dominio.User.ROL_OPERADOR)
            {
                ViewBag.paquetes = unE.CanalesEnPaquete(nombreCanal);
            }

            ViewBag.usuarioLogin = unE.LoggedIn;
            ViewBag.usuarioRol = Session["UserRol"];
            return View("Index");
        }

        // toda info paquete....
        public ActionResult Carrito(string nombrePaquete)
        {
            Paquete paquete = unE.BuscarPaquete(nombrePaquete);
            //ViewBag.paquete = unE.BuscarPaquete(nombrePaquete);



            return View(paquete);
        }

    }
}