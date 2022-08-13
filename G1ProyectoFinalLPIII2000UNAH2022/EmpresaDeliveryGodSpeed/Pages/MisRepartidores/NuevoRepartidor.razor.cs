using CurrieTechnologies.Razor.SweetAlert2;
using EmpresaDeliveryGodSpeed.Interfaces;
using Entidades;
using Microsoft.AspNetCore.Components;

namespace EmpresaDeliveryGodSpeed.Pages.MisRepartidores
{
    partial class NuevoRepartidor
    {
        [Inject] private IRepartidorServicio _repartidorServicio { get; set; }
        [Inject] private SweetAlertService Swal { get; set; }
        [Inject] NavigationManager _navigationManager { get; set; }

        private Repartidor rep = new Repartidor();


        protected async void Guardar()
        {
            if (string.IsNullOrEmpty(rep.CodigoRepartidor) || string.IsNullOrEmpty(rep.Nombre)
                || string.IsNullOrEmpty(rep.Clave))
            {
                return;
            }

            bool inserto = await _repartidorServicio.Nuevo(rep);

            if (inserto)
            {
                await Swal.FireAsync("¡Felicidades!", "Repartidor registrado con exito", SweetAlertIcon.Success);
            }
            else
            {
                await Swal.FireAsync("Error!!!", "No se pudo registrar el repartidor", SweetAlertIcon.Error);
            }
            _navigationManager.NavigateTo("/Repartidores");
        }



        protected void Cancelar()
        {
            _navigationManager.NavigateTo("/Repartidores");
        }
    }
}
