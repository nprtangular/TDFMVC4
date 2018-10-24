using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TDFMVC4.BL.Facade;
using TDFMVC4.Common.Models;
using TDFMVC4.Common.Sessions;

namespace TDFMVC4.MVC.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Registrar/

        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(string correo,
                                  string contrasena)
        {
            FacadeLogin facA = new FacadeLogin();
            
            var validacion = facA.validarLogin(correo, contrasena);
            string mensaje = "";
            if (validacion == false)
            {
                mensaje = "El nombre de correo o contraseña es invalido";
                return RedirectToAction("Index", new { Mensaje = mensaje });
            }
            else
            {
                FacadeCuenta facACuenta = new FacadeCuenta();
                var cuentaSession = facACuenta.obtenerCuentaPorCorreo(correo);
                Session[SessionConst.CurrentSessionKey] = cuentaSession;
                
                return RedirectToAction("Index", "Muro");

            }

        }


        public ActionResult LogOut()
        {
            Session[SessionConst.CurrentSessionKey] = null;
            return RedirectToAction("Index", "Home");
        }

    }
}
