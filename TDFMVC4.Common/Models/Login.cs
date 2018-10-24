using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDFMVC4.Common.Models
{
    public class Login
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese un correo")]
        //[DataType(DataType.MultilineText)]
        public string Correo { get; set; }
        
        [Required(ErrorMessage = "Ingrese una contraseña")]
        //[DataType(DataType.MultilineText)]
        public string Contrasena { get; set; }
        //public Chica Chica { get; set; } //navigation property de Post

    }
}
