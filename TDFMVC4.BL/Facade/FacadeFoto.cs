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
    public class FacadeFoto : IFoto
    {
        private IFoto facAEF = FactoryFoto.Get(DataLayerType.EF);

        public void agregarFoto(Foto foto)
        {
            facAEF.agregarFoto(foto);
        }

        public void eliminarFoto(int Id)
        {
            facAEF.eliminarFoto(Id);
        }

        public List<Foto> listarFotosPorId(int usuarioId)
        {
            return facAEF.listarFotosPorId(usuarioId);
        }

        public List<Foto> listarFotosPorNombreUsuario(string NombreUsuario)
        {
            return facAEF.listarFotosPorNombreUsuario(NombreUsuario);
        }
    }
}
