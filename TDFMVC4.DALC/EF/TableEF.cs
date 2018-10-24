using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDFMVC4.Common.Models;
using TDFMVC4.Common.Interfaces;
using TDFMVC4.DALC.Context;

namespace TDFMVC4.DALC.EF
{
    public class TableEF : ITable
    {
        
        public List<Cuenta> obtenerTableAsignadoAChica(int chicaId)
        {
            using (var ctx = new ModelTDFMVC4())
            {
                var asignacion = ctx.AsignarTables
                                    .SingleOrDefault(a => a.UsuarioId == chicaId);

                var table = ctx.Cuentas
                               .Include("Table")
                               .Where(t => t.Id == asignacion.TableId)                               
                               .ToList();
                return table;
            }
        }

        public List<Cuenta> obtenerChicasConFotos(int TableId)
        {
            using (var ctx = new ModelTDFMVC4())
            {
                var listaChicas = new List<Cuenta>();
                var relChicaTable = ctx.AsignarTables
                                       .Where(a => a.TableId == TableId)
                                       .ToList();

                foreach (AsignarTable  item in relChicaTable)
                {
                    var cuenta = ctx.Cuentas
                                    .Include("Foto")
                                    .Where(c => c.Id  == item.UsuarioId)
                                    .FirstOrDefault();
                    listaChicas.Add(cuenta);
                }

                return listaChicas;
            }
        }

        public Cuenta obtenerDondeTrabajaChica(int chicaId)
        {
            using (var ctx = new ModelTDFMVC4())
            {
                try
                {
                    var tableId = ctx.AsignarTables
                                 .SingleOrDefault(a => a.UsuarioId == chicaId);

                    int tableSeleccionado = tableId.TableId;

                    var cuentaTable = ctx.Cuentas
                                         .Include("Table")
                                         .SingleOrDefault(c => c.Id == tableSeleccionado);

                    return cuentaTable;
                }
                catch (Exception)
                {
                    return null;                       
                }
            }
        }
                        
        List<Cuenta> ITable.listarTablesPorEstadoConFoto(int estado)
        {
            using (var ctx = new ModelTDFMVC4())
            {
                var listaTables = ctx.Cuentas
                                     .Include("Table")
                                     .Include("Foto")
                                     .Where(t => t.Table.EstadoId == estado).ToList();
                return listaTables;
            }
        }




        public List<Cuenta> obtenerDondeTrabajaChicaLista(int chicaId)
        {
            using (var ctx = new ModelTDFMVC4())
            {
                try
                {
                    var tableId = ctx.AsignarTables
                                 .SingleOrDefault(a => a.UsuarioId == chicaId);

                    int tableSeleccionado = tableId.TableId;

                    List<Cuenta> cuentaTable = ctx.Cuentas
                                                  .Include("Table")
                                                  .Where(c => c.Id == tableSeleccionado)
                                                  .ToList();

                    return cuentaTable;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
    }
}
