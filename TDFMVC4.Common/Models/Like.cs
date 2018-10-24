using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDFMVC4.Common.Models
{
    public class Like
    {
        public int Id { get; set; }
        [Required]
        public int PostId { get; set; }
        [Required]
        public int UsuarioId { get; set; }
    }
}
