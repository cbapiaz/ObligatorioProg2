﻿using Dominio;
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


        private void populate()
        {
            Compra c = emp.AgregarNuevaCompra("45042994", DateTime.Now.AddMonths(-2), new List<string>() { "paqueteHD1", "paqueteSD1" });
            Compra c2 = emp.AgregarNuevaCompra("45042994", DateTime.Now.AddDays(2), new List<string>() { "paqueteHD2", "paqueteSD2" });

        }

        // GET: Compra
        public ActionResult Index()
        {
            populate();
           
            ViewBag.IdCompra = 1;

            if (Session["LoggedIn"] == null || !(bool)Session["LoggedIn"])
            {
                return Redirect("/login/index");
            }

            if (Session["UserRol"]!= null && Session["UserRol"].ToString() == Dominio.User.ROL_OPERADOR) {
                ViewBag.Compras = emp.ListarCompras();
                ViewBag.Total = emp.TotalCompras();
                ViewBag.Start = DateTime.Now.ToString("yyyy-MM-ddThh:mm");
                ViewBag.End = DateTime.Now.ToString("yyyy-MM-ddThh:mm");
                return View();
            }
            else
            {
                Session["error"] = "ERROR: Rol no valido por favor loguearse nuevamente";
                return RedirectToAction("Error", "Error");
            }
        }

        public ActionResult MisCompras()
        {
            ViewBag.usuarioLogin = (bool)Session["LoggedIn"];
            ViewBag.rolUsuario = Session["UserRol"].ToString();


            if (Session["UserRol"] != null && Session["UserRol"].ToString() == Dominio.User.ROL_CLIENTE)
            {
                Dominio.User usuario = emp.BuscarUsuario(Session["UserName"].ToString());
                ViewBag.usuario = usuario;
                ViewBag.misCompras = usuario.Compras;
                return View();
            }
            else
            {
                Session["error"] = "ERROR: Rol no valido por favor loguearse nuevamente";
                return RedirectToAction("Error", "Error");
            }
        }

        public ActionResult Filtrar(DateTime start, DateTime end)
        {

            if (Session["UserRol"] != null && Session["UserRol"].ToString() == Dominio.User.ROL_OPERADOR)
            {
                ViewBag.Compras = emp.ListarCompras(start,end);
                ViewBag.Total = emp.TotalCompras(start, end);
                ViewBag.Start = start.ToString("yyyy-MM-ddThh:mm");
                ViewBag.End = end.ToString("yyyy-MM-ddThh:mm");
                return View("Index");
            }
            else
            {
                throw new Exception("Error Rol no valido");
            }
        }

        //public ActionResult TerminarCompra(string nomPaquete)
        //{

        //}

        /*public ActionResult TerminarCompra(int idCompra, List<int> idPaquete)
        {
           // emp.AgregarPaqueteCompra(idCompra, idPaquete);
        } */
    }
}