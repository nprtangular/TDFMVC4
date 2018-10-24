using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDFMVC4.Common.Models;

namespace TDFMVC4.DALC.Mapping
{
    public class CuentaMapping : EntityTypeConfiguration<Cuenta>
    {
        public CuentaMapping()
        {
            ToTable("Cuentas");
            //HasOptional(c => c.Login);
            //HasOptional(f => f.Follow);
            
            //HasMany(m => m.Friends).WithMany();
        
            //modelBuilder.Entity<User>().HasMany(m => m.Friends).WithMany();

        }
    }
}
