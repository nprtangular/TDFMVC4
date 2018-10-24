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
    public class UsuarioController : Controller
    {
        //
        // GET: /Chica/

        public ActionResult Index()
        {
            //FacadeCuenta facA = new FacadeCuenta();
            //var listarUsuarios = facA.listarUsuario();
            //return View(listarUsuarios);
            return View();
        }

        public ActionResult Fotos(string NombreUsuario)
        {
            meteAViewBagSession();
            FacadeFoto facA = new FacadeFoto();
            var listaFotos = facA.listarFotosPorNombreUsuario(NombreUsuario);
            ViewBag.ListaFotos = listaFotos;

            return View();
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
