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
    public class PerfilController : Controller
    {
        //
        // GET: /Perfil/

        public ActionResult Index()
        {
            var sessionCuenta = Session[SessionConst.CurrentSessionKey] as Cuenta;
            var Id = sessionCuenta.Id;

            FacadeCuenta facA = new FacadeCuenta();
            var cuenta = facA.obtenerCuentaPorId(Id);

            ViewBag.NombreUsuario = cuenta.NombreUsuario;
            ViewBag.TipoUsuario = cuenta.TipoUsuario;
            return View(cuenta);
        }

        public ActionResult EditarNombreArtistico(int Id)
        {
            FacadeCuenta facA = new FacadeCuenta();
            var cuenta = facA.obtenerCuentaPorId(Id);

            ViewBag.Cuenta = cuenta;
            ViewBag.TipoUsuario = cuenta.TipoUsuario;

            return View(cuenta);
        }

        [HttpPost]
        public ActionResult EditarNombreArtistico(int Id,
                                   Chica chica,
                                   Usuario usuario,
                                   Table table)
        {
            FacadeCuenta facA = new FacadeCuenta();
            var c = facA.obtenerCuentaPorId(Id);
            
            if (c.TipoUsuario == 1)
            {
                Cuenta cuenta = new Cuenta()
                {
                    Id = Id,
                    TipoUsuario = c.TipoUsuario,

                    Chica = new Chica()
                    {
                        Id = c.Chica.Id,
                        NombreArtistico = chica.NombreArtistico
                    },

                };
                facA.editarPerfil(cuenta);
            }
            if (c.TipoUsuario == 2)
            {
                Cuenta cuenta = new Cuenta()
                {
                    Id = Id,
                    TipoUsuario = c.TipoUsuario,

                    Usuario = new Usuario()
                    {
                        Id = c.Usuario.Id,
                        LugarNacimiento = usuario.LugarNacimiento 
                    },

                };
                facA.editarPerfil(cuenta);
            
            }
            if (c.TipoUsuario == 3)
            {
                Cuenta cuenta = new Cuenta()
                {
                    Id = Id,
                    TipoUsuario = c.TipoUsuario,

                    Table = new Table()
                    {
                        Id = c.Table.Id,
                        ChicasEnEscena = table.ChicasEnEscena 
                    },
                };
                facA.editarPerfil(cuenta);
            }
                                    
            return RedirectToAction("Index", "Perfil");
        
        }



        public ActionResult UsuarioEditarLugarDeNacimiento(string NombreUsuario)
        {
            FacadeCuenta facA = new FacadeCuenta();
            var model = facA.obtenerCuentaPorNombreUsuario(NombreUsuario);
            return View(model);
        }

        public ActionResult TableEditarChicasEnEscena(string NombreUsuario)
        {
            FacadeCuenta facA = new FacadeCuenta();
            var model = facA.obtenerCuentaPorNombreUsuario(NombreUsuario);
            return View(model);
        }



        [HttpPost]
        public ActionResult UsuarioEditarLugarDeNacimiento(Cuenta cuenta)
        {
            FacadeCuenta facA = new FacadeCuenta();
            var cuentaId = cuenta.Id;
            var cuentaUsuario = facA.obtenerCuentaPorId(cuentaId);

            Cuenta cuentaEntity = new Cuenta()
            {
                Id = cuenta.Id,
                TipoUsuario = cuentaUsuario.TipoUsuario,                
                Usuario = new Usuario()
                {
                    Id = cuentaUsuario.Usuario.Id,
                    LugarNacimiento = cuenta.Usuario.LugarNacimiento                    
                },
            };
            facA.editarPerfil(cuentaEntity);
            return RedirectToAction("Index", "Perfil");
        }


        [HttpPost]
        public ActionResult TableEditarChicasEnEscena(Cuenta cuenta)
        {
            FacadeCuenta facA = new FacadeCuenta();
            var cuentaId = cuenta.Id;
            var cuentaUsuario = facA.obtenerCuentaPorId(cuentaId);

            Cuenta cuentaEntity = new Cuenta()
            {
                Id = cuenta.Id,
                TipoUsuario = cuentaUsuario.TipoUsuario,
                Table = new Table()
                {
                    Id = cuentaUsuario.Table.Id,
                    ChicasEnEscena = cuenta.Table.ChicasEnEscena
                },
            };
            facA.editarPerfil(cuentaEntity);
            return RedirectToAction("Index", "Perfil");
        }


    }
}
