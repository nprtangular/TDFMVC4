using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDFMVC4.BL.Factory;
using TDFMVC4.Common.Enum;
using TDFMVC4.Common.Interfaces;
using TDFMVC4.Common.Models;

namespace TDFMVC4.BL.Facade
{
    public class FacadeAsignarTable
    {
        private IAsignarTable facAEF = FactoryAsignarTable.Get(DataLayerType.EF);

        public void AsignarTable(int usuarioId, int tableId)
        {
            facAEF.AsignarTable(usuarioId, tableId);
        }

        public Cuenta verificarSiChicaTieneTableAsignado(int chicaId)
        {
            return facAEF.verificarSiChicaTieneTableAsignado(chicaId);
        }

        public void DesasignarTable(int chicaId, int tableId)
        {
            facAEF.desasignarTable(chicaId, tableId);
        }
    }
}
