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
    public class CuentaEF : ICuenta
    {

        public void agregarUsuario(RegistrarUsuario registrarUsuario)
        {
            using (var ctx = new ModelTDFMVC4())
            {
                Cuenta cuenta = new Cuenta()
                {
                    NombreUsuario = registrarUsuario.NombreUsuario,
                    TipoUsuario = registrarUsuario.TipoUsuario,
                    Correo = registrarUsuario.Correo,

                    Login = new Login()
                    {
                        Correo = registrarUsuario.Correo,
                        Contrasena = registrarUsuario.Contrasena
                    },

                    Usuario = new Usuario()
                    {
                        LugarNacimiento = registrarUsuario.LugarDeNacimiento
                    },

                };

                ctx.Cuentas.Add(cuenta);
                ctx.SaveChanges();
            }
        }
        
        public void agregarTable(RegistrarTable registrarTable)
        {
            using (var ctx = new ModelTDFMVC4())
            {
                Cuenta cuenta = new Cuenta()
                {
                    NombreUsuario = registrarTable.NombreUsuario,
                    TipoUsuario = registrarTable.TipoUsuario,
                    Correo = registrarTable.Correo,

                    Login = new Login()
                    {
                        Correo = registrarTable.Correo,
                        Contrasena = registrarTable.Contrasena
                    },

                    Table = new Table()
                    {
                        ChicasEnEscena = registrarTable.ChicasEnEscena,
                        NombreTable = registrarTable.NombreTable,
                        ConsumoXPersona = registrarTable.ConsumoXPersona,
                        EstadoId= registrarTable.EstadoId,
                        TelefonoReservacion = registrarTable.TelefonoReservacion
                    },
                };

                ctx.Cuentas.Add(cuenta);
                ctx.SaveChanges();
            }
        }

        public void agregarChica(RegistrarChica registrarChica)
        {
            using (var ctx = new ModelTDFMVC4())
            {
                Cuenta cuenta = new Cuenta()
                {
                    NombreUsuario = registrarChica.NombreUsuario,
                    TipoUsuario = registrarChica.TipoUsuario,
                    Correo = registrarChica.Correo,

                    Login = new Login()
                    {
                        Correo = registrarChica.Correo,
                        Contrasena = registrarChica.Contrasena
                    },

                    Chica = new Chica()
                    {
                        NombreArtistico = registrarChica.NombreArtistico
                    },

                };

                ctx.Cuentas.Add(cuenta);
                ctx.SaveChanges();
            }
        }

        public Cuenta obtenerCuentaPorNombreDeCuenta(string nombreUsuario)
        {
            using (var ctx = new ModelTDFMVC4())
            {
                Cuenta cuenta = new Cuenta();
                cuenta = ctx.Cuentas.SingleOrDefault(x => x.NombreUsuario == nombreUsuario);
                ctx.SaveChanges();
                return cuenta;
            }
        }

        public Cuenta obtenerCuentaPorCorreo(string correo)
        {
            using (var ctx = new ModelTDFMVC4())
            {
                var cuenta = ctx.Cuentas
                                .SingleOrDefault(x => x.Login.Correo == correo);
                ctx.SaveChanges();
                return cuenta;
            }
        }

        public Cuenta obtenerCuentaPorId(int cuentaId)
        {
            using (var ctx = new ModelTDFMVC4())
            {
                var cuenta = ctx.Cuentas
                             .Include("Chica")
                             .Include("Usuario")
                             .Include("Table")
                             .SingleOrDefault(x => x.Id == cuentaId);
                
                ctx.SaveChanges();
                return cuenta;
            }
        }

        public Cuenta obtenerCuentaPorNombreUsuario(string NombreUsuario)
        {
            using (var ctx = new ModelTDFMVC4())
            {                
                var cuenta = ctx.Cuentas
                             .Include("Chica")
                             .Include("Usuario")
                             .Include("Table")
                             .SingleOrDefault(x => x.NombreUsuario == NombreUsuario );
                ctx.SaveChanges();
                return cuenta;
            }
        }
        
        public void editarPerfil(Cuenta cuenta)
        {
            using (var ctx = new ModelTDFMVC4())
            {

                if (cuenta.TipoUsuario==1)
                {
                    var chicaModificar = ctx.Chicas.Where(c => c.Id == cuenta.Chica.Id).SingleOrDefault();
                    chicaModificar.NombreArtistico = cuenta.Chica.NombreArtistico;
                    ctx.SaveChanges();               
                }
                else if (cuenta.TipoUsuario == 2)
                {
                    var usuarioModificar = ctx.Usuarios
                                              .Where(u => u.Id == cuenta.Usuario.Id)
                                              .SingleOrDefault();
                    usuarioModificar.LugarNacimiento = cuenta.Usuario.LugarNacimiento;
                    ctx.SaveChanges();                               
                }
                else if (cuenta.TipoUsuario == 3)
                {
                    var tableModificar = ctx.Tables.Where(u => u.Id == cuenta.Table.Id).SingleOrDefault();
                    tableModificar.ChicasEnEscena  = cuenta.Table.ChicasEnEscena;
                    ctx.SaveChanges();
                }
            }
        }

    }
}
