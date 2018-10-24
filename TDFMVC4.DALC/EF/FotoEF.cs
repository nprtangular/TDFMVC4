using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDFMVC4.Common.Interfaces;
using TDFMVC4.Common.Models;
using TDFMVC4.DALC.Context;

namespace TDFMVC4.DALC.EF
{
    public class FotoEF : IFoto
    {
        public void agregarFoto(Foto foto)
        {
            using (var ctx = new ModelTDFMVC4())
            {
                Foto f = new Foto();
                f.Imagen = foto.Imagen;
                f.Descripcion = foto.Descripcion;
                f.CuentaId = foto.CuentaId;

                ctx.Fotos.Add(foto);
                ctx.SaveChanges();
            }
        }

        public void eliminarFoto(int Id)
        {
            using (var ctx = new ModelTDFMVC4())
            {
                var foto = ctx.Fotos.SingleOrDefault(f => f.Id == Id);
                ctx.Fotos.Remove(foto);
                ctx.SaveChanges();
            }
        }

        public List<Foto> listarFotosPorId(int usuarioId)
        {
            using (var ctx = new ModelTDFMVC4())
            {
                var listaFotos = ctx.Fotos.Where(f => f.CuentaId == usuarioId).ToList();
                return listaFotos;
            }
        }

        public List<Foto> listarFotosPorNombreUsuario(string NombreUsuario)
        {
            using (var ctx = new ModelTDFMVC4())
            {
                List<Cuenta> cuentaUsuario = ctx.Cuentas
                                    .Where(c => c.NombreUsuario == NombreUsuario)
                                    .ToList();

                var listaDeFotos = new List<Foto>();

                foreach (var item in cuentaUsuario)
	            {
                    var listaFotos = ctx.Fotos                                    
                                    .Where(f => f.CuentaId  == item.Id)
                                    .ToList();

                    return listaFotos;
	            }

                return null;
            }
        }
    }
}
