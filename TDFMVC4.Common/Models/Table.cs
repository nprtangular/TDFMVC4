using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDFMVC4.Common.Models
{
    public class Table
    {
        public int Id { get; set; }
        public string NombreTable { get; set; }
        public int ChicasEnEscena { get; set;}
        public decimal ConsumoXPersona { get; set; }
        public string TelefonoReservacion { get; set; }
        public virtual ICollection<Foto> Foto { get; set; }
        public virtual Login Login { get; set; }
        public int EstadoId { get; set; }
    }
}
