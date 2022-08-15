
using Datos.Interfaces;
using Datos.Repositorios;
using EmpresaDeliveryGodSpeed.Data;
using EmpresaDeliveryGodSpeed.Interfaces;
using Entidades;

namespace EmpresaDeliveryGodSpeed.Servicios
{
    public class EnvioReciboServicio : IEnvioReciboServicio
    {
        private readonly MySQLConfiguracion config;
        private IEnvioReciboRepositorio EnvioReciboRepositorio;

        public EnvioReciboServicio(MySQLConfiguracion configuracion)
        {
            config = configuracion;
            EnvioReciboRepositorio = new EnvioReciboRepositorio(configuracion.CadenaConexion);
        }

        public async Task<int> Nuevo(EnvioRecibo enviorecibo)
        {
            return await EnvioReciboRepositorio.Nuevo(enviorecibo);
        }
    }
}
