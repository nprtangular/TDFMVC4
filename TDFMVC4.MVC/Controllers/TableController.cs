using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using TDFMVC4.BL.Facade;
using TDFMVC4.Common.Models;
using TDFMVC4.Common.Sessions;

namespace TDFMVC4.MVC.Controllers
{
    public class TableController : Controller
    {
        //
        // GET: /Table/

        public ActionResult Index()
        {
            meteAViewBagSession();       
            FacadeEstado facAEstado = new FacadeEstado();
            var listaEstados = facAEstado.obtenerEstados();

            ViewBag.ListaEstados = listaEstados;                       
            return View();
        }

        public ActionResult Buscar(int estadoId)
        {
            meteAViewBagSession();       
            FacadeTable facATable = new FacadeTable();
            var estado = estadoId;
       
            var listaTables = facATable.listarTablesPorEstadoConFoto(estado);

            if (listaTables == null)
            {
                return RedirectToAction("Index", "Table");
            }
            else
            {
                ViewBag.ListaTables = listaTables;
                return View();
            }            
        }

        public ActionResult Perfil(int Id)
        {
            meteAViewBagSession();  
            var usuarioId = Id;
            FacadeCuenta facA = new FacadeCuenta();
            var model = facA.obtenerCuentaPorId(Id);
            
            return View(model);        
        }

        public ActionResult BuscarTableChica(int estadoId)
        {
            meteAViewBagSession();

            var sessionCuenta = Session[SessionConst.CurrentSessionKey] as Cuenta;
            var Id = sessionCuenta.Id;

            FacadeAsignarTable facAAsignarTable = new FacadeAsignarTable();
            var chicaId = Id;
            var verificarSiChicaTieneTable = facAAsignarTable.verificarSiChicaTieneTableAsignado(chicaId);

            if (verificarSiChicaTieneTable == null)
            {
                FacadeTable facATable = new FacadeTable();
                var estado = estadoId;
                var listaTables = facATable.listarTablesPorEstadoConFoto(estado);

                if (listaTables == null)
                {
                    return RedirectToAction("Index", "Table");
                }
                else
                {
                    ViewBag.ListaTables = listaTables;
                    ViewBag.VerificarSiChicaTieneTable = false;
                    return View();
                }
            }
            else
            {
                FacadeTable facATable = new FacadeTable();
                var estado = estadoId;
                var listaTables = facATable.listarTablesPorEstadoConFoto(estado);

                if (listaTables == null)
                {
                    return RedirectToAction("Index", "Table");
                }
                else
                {
                    List<Cuenta> tableConAsignacion = facATable.obtenerTableAsignadoAChica(chicaId);
                        
                    ViewBag.TableActual = tableConAsignacion; 
                    ViewBag.ListaTables = listaTables;
                    ViewBag.VerificarSiChicaTieneTable = true;
                    return View();
                }                               
            }            
        }

        public ActionResult Seleccionar()
        {
            meteAViewBagSession();        
            var facAEstado = new FacadeEstado();
            var listaEstados = facAEstado.obtenerEstados();
            ViewBag.ListaEstados = listaEstados;    
            return View();
        }

        public ActionResult AsignarChicaTable(int Id)
        {
            var cuentaSession = Session[SessionConst.CurrentSessionKey] as Cuenta;
            var usuarioId = cuentaSession.Id;

            FacadeAsignarTable facA = new FacadeAsignarTable();
            var tableId = Id;
            facA.AsignarTable(usuarioId, tableId);

            return RedirectToAction("Seleccionar", "Table");
        }

        public ActionResult DesasignarChicaTable(int Id)
        {
            var cuentaSession = Session[SessionConst.CurrentSessionKey] as Cuenta;
            var chicaId = cuentaSession.Id;

            FacadeAsignarTable facA = new FacadeAsignarTable();
            var tableId = Id;
            facA.DesasignarTable(chicaId, tableId);

            return RedirectToAction("Seleccionar", "Table");
        }

        public ActionResult Fotos(int Id)
        {
            meteAViewBagSession();
            FacadeCuenta facA = new FacadeCuenta();
            var model = facA.obtenerCuentaPorId(Id);

            
            var usuarioId = Id;
            FacadeFoto facAFoto = new FacadeFoto();
            var listaFotos = facAFoto.listarFotosPorId(usuarioId);
            ViewBag.ListaFotos = listaFotos;

            return View(model);        
        }


        public ActionResult Opiniones(int Id)
        {
            meteAViewBagSession();        
            var usuarioId = Id;
            var cuentaId = Id;
            FacadePost facA = new FacadePost();
            var listaDeComentarios = facA.obtenerPostPorUsuarioId(usuarioId);
            var listaDeComentariosConFoto = facA.listarPostsPorUsuarioIdConFoto(usuarioId);

            ViewBag.ListaDeComentarios = listaDeComentariosConFoto;
                        
            //var post = facA.obtenerPostPorUsuarioId(Id);
            Post post = new Post();

            FacadeCuenta facACuenta = new FacadeCuenta();
            var cuenta = facACuenta.obtenerCuentaPorId(cuentaId);
            ViewBag.Cuenta = cuenta;

            return View(post);
        }

        [HttpPost]
        public ActionResult Opiniones(int Id,
                                      string DescripcionPost)
        {
            meteAViewBagSession();
            var sessionCuenta = Session[SessionConst.CurrentSessionKey] as Cuenta;
            var UsuarioId = sessionCuenta.Id;

            var RecipienteId = Id;
            FacadePost facA = new FacadePost();
            Post post = new Post();

            post.CuentaId = UsuarioId;
            post.DescripcionPost = DescripcionPost;
            post.UsuarioId = UsuarioId;
            post.RecipienteId = RecipienteId;
            post.TimeStamp = DateTime.Now;
            
            facA.agregarPost(post);


            return RedirectToAction("Seleccionar", "Table");
        }

        
        public ActionResult Chicas(int? Id)        
        {
            meteAViewBagSession();
            var sessionCuenta = Session[SessionConst.CurrentSessionKey] as Cuenta;
            var TableId = 0;


            FacadeTable facA = new FacadeTable();
            FacadeCuenta facACuenta = new FacadeCuenta();

            if (Id == null)
            {
                TableId = sessionCuenta.Id;
            }
            else
            {
                var IdSiNoEsNulo = Id ?? default(int);
                TableId = IdSiNoEsNulo;
                int cuentaId = TableId;
                var cuenta = facACuenta.obtenerCuentaPorId(cuentaId);
                ViewBag.NombreTable = cuenta.Table.NombreTable;
            }
                        
            var listaChicas = facA.obtenerChicasConFotos(TableId);
            ViewBag.ListaChicas = listaChicas;
                                                                                
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

            try
            {
                ViewBag.NombreTable = cuenta.Table.NombreTable;
            }
            catch (Exception)
            {
                var x = 0;    
            }

        }


        //********************************* ANGULAR  *********************************

        public JsonResult ListarPostsJson()
        {             
            FacadePost facA = new FacadePost();
            //var c = facA.listarPostsPorUsuarioIdConFoto(2); //2 la Doña

            Cuenta x = facA.obtenerPostPorUsuarioIdConFoto(3); //3 la Quebradita

   

            //Probar con un objeto de la clase

            return new JsonResult { Data = x, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult ListarPostsJson2()
        {
            meteAViewBagSession();
            return View();
        }
         

        //********************************* ANGULAR  *********************************


    }
}

