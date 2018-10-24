using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDFMVC4.Common.Models;

namespace TDFMVC4.Common.Interfaces
{
    public interface IAsignarTable
    {
        void AsignarTable(int usuarioId, int tableId);
        Cuenta verificarSiChicaTieneTableAsignado(int chicaId);
        void desasignarTable(int chicaId, int tableId);

        //List<Cuenta> obtenerSeguidores(int usuarioId);
        //List<Cuenta> obtenerSiguiendo(int usuarioId);
      
    }
}
