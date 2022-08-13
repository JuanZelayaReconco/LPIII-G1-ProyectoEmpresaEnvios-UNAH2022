using Datos.Interfaces;
using Datos.Repositorios;
using EmpresaDeliveryGodSpeed.Data;
using EmpresaDeliveryGodSpeed.Interfaces;
using Entidades;

namespace EmpresaDeliveryGodSpeed.Servicios
{
    public class RepartidorServicio : IRepartidorServicio
    {
        private readonly MySQLConfiguracion _configuracion;
        private IRepartidorRepositorio repartidorRepositorio;

        public RepartidorServicio(MySQLConfiguracion configuracion)
        {
            _configuracion = configuracion;
            repartidorRepositorio = new RepartidorRepositorio(configuracion.CadenaConexion);
        }

        public async Task<bool> Actualizar(Repartidor repartidor)
        {
            return await repartidorRepositorio.Actualizar(repartidor);
        }

        public async Task<bool> Eliminar(Repartidor repartidor)
        {
            return await repartidorRepositorio.Eliminar(repartidor);
        }

        public async Task<IEnumerable<Repartidor>> GetLista()
        {
            return await repartidorRepositorio.GetLista();
        }

        public async Task<Repartidor> GetPorCodigo(string codigoRepartidor)
        {
            return await repartidorRepositorio.GetPorCodigo(codigoRepartidor);
        }

        public async Task<bool> Nuevo(Repartidor repartidor)
        {
            return await repartidorRepositorio.Nuevo(repartidor);
        }
    }
}
