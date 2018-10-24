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
    public class FacadePost : IPost
    {
        private IPost facAEF = FactoryPost.Get(DataLayerType.EF);

        public void agregarPost(Post post)
        {
            facAEF.agregarPost(post);
        }

        public List<Post> obtenerPostPorUsuarioId(int usuarioId)
        {
            return facAEF.obtenerPostPorUsuarioId(usuarioId);
        }
        
        public List<Cuenta> listarPostsPorUsuarioIdConFoto(int usuarioId)
        {
            return facAEF.listarPostsPorUsuarioIdConFoto(usuarioId);
        }



        public Cuenta obtenerPostPorUsuarioIdConFoto(int usuarioId)
        {
            return facAEF.obtenerPostPorUsuarioIdConFoto(usuarioId);
        }
    }
}
