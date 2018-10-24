using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDFMVC4.Common.Interfaces
{
    public interface ILogin
    {
        bool validarLogin(string correo, string contrasena);
    
    }
}
