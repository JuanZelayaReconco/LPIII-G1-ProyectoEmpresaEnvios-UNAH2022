using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetalleEnvio
    {
        public int Id { get; set; }
        public int IdEnvio { get; set; }
        public string TipoServicio { get; set; }
        public string FormaPago { get; set; }
        public string DescripcionObjetosEnvio { get; set; }
    }
}
