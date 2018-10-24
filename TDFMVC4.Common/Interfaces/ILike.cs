using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDFMVC4.Common.Models;

namespace TDFMVC4.Common.Interfaces
{
    interface ILike
    {
        void agregarLike(Like like);
        List<Post> obtenerLikes(int usuarioId);
        List<Post> obtenerLikesPorId(int likeId);
    }
}
