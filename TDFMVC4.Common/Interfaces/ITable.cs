using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDFMVC4.Common.Models;

namespace TDFMVC4.Common.Interfaces
{
    public interface ITable
    {
        List<Cuenta> obtenerTableAsignadoAChica(int chicaId);
        List<Cuenta> obtenerChicasConFotos(int TableId);
        Cuenta obtenerDondeTrabajaChica(int chicaId);

        List<Cuenta> listarTablesPorEstadoConFoto(int estado);

        List<Cuenta> obtenerDondeTrabajaChicaLista(int chicaId);
    }
}
