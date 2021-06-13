using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio;
namespace MVCApp.Controllers
{
    public class CanalController : Controller
    {
        Empresa unE =Empresa.Instancia;
        // GET: Canal
        public ActionResult Index()
        {
            ViewBag.canales = unE.ListarCanales();
            ViewBag.usuarioLogin = unE.LoggedIn;
            return View();
        }

    }
}