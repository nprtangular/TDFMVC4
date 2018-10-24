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
    public class AsignarTableEF : IAsignarTable 
    {

        public void AsignarTable(int usuarioId, int tableId)
        {
            using (var ctx = new ModelTDFMVC4())
            {
                AsignarTable asignarTable = new AsignarTable()
                {
                    UsuarioId = usuarioId,
                    TableId = tableId  
                };

                ctx.AsignarTables.Add(asignarTable);
                ctx.SaveChanges();
            }
        }



        public Cuenta verificarSiChicaTieneTableAsignado(int chicaId)
        {
            using (var ctx = new ModelTDFMVC4())
            {
                var verificarTable = ctx.AsignarTables.SingleOrDefault(a => a.UsuarioId == chicaId);

                Cuenta table = new Cuenta();

                if (verificarTable == null)
                {
                    table = null;
                }
                else
                {
                    table = ctx.Cuentas.SingleOrDefault(t => t.Id == verificarTable.TableId);
                }

                return table;
            }
        }
        
        public void desasignarTable(int chicaId, int tableId)
        {
            using (var ctx = new ModelTDFMVC4())
            {
                var desasignarTable = ctx.AsignarTables.SingleOrDefault(a => a.UsuarioId == chicaId);

                ctx.AsignarTables.Remove(desasignarTable);
                ctx.SaveChanges();
            }
        }
    }
}
