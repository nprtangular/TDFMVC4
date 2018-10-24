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
    public class ChicaController : Controller
    {
        //
        // GET: /Chica/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Perfil(string NombreUsuario)
        {
            meteAViewBagSession();            
            FacadeCuenta facA = new FacadeCuenta();
            var model = facA.obtenerCuentaPorNombreUsuario(NombreUsuario);

            var chicaId = model.Id;
            
            FacadeTable facATable = new FacadeTable();
            Cuenta tableTrabajo = facATable.obtenerDondeTrabajaChica(chicaId);
            ViewBag.TableTrabajo = tableTrabajo;
            return View(model);
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

        public ActionResult Fotos(string NombreUsuario)
        {
            meteAViewBagSession();            
            FacadeFoto facA = new FacadeFoto();
            var listaFotos = facA.listarFotosPorNombreUsuario(NombreUsuario);
            ViewBag.ListaFotos = listaFotos;

            return View();
        }


    }
}
