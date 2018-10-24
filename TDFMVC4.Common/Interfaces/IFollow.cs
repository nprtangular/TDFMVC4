using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDFMVC4.Common.Models;

namespace TDFMVC4.Common.Interfaces
{
    public interface IFollow
    {
        void Seguir(int usuarioId, int seguidoId);
        List<Cuenta> obtenerSiguiendoConFotos(string NombreUsuario, int UsuarioId);
        List<Cuenta> obtenerSeguidoresConFotos(string NombreUsuario, int UsuarioId);

        void DejarDeSeguir(int usuarioId, int seguidoId);
    }
}
