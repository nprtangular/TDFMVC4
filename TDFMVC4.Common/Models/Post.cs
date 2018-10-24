using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDFMVC4.Common.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese un comentrio en el post")]
        [DataType(DataType.MultilineText)]
        public string DescripcionPost { get; set; }
        public DateTime TimeStamp { get; set; }
        public int UsuarioId { get; set; }
        public int RecipienteId { get; set; }
        public int CuentaId { get; set; }
    }
}
