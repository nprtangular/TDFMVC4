using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TDFMVC4.BL.Facade;
using TDFMVC4.Common.Models;
using TDFMVC4.Common.Sessions;

namespace TDFMVC4.MVC.Controllers
{
    public class FotoController : Controller
    {
        //
        // GET: /Fotos/

        FacadeFoto facA = new FacadeFoto();

        public ActionResult Index()
        {
            Cuenta cuentaSession = Session[SessionConst.CurrentSessionKey] as Cuenta;
            var usuarioId = cuentaSession.Id;

            var listaFotos = facA.listarFotosPorId(usuarioId);

            ViewBag.ListaFotos = listaFotos;
            ViewBag.NombreUsuario = cuentaSession.NombreUsuario;
            ViewBag.TipoUsuario = cuentaSession.TipoUsuario;
            return View();
        }
        
        public ActionResult AgregarFoto(HttpPostedFileBase Imagen)
        {
            var fileName = Path.GetFileName(Imagen.FileName);
            fileName = DateTime.Now.ToString("ddMMyyyyHHmmss") + fileName;
            var ruta = Path.Combine(Server.MapPath("~/Content/Upload"), fileName);
            Imagen.SaveAs(ruta);

            Cuenta cuentaSession = Session[SessionConst.CurrentSessionKey] as Cuenta;
                        
            Foto foto = new Foto();

            foto.Imagen = "~/Content/Upload/" + fileName;
            foto.CuentaId = cuentaSession.Id;
            facA.agregarFoto(foto);

            return RedirectToAction("Index", "Foto");
        }

        public ActionResult AgregarFotoATable(HttpPostedFileBase Imagen,
                                              int Id)
        {
            var fileName = Path.GetFileName(Imagen.FileName);
            fileName = DateTime.Now.ToString("ddMMyyyyHHmmss") + fileName;
            var ruta = Path.Combine(Server.MapPath("~/Content/Upload"), fileName);
            Imagen.SaveAs(ruta);

            //Cuenta cuentaSession = Session[SessionConst.CurrentSessionKey] as Cuenta;
            Foto foto = new Foto();
            var tableId = Id;
            foto.Imagen = "~/Content/Upload/" + fileName;
            foto.CuentaId = tableId;
            facA.agregarFoto(foto);

            return RedirectToAction("Index", "Muro");
        }
        

        public ActionResult EliminarFoto(int Id)
        {
            Cuenta cuentaSession = Session[SessionConst.CurrentSessionKey] as Cuenta;
            var UsuarioId = cuentaSession.Id;

            facA.eliminarFoto(Id);
                   
            return RedirectToAction("Index", "Foto");
        }
    }
}
