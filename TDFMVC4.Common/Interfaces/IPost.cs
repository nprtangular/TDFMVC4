using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDFMVC4.Common.Models;

namespace TDFMVC4.Common.Interfaces
{
    public interface IPost
    {
        void agregarPost(Post post);
        List<Post> obtenerPostPorUsuarioId(int usuarioId);
        
        List<Cuenta> listarPostsPorUsuarioIdConFoto(int usuarioId);


        Cuenta obtenerPostPorUsuarioIdConFoto(int usuarioId);
    }
}
