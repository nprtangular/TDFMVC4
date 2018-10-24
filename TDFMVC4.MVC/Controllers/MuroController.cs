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
    public class MuroController : Controller
    {
        //
        // GET: /Muro/

        public ActionResult Index()
        {
            var cuentaSession = Session[SessionConst.CurrentSessionKey] as Cuenta;
            FacadeChica facA = new FacadeChica();
            var usuarioId = cuentaSession.Id;
            var chicaId = usuarioId;

            if (cuentaSession == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if (cuentaSession.TipoUsuario == 1)
                {
                    FacadeAsignarTable facAAsignarTable = new FacadeAsignarTable();
                    var verificarSiChicaTieneTable = facAAsignarTable.verificarSiChicaTieneTableAsignado(chicaId);

                    if (verificarSiChicaTieneTable == null)
                    {
                    }
                    else
                    {
                        FacadeTable facATable = new FacadeTable();
                        List<Cuenta> tableTrabajo = facATable.obtenerDondeTrabajaChicaLista(chicaId);

                        ViewBag.TableTrabajo = tableTrabajo;
                        ViewBag.VerificarSiChicaTieneTable = true;
                    }

                }
                else if (cuentaSession.TipoUsuario == 2)
                {
                    var cuentasChicas = facA.listarChicaInnerFotosPorUsuario(usuarioId);
                    ViewBag.CuentasChicas = cuentasChicas;
                }
                else if (cuentaSession.TipoUsuario == 3)
                {

                }
            }

            var NombreUsuario = cuentaSession.NombreUsuario;
            ViewBag.NombreUsuario = NombreUsuario;
            ViewBag.TipoUsuario = cuentaSession.TipoUsuario;
            return View(cuentaSession);
        }

    }
}
