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
    public class FacadeFollow : IFollow
    {
        private IFollow facAEF = FactoryFollow.Get(DataLayerType.EF);

        public void Seguir(int usuarioId, int seguidoId)
        {
            facAEF.Seguir(usuarioId, seguidoId);
        }
        
        public List<Cuenta> obtenerSiguiendoConFotos(string NombreUsuario, int UsuarioId)
        {
            return facAEF.obtenerSiguiendoConFotos(NombreUsuario, UsuarioId);
        }
           

        public List<Cuenta> obtenerSeguidoresConFotos(string NombreUsuario, int UsuarioId)
        {
            return facAEF.obtenerSeguidoresConFotos(NombreUsuario, UsuarioId);
        }

        public void DejarDeSeguir(int usuarioId, int seguidoId)
        {
            facAEF.DejarDeSeguir(usuarioId, seguidoId);
        }
    }
}
