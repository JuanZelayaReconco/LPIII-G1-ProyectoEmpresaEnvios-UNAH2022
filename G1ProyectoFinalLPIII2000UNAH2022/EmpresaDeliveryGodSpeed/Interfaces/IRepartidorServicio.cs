using Entidades;

namespace EmpresaDeliveryGodSpeed.Interfaces
{
    public interface IRepartidorServicio
    {
        Task<bool> Nuevo(Repartidor repartidor);
        Task<bool> Actualizar(Repartidor repartidor);
        Task<bool> Eliminar(Repartidor repartidor);
        Task<IEnumerable<Repartidor>> GetLista();
        Task<Repartidor> GetPorCodigo(string CodigoRepartidor);
    }
}
