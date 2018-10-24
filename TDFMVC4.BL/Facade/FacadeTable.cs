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
    public class FacadeTable : ITable
    {
        private ITable facAEF = FactoryTable.Get(DataLayerType.EF);
        
        public List<Cuenta> obtenerTableAsignadoAChica(int chicaId)
        {
            return facAEF.obtenerTableAsignadoAChica(chicaId);
        }

        public List<Cuenta> obtenerChicasConFotos(int TableId)
        {
            return facAEF.obtenerChicasConFotos(TableId);
        }

        public Cuenta obtenerDondeTrabajaChica(int chicaId)
        {
            return facAEF.obtenerDondeTrabajaChica(chicaId);
        }
        public List<Cuenta> listarTablesPorEstadoConFoto(int estado)
        {
            return facAEF.listarTablesPorEstadoConFoto(estado);
        }

        public List<Cuenta> obtenerDondeTrabajaChicaLista(int chicaId)
        {
            return facAEF.obtenerDondeTrabajaChicaLista(chicaId);
        }
    }

}
