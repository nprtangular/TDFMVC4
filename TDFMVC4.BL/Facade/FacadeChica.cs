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
    public class FacadeChica : IChica
    {
        private IChica facAEF = FactoryChica.Get(DataLayerType.EF);
           
        public List<Cuenta> listarChicaInnerFotos()
        {
            return facAEF.listarChicaInnerFotos();
        }


        public List<Cuenta> listarChicaInnerFotosPorUsuario(int usuarioId)
        {
            return facAEF.listarChicaInnerFotosPorUsuario(usuarioId);
        }

    }
}
