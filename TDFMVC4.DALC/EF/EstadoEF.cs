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
    public class EstadoEF : IEstado
    {
        public void agregarEstado(Estado estado)
        {
            using (var ctx = new ModelTDFMVC4())
            {
                Estado e = new Estado()
                {
                    Nombre = estado.Nombre
                };

                ctx.Estados.Add(e);
                ctx.SaveChanges();
            }
        }


        public List<Estado> obtenerEstados()
        {
            using (var ctx = new ModelTDFMVC4())
            {
                List<Estado> estados = new List<Estado>();
                estados = ctx.Estados.ToList();
                ctx.SaveChanges();
                return estados;                
            }
        }
    }
}
