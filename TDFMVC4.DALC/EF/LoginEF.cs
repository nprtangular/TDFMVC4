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
    public class LoginEF : ILogin
    {
        public bool validarLogin(string correo, string contrasena)
        {
            using (var ctx = new ModelTDFMVC4())
            {
                Login login = new Login();
                login = ctx.Logins.FirstOrDefault(l => l.Correo == correo && l.Contrasena  == contrasena);
                if (login != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
