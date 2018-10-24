using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDFMVC4.Common.Models
{
    public class RegistrarChica
    {
        [Display(Name = "Nombre de Usuario")]
        [Required(ErrorMessage = "El Nombre de Usuario es requerido")]
        public string NombreUsuario { get; set; }

        [Display(Name = "Nombre Artistico")]
        [Required(ErrorMessage = "El Nombre Artistico es requerido")]
        public string NombreArtistico { get; set; }

        [Required(ErrorMessage = "Ingrese un correo")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "Ingrese una contraseña")]
        public string Contrasena { get; set; }
        public int TipoUsuario { get; set; }

    }
}
