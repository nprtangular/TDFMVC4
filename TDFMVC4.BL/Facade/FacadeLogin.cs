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
    public class FacadeLogin : ILogin
    {
        private ILogin facAEF = FactoryLogin.Get(DataLayerType.EF);
        
        public bool validarLogin(string correo, string contrasena)
        {
            return facAEF.validarLogin(correo, contrasena);
        }
    }
}
