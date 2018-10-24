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
    public class FacadeEstado : IEstado
    {
        private IEstado facAEF = FactoryEstado.Get(DataLayerType.EF);
        public void agregarEstado(Estado estado)
        {
            facAEF.agregarEstado(estado);
        }
        
        public List<Estado> obtenerEstados()
        {
            return facAEF.obtenerEstados();
        }
    }
}
