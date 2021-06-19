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
            return View();
        }


        //alta
       /* [HttpGet]
        [HttpPost]*/
        public ActionResult Registrar(User user)
        {
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

        [HttpPut]
        public ActionResult Modificacion()
        {

            return View();
        }

        [HttpDelete]
        public ActionResult Borrado()
        {

            return View();
        }


    }
}