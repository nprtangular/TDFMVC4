using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TDFMVC4.BL.Facade;
using TDFMVC4.Common.Models;

namespace TDFMVC4.MVC.Controllers
{
    public class RegistrarController : Controller
    {
        //
        // GET: /Registrar/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult IndexChica()
        {
            return View();
        }

        public ActionResult IndexTable()
        {
            FacadeEstado facAEstado = new FacadeEstado();
            var listaEstados = facAEstado.obtenerEstados();

            ViewBag.ListaEstados = listaEstados;

            return View();
        }

        public ActionResult IndexUsuario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistrarChica(string nombreUsuario,
                                           string nombreArtistico,
                                           string correo,
                                           string contrasena)
        {
            FacadeCuenta facA = new FacadeCuenta();
            Chica chica = new Chica();
            RegistrarChica registrarchica = new RegistrarChica();

            var validacion = facA.obtenerCuentaPorNombreDeCuenta(nombreUsuario);

            string mensaje = "";
            if (validacion != null)
            {
                mensaje = "Ya existe otro usuario con ese perfilId escoja otro";
                return RedirectToAction("Index", new { Mensaje = mensaje });
            }
            else
            {
                registrarchica.NombreArtistico = nombreArtistico;
                registrarchica.NombreUsuario = nombreUsuario;
                registrarchica.Correo = correo;
                registrarchica.Contrasena = contrasena;

                //**********************************************************
                registrarchica.TipoUsuario = 1;
                //**********************************************************

                facA.agregarChica(registrarchica);
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult RegistrarTable(string nombreUsuario,
                                           string nombreTable,
                                           int chicasEnEscena,
                                           decimal consumoXPersona,
                                           string telefonoReservacion,
                                           string correo,
                                           string contrasena,
                                           int estadoId)
        {
            FacadeCuenta facA = new FacadeCuenta();
            Table table = new Table();
            RegistrarTable registrarTable = new RegistrarTable();

            var nombreUsuarioTable = nombreUsuario;
            var validacion = facA.obtenerCuentaPorCorreo(correo);
            string mensaje = "";
            if (validacion != null)
            {
                mensaje = "Ya existe otro usuario con ese perfilId escoja otro";
                return RedirectToAction("Index", new { Mensaje = mensaje });
            }
            else
            {
                registrarTable.NombreUsuario = nombreUsuario;
                registrarTable.NombreTable = nombreTable;
                registrarTable.Correo = correo;
                registrarTable.Contrasena = contrasena;
                registrarTable.ChicasEnEscena = chicasEnEscena;
                registrarTable.EstadoId = estadoId;
                registrarTable.ConsumoXPersona = consumoXPersona;
                registrarTable.TelefonoReservacion = telefonoReservacion;

                //**********************************************************
                registrarTable.TipoUsuario = 3;
                //**********************************************************

                facA.agregarTable(registrarTable);
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult RegistrarUsuario(string nombreUsuario,
                                             string correo,
                                             string contrasena,
                                             string lugarDeNacimiento)
        {
            FacadeCuenta facA = new FacadeCuenta();
            Cuenta cuenta = new Cuenta();
            RegistrarUsuario registrarUsuario = new RegistrarUsuario();

            var validacion = facA.obtenerCuentaPorNombreDeCuenta(nombreUsuario);

            string mensaje = "";
            if (validacion != null)
            {
                mensaje = "Ya existe otro usuario con ese perfilId escoja otro";
                return RedirectToAction("Index", new { Mensaje = mensaje });
            }
            else
            {
                registrarUsuario.NombreUsuario = nombreUsuario;
                registrarUsuario.Correo = correo;
                registrarUsuario.Contrasena = contrasena;
                registrarUsuario.LugarDeNacimiento = lugarDeNacimiento;

                ////**********************************************************
                registrarUsuario.TipoUsuario = 2;
                ////**********************************************************

                facA.agregarUsuario(registrarUsuario);
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
