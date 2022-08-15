using Entidades;

namespace EmpresaDeliveryGodSpeed.Interfaces
{
    public interface IEnvioReciboServicio
    {
        Task<int> Nuevo(EnvioRecibo enviorecibo);
    }
}
