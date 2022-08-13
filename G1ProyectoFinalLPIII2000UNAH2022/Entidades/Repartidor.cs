using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class Repartidor
    {
        [Required(ErrorMessage = "El código es obligatorio")]
        public string CodigoRepartidor { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
        [MinLength(6, ErrorMessage = "La contraseña debe tener un mínimo de 6 caracteres")]
        [Required(ErrorMessage = "La contraseña es obligatoria")]
        public string Clave { get; set; }
        public bool EstaActivo { get; set; }
    }
}
