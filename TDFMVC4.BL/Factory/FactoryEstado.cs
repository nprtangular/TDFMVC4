using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDFMVC4.Common.Enum;
using TDFMVC4.Common.Interfaces;
using TDFMVC4.DALC.EF;

namespace TDFMVC4.BL.Factory
{
    class FactoryEstado
    {
        public static IEstado Get(DataLayerType type)
        {
            switch (type)
            {
                case DataLayerType.EF:
                    return new EstadoEF();
                //case DataLayerType.ADO:
                //    return new EstadoADO();

                default:
                    return null;
            }
        }
    }
}
