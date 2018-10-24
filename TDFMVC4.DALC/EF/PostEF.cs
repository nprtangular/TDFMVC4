using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDFMVC4.Common.Interfaces;
using TDFMVC4.Common.Models;
using TDFMVC4.DALC.Context;

namespace TDFMVC4.DALC.EF
{
    public class PostEF : IPost
    {

        public void agregarPost(Post post)
        {
            using (var ctx = new ModelTDFMVC4())
            {
                ctx.Posts.Add(post);
                ctx.SaveChanges();
            }
        }

        public List<Post> obtenerPostPorUsuarioId(int usuarioId)
        {
            using (var ctx = new ModelTDFMVC4())
            {
                List<Post> posts = new List<Post>();
                posts = ctx.Posts.ToList()
                                 .FindAll(p => p.RecipienteId == usuarioId);
                ctx.SaveChanges();
                return posts;
            }
        }

        public List<Cuenta> listarPostsPorUsuarioIdConFoto(int usuarioId)
        {
            using (var ctx = new ModelTDFMVC4())
            {
                List<Post> posts = new List<Post>();
                posts = ctx.Posts
                           .Where(p => p.RecipienteId == usuarioId)
                           .ToList();

                List<Cuenta> cuentas = new List<Cuenta>();

                foreach (var post in posts)
                {
                    var cuenta = ctx.Cuentas
                                     .Include("Post")
                                     .Include("Foto")
                                     .Where(c => c.Id == post.UsuarioId)
                                     .FirstOrDefault();
                    cuentas.Add(cuenta);
                }
                //Trae los mensajes de los que publicaron
                return cuentas;
            }
        }


        public Cuenta obtenerPostPorUsuarioIdConFoto(int usuarioId)
        {
            using (var ctx = new ModelTDFMVC4())
            {
                Post posts = new Post();
                posts = ctx.Posts
                           .Where(p => p.RecipienteId == usuarioId)
                           .SingleOrDefault();                           

                Cuenta cuentas = new Cuenta();

                
                    var cuenta = ctx.Cuentas
                                     .Include("Post")
                                     .Include("Foto")
                                     .Where(c => c.Id == posts.UsuarioId)
                                    .FirstOrDefault();                 
                return cuenta;
            }
        }
    }
}
