using Datos.Interfaces;
using Datos.Repositorios;
using EmpresaDeliveryGodSpeed.Data;
using EmpresaDeliveryGodSpeed.Interfaces;
using Entidades;

namespace EmpresaDeliveryGodSpeed.Servicios
{
    public class DetalleEnvioServicio : IDetalleEnvioServicio
    {
        private readonly MySQLConfiguracion config;
        private IDetalleEnvioRepositorio DetalleEnvioRepositorio;

        public DetalleEnvioServicio(MySQLConfiguracion configuracion)
        {
            config = configuracion;
            DetalleEnvioRepositorio = new DetalleEnvioRepositorio(configuracion.CadenaConexion);
        }

        public async Task<bool> Nuevo(DetalleEnvio detalleenvio)
        {
            return await DetalleEnvioRepositorio.Nuevo(detalleenvio);
        }
    }
}
