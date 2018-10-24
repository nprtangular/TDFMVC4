using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDFMVC4.Common.Models;

namespace TDFMVC4.Common.Interfaces
{
    public interface IFoto
    {
        void agregarFoto(Foto foto);
        void eliminarFoto(int Id);
        List<Foto> listarFotosPorId(int usuarioId);
        List<Foto> listarFotosPorNombreUsuario(string NombreUsuario);
    }
}
