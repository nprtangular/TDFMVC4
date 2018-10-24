using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDFMVC4.Common.Models;

namespace TDFMVC4.Common.Interfaces
{
    public interface IEstado
    {
        void agregarEstado(Estado estado);
        List<Estado> obtenerEstados();
    }
}
