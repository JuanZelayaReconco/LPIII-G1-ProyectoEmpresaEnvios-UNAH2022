using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interfaces
{
    public interface IRepartidorRepositorio
    {
        Task<bool> Nuevo(Repartidor repartidor);
        Task<bool> Actualizar(Repartidor repartidor);
        Task<bool> Eliminar(Repartidor repartidor);
        Task<IEnumerable<Repartidor>> GetLista();
        Task<Repartidor> GetPorCodigo(string CodigoRepartidor);
    }
}
