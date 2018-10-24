using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDFMVC4.Common.Models
{
    public class Foto
    {
        public int Id {get;set;}
        public string Imagen { get; set; }
        public string Descripcion { get; set; }
        public int CuentaId { get; set; }
    }
}
