using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDFMVC4.Common.Models
{
    public class Follow
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int SeguidoId { get; set; }
        
    }
}
