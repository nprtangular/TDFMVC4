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
    public class UsuarioEF : IUsuario
    {   
        public Usuario obtenerLugarDeNacimientoUsuario(int usuarioId)
        {
            using (var ctx = new ModelTDFMVC4())
            {
                Usuario usuario = new Usuario();
                usuario = ctx.Usuarios
                             .SingleOrDefault(x => x.Id == usuarioId);
                ctx.SaveChanges();
                return usuario;
            }
        }
    }
}
