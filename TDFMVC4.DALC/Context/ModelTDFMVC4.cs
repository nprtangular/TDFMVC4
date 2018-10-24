using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDFMVC4.Common.Models;
using TDFMVC4.DALC.Mapping;

namespace TDFMVC4.DALC.Context
{
    public class ModelTDFMVC4 : DbContext
    {
        public ModelTDFMVC4()
            : base("name=ModelTDFMVC4")
        { }

   
        public virtual DbSet<AsignarTable> AsignarTables { get; set; }
        public virtual DbSet<Chica> Chicas { get; set; }
        public virtual DbSet<Cuenta> Cuentas { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<Foto> Fotos{ get; set; }
        public virtual DbSet<Like> Likes { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Follow> Follows { get; set; }
        public virtual DbSet<Table> Tables { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Configurations.Add(new AsignarTableMapping());
            modelBuilder.Configurations.Add(new ChicaMapping());
            modelBuilder.Configurations.Add(new CuentaMapping());
            modelBuilder.Configurations.Add(new LoginMapping());
            modelBuilder.Configurations.Add(new FollowMapping ());
            modelBuilder.Configurations.Add(new FotoMapping());
            modelBuilder.Configurations.Add(new PostMapping());
            modelBuilder.Configurations.Add(new TableMapping());
        }

    }
}
