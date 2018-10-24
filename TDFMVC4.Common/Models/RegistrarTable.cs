using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDFMVC4.Common.Models
{
    public class RegistrarTable
    {
        [Display(Name = "Nombre de Usuario")]
        [Required(ErrorMessage = "El Nombre de Table es requerido")]
        public string NombreUsuario { get; set; }
        public string NombreTable { get; set; }
        public decimal ConsumoXPersona { get; set; }
        public int EstadoId { get; set; }

        public string TelefonoReservacion { get; set; }
         
        [Required(ErrorMessage = "Ingrese un correo")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "Ingrese una contraseña")]
        public int ChicasEnEscena { get; set; }
        public string Contrasena { get; set; }
        public int TipoUsuario { get; set; }
    }
}
