using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDFMVC4.Common.Models;

namespace TDFMVC4.Common.Interfaces
{
    public interface ICuenta
    {

        void agregarChica(RegistrarChica registrarChica);
        void agregarTable(RegistrarTable registrarTable);
        void agregarUsuario(RegistrarUsuario registrarUsuario);
        Cuenta obtenerCuentaPorNombreDeCuenta(string nombreUsuario);
        Cuenta obtenerCuentaPorCorreo(string correo);
        Cuenta obtenerCuentaPorId(int cuentaId);
        void editarPerfil(Cuenta cuenta);        
        Cuenta obtenerCuentaPorNombreUsuario(string NombreUsuario);
    }
}
