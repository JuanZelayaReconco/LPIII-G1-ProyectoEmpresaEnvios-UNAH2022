using EmpresaDeliveryGodSpeed.Interfaces;
using Entidades;
using Microsoft.AspNetCore.Components;

namespace EmpresaDeliveryGodSpeed.Pages.MisRepartidores
{
    partial class Repartidores
    {
        [Inject] private IRepartidorServicio _repartidorServicio { get; set; }

        private IEnumerable<Repartidor> listaRepartidor { get; set; }

        protected override async Task OnInitializedAsync()
        {
            listaRepartidor = await _repartidorServicio.GetLista();
        }
    }
}
