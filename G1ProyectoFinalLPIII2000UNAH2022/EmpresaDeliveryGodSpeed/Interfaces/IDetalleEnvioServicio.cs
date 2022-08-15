using Entidades;

namespace EmpresaDeliveryGodSpeed.Interfaces
{
    public interface IDetalleEnvioServicio
    {
        Task<bool> Nuevo(DetalleEnvio detalleenvio);
    }
}
