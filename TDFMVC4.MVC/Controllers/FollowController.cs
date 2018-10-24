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
    public class FollowController : Controller
    {
        //
        // GET: /Seguidor/

        public ActionResult Index()
        {
            meteAViewBagSession();
            var cuentaSession = Session[SessionConst.CurrentSessionKey] as Cuenta;
            var UsuarioId = cuentaSession.Id;
            var usuarioId = cuentaSession.Id;

            var NombreUsuario = cuentaSession.NombreUsuario;
            FacadeFollow facA = new FacadeFollow();

            if (cuentaSession.TipoUsuario == 1)
            {
                List<Cuenta> seguidores = facA.obtenerSeguidoresConFotos(NombreUsuario, UsuarioId);
                ViewBag.ListaSeguidores = seguidores;
            }
            else if (cuentaSession.TipoUsuario == 2)
            {
                List<Cuenta> listaSiguiendo = facA.obtenerSiguiendoConFotos(NombreUsuario, UsuarioId);
                ViewBag.ListaSiguiendo = listaSiguiendo;
            }

            ViewBag.NombreUsuario = cuentaSession.NombreUsuario;
            ViewBag.TipoUsuario = cuentaSession.TipoUsuario;
            return View(cuentaSession);
        }

        //[HttpPost]
        public ActionResult Seguir(int Id)
        {

                var usuarioSession = Session[SessionConst.CurrentSessionKey] as Cuenta;
                var usuarioId = usuarioSession.Id;
                var cuentaId = Id;

                FacadeCuenta facA = new FacadeCuenta();
                var cuenta = facA.obtenerCuentaPorId(cuentaId);
                var seguidoId = cuenta.Id;

                FacadeFollow facAFollow = new FacadeFollow();
                facAFollow.Seguir(usuarioId, seguidoId);

                return RedirectToAction("Index", "Muro");       
        }

        public ActionResult DejarDeSeguir(int Id)
        {
            var seguidoId = Id;
            var usuarioSession = Session[SessionConst.CurrentSessionKey] as Cuenta;
            var usuarioId = usuarioSession.Id;
            
            FacadeFollow facAFollow = new FacadeFollow();
            facAFollow.DejarDeSeguir(usuarioId, seguidoId);

            return RedirectToAction("Index", "Muro");
            
        }


        private void meteAViewBagSession()
        {
            var sessionCuenta = Session[SessionConst.CurrentSessionKey] as Cuenta;
            var Id = sessionCuenta.Id;

            FacadeCuenta facA = new FacadeCuenta();
            var cuenta = facA.obtenerCuentaPorId(Id);

            ViewBag.NombreUsuario = cuenta.NombreUsuario;
            ViewBag.TipoUsuario = cuenta.TipoUsuario;
        }
        
    }
}
