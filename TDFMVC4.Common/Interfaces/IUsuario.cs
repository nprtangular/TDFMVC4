using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDFMVC4.Common.Models;

namespace TDFMVC4.Common.Interfaces
{
    public interface IUsuario
    {
        //void agregarUsuario(RegistrarUsuario registrarUsuario);
        //List<Cuenta> listarUsuario();
        //Cuenta obtenerUsuarioPorNombreUsuario(string nombreUsuario);
        //Cuenta obtenerUsuarioPorCorreo(string correo);
        Usuario obtenerLugarDeNacimientoUsuario(int usuarioId);
    }
}
