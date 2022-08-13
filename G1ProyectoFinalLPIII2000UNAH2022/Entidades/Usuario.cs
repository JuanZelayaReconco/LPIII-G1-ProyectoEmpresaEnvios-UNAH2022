using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
        [Required(ErrorMessage = "El código es obligatorio")]
        public string CodigoUsuario { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El rol es obligatorio")]
        public string Rol { get; set; }
        [MinLength(6, ErrorMessage = "La contraseña debe tener un mínimo de 6 caracteres")]
        [Required(ErrorMessage = "La clave es obligatoria")]
        public string Clave { get; set; }
    }
}
