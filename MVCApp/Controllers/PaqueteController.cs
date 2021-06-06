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
        Empresa unP = Empresa.Instancia;
        // GET: Paquete
        public ActionResult Index()
        {
            ViewBag.paquetes = unP.ListarPaquetes();
            return View();
        }
    }
}