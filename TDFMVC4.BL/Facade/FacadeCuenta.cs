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
    public class FacadeCuenta : ICuenta
    {
        private ICuenta facAEF = FactoryCuenta.Get(DataLayerType.EF);

        public void agregarChica(RegistrarChica registrarChica)
        {
            facAEF.agregarChica(registrarChica);
        }
        
        public void agregarUsuario(RegistrarUsuario registrarUsuario)
        {
            facAEF.agregarUsuario(registrarUsuario);
        }
                
        public void agregarTable(RegistrarTable registrarTable)
        {
            facAEF.agregarTable(registrarTable);
        }

        public Cuenta obtenerCuentaPorNombreDeCuenta(string nombreUsuario)
        {
            return facAEF.obtenerCuentaPorNombreDeCuenta(nombreUsuario);
        }

        public Cuenta obtenerCuentaPorCorreo(string correo)
        {
            return facAEF.obtenerCuentaPorCorreo(correo);
        }

        public Cuenta obtenerCuentaPorId(int cuentaId)
        {
            return facAEF.obtenerCuentaPorId(cuentaId);
        }
        public Cuenta obtenerCuentaPorNombreUsuario(string NombreUsuario)
        {
            return facAEF.obtenerCuentaPorNombreUsuario(NombreUsuario);
        }

        public void editarPerfil(Cuenta cuenta)
        {
            facAEF.editarPerfil(cuenta);
        }

    }
}
