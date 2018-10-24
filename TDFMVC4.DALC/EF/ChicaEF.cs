using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDFMVC4.Common.Models;
using TDFMVC4.Common.Interfaces; 
using TDFMVC4.DALC.Context;

namespace TDFMVC4.DALC.EF
{
    public class ChicaEF : IChica
    {
        public List<Cuenta> listarChicaInnerFotos()
        {
            using (var ctx = new ModelTDFMVC4())
            {
                var cuentas = (List<Cuenta>)ctx.Cuentas
                                                .Include("Foto")
                                                .Include("Chica")
                                                .Where(c=>c.TipoUsuario ==1)
                                                .OrderBy(c => c.NombreUsuario)
                                                .ToList();

                ctx.SaveChanges();
                return cuentas;
            }
        }


        //************** EF Caso 01 **************
        //Cuando obtienes una lista primero, y comparas un objeto de una clase
        //con los objetos contrarios de la otra clase

        public List<Cuenta> listarChicaInnerFotosPorUsuario(int usuarioId)
        {
            using (var ctx = new ModelTDFMVC4())
            {
                var listaQuienesSiguenAUsuario = ctx.Follows
                                 .Where(f => f.UsuarioId == usuarioId)
                                 .ToList();

                var listaDeSeguidoresDeUsuario = new List<Cuenta>();

                foreach (Follow f in listaQuienesSiguenAUsuario)
                {
                    var cuenta = ctx.Cuentas
                                    .Where(c => c.Id == f.SeguidoId)
                                    .FirstOrDefault();

                    listaDeSeguidoresDeUsuario.Add(cuenta);                    
                }
                                
                var listaDeTodosUsuariosTipoId1 = (List<Cuenta>)ctx.Cuentas
                                             .Include("Foto")
                                             .Include("Chica")
                                             .Where(c => c.TipoUsuario == 1)
                                             .OrderBy(c => c.NombreUsuario).ToList();

                var todas2 = ctx.Cuentas
                                .Include("Foto")
                                .Include("Chica")
                                .Where(c => c.TipoUsuario == 1)
                                .OrderBy(c => c.NombreUsuario).ToList();
                //Aqui ya tiene las seguidas y todas
                
                List<Cuenta> listaNuevas = new List<Cuenta>();

                var filtradas = new List<Cuenta>(listaNuevas);
                filtradas.AddRange(listaDeTodosUsuariosTipoId1
                                  .Where(p2 => listaDeSeguidoresDeUsuario.All(p1 => p1.Id != p2.Id)));

                //******************* ESTO ES LO MISMO QUE LO DE ARRIBA *******************
                var merged2 = new List<Cuenta>(listaDeSeguidoresDeUsuario);
                merged2.AddRange(listaDeTodosUsuariosTipoId1
                                .Where(p2 => listaDeSeguidoresDeUsuario.All(p1 => p1.Id != p2.Id)));
                //******************* ESTO ES LO MISMO QUE LO DE ARRIBA *******************
                
                return filtradas;                               
            }
        }

    }
}
