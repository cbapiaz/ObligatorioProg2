using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApp.Controllers
{
    public class CompraController : Controller
    {
        Empresa emp = Empresa.Instancia;
        // GET: Compra
        public ActionResult Index()
        {
            Compra c=  emp.AgregarNuevaCompra("45042994", new List<string>() {"paqueteHD1","paqueteSD1" });
            Compra c2 = emp.AgregarNuevaCompra("45042994", new List<string>() { "paqueteHD2", "paqueteSD2" });

            ViewBag.IdCompra = c.Id;

            if (Session["UserRol"]!= null && Session["UserRol"].ToString() == Dominio.User.ROL_OPERADOR) {
                ViewBag.Compras = emp.ListarCompras();
                return View();
            }
            else
            {
                throw new Exception("Error Rol no valido");
            }
        }

        /*public ActionResult TerminarCompra(int idCompra, List<int> idPaquete)
        {
           // emp.AgregarPaqueteCompra(idCompra, idPaquete);
        } */
    }
}