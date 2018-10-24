using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDFMVC4.Common.Models
{
    public class Cuenta
    {
        public int Id { get; set; }

        [Required]
        public string NombreUsuario { get; set; }
        public int TipoUsuario { get; set; }
        public string Correo { get; set; }
        public virtual Login Login { get; set; }
        public virtual Chica Chica { get; set; }
        public virtual Table Table { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Follow> Follow { get; set; }
        public virtual ICollection<Foto> Foto { get; set; }
        public virtual ICollection<Post> Post { get; set; }

    }
}
