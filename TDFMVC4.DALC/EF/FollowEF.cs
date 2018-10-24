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
    public class FollowEF : IFollow
    {

        public void Seguir(int usuarioId, int seguidoId)
        {
            using (var ctx = new ModelTDFMVC4())
            {
                Follow follow = new Follow()
                {
                    UsuarioId = usuarioId,
                    SeguidoId  = seguidoId  
                };

                ctx.Follows.Add(follow);
                ctx.SaveChanges();
            }
        }

        public void DejarDeSeguir(int usuarioId, int seguidoId)
        {
            using (var ctx = new ModelTDFMVC4())
            {

                var dejarDeSeguir = ctx.Follows
                                       .SingleOrDefault(f => f.SeguidoId == seguidoId && f.UsuarioId == usuarioId);
                    
                ctx.Follows.Remove(dejarDeSeguir);
                ctx.SaveChanges();
            }
        }

                      
        public List<Cuenta> obtenerSiguiendoConFotos(string NombreUsuario, int UsuarioId)
        {
            using (var ctx = new ModelTDFMVC4())
            {
            
                var listaUsuariosFollow = new List<Cuenta>();
                var follows = ctx.Follows
                                 .Where(f => f.UsuarioId  == UsuarioId)
                                 .ToList();

                foreach (Follow f in follows)
                {
                    var cuenta = ctx.Cuentas
                                    .Include("Foto")
                                    .Where(u => u.Id == f.SeguidoId)
                                    .FirstOrDefault();
                    listaUsuariosFollow.Add(cuenta);
                }

                return listaUsuariosFollow;
            }
        }


        public List<Cuenta> obtenerSeguidoresConFotos(string NombreUsuario, int UsuarioId)
        {
            using (var ctx = new ModelTDFMVC4())
            {
                var listaUsuariosFollow = new List<Cuenta>();
                var follows = ctx.Follows.Where(f => f.SeguidoId == UsuarioId).ToList();

                foreach (Follow f in follows)
                {
                    var cuenta = ctx.Cuentas
                                    .Include("Foto")
                                    .Where(u => u.Id == f.UsuarioId).FirstOrDefault();

                    listaUsuariosFollow.Add(cuenta);
                }

                return listaUsuariosFollow;
            }
        }
    }
}
