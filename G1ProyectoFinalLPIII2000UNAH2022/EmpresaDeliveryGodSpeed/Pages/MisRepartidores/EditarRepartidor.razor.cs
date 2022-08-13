using CurrieTechnologies.Razor.SweetAlert2;
using EmpresaDeliveryGodSpeed.Interfaces;
using Entidades;
using Microsoft.AspNetCore.Components;

namespace EmpresaDeliveryGodSpeed.Pages.MisRepartidores
{
    partial class EditarRepartidor
    {
        [Inject] private IRepartidorServicio _repartidorServicio { get; set; }
        [Inject] private SweetAlertService Swal { get; set; }
        [Inject] NavigationManager _navigationManager { get; set; }

        private Repartidor rep = new Repartidor();

        [Parameter] public string CodigoRepartidor { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(CodigoRepartidor))
            {
                rep = await _repartidorServicio.GetPorCodigo(CodigoRepartidor);
            }
        }

        protected async void Guardar()
        {
            if (string.IsNullOrEmpty(rep.CodigoRepartidor) || string.IsNullOrEmpty(rep.Nombre)
                || string.IsNullOrEmpty(rep.Clave))
            {
                return;
            }

            bool edito = await _repartidorServicio.Actualizar(rep);

            if (edito)
            {
                await Swal.FireAsync("Felicidades", "Repartidor guardado con exito", SweetAlertIcon.Success);
            }
            else
            {
                await Swal.FireAsync("Error", "No se pudo guardar el repartidor", SweetAlertIcon.Error);
            }
            _navigationManager.NavigateTo("/Repartidores");
        }

        protected void Cancelar()
        {
            _navigationManager.NavigateTo("/Repartidores");
        }

        protected async Task Eliminar()
        {
            bool elimino = false;

            SweetAlertResult result = await Swal.FireAsync(new SweetAlertOptions
            {
                Title = "¿Seguro que desea eliminar el repartidor?",
                Icon = SweetAlertIcon.Warning,
                ShowCancelButton = true,
                ConfirmButtonText = "Sí",
                CancelButtonText = "No"
            });

            if (!string.IsNullOrEmpty(result.Value))
            {
                elimino = await _repartidorServicio.Eliminar(rep);
                if (elimino)
                {
                    await Swal.FireAsync("Felicidades", "Repartidor eliminado con exito", SweetAlertIcon.Success);
                    _navigationManager.NavigateTo("/Repartidores");
                }
                else
                {
                    await Swal.FireAsync("Error", "No se pudo eliminar el repartidor", SweetAlertIcon.Error);
                }
            }
        }
    }
}
