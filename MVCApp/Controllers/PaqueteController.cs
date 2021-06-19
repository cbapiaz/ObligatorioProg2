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
            return View();
        }

        public ActionResult MayorPrecio(decimal paquetePrecio)
        {
            if (Session["LoggedIn"] == null || !(bool)Session["LoggedIn"])
            {
                return Redirect("/login/index");
            }

            ViewBag.paquetes = unE.PaquetesMayorPrecio(paquetePrecio);
            ViewBag.usuarioLogin = unE.LoggedIn;
            return View("Index");
        }

        public ActionResult CanalesEnPaquete(string nombreCanal)
        {

            if (Session["LoggedIn"] == null || !(bool)Session["LoggedIn"])
            {
                return Redirect("/login/index");
            }


            ViewBag.paquetes = unE.CanalesEnPaquete(nombreCanal);
            ViewBag.usuarioLogin = unE.LoggedIn;
            return View("Index");
        }
    }
}