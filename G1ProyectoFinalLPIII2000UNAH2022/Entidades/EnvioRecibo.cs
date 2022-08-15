using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EnvioRecibo
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public string IdentidadCliente { get; set; }
        public string NombreCliente { get; set; }
        public string DireccionEnvio { get; set; }
        public string Telefono { get; set; }
        public decimal Costo { get; set; }
        public string CodigoUsuario { get; set; }
        public string CodigoRepartidor { get; set; }
    }
}
