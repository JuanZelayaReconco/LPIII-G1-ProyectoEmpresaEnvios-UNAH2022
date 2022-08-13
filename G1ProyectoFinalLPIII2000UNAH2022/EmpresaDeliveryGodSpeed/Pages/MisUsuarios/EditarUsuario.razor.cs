using CurrieTechnologies.Razor.SweetAlert2;
using EmpresaDeliveryGodSpeed.Interfaces;
using Entidades;
using Microsoft.AspNetCore.Components;

namespace EmpresaDeliveryGodSpeed.Pages.MisUsuarios
{
    partial class EditarUsuario
    {
        [Inject] private IUsuarioServicio _usuarioServicio { get; set; }
        [Inject] private SweetAlertService Swal { get; set; }
        [Inject] NavigationManager _navigationManager { get; set; }

        private Usuario user = new Usuario();

        [Parameter] public string Codigo { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(Codigo))
            {
                user = await _usuarioServicio.GetPorCodigo(Codigo);
            }
        }

        protected async void Guardar()
        {
            if (string.IsNullOrEmpty(user.CodigoUsuario) || string.IsNullOrEmpty(user.Nombre) || string.IsNullOrEmpty(user.Rol) || user.Rol == "Seleccionar" || string.IsNullOrEmpty(user.Clave))
            {
                await Swal.FireAsync("Atención!", "Debe ingresar todos los campos requeridos", SweetAlertIcon.Info);
                return;
            }

            bool update = await _usuarioServicio.Actualizar(user);
            if (update)
            {
                await Swal.FireAsync("Felicidades!", "Usuario(a) actualizado con éxito", SweetAlertIcon.Success);
            }
            else
            {
                await Swal.FireAsync("Error!!!", "No se pudo actualizar el usuario(a)", SweetAlertIcon.Error);
            }
            _navigationManager.NavigateTo("/Usuarios");
        }

        protected void Cancelar()
        {
            _navigationManager.NavigateTo("/Usuarios");
        }

        protected async Task Eliminar()
        {
            bool delete = false;

            SweetAlertResult result = await Swal.FireAsync(new SweetAlertOptions
            {
                Title = "¡Advertencia!",
                Text = "¿Está seguro que desea eliminar el usuario(a)?",
                Icon = SweetAlertIcon.Warning, //Puede ser "Question" en vez de "Warning".
                ShowCancelButton = true,
                ConfirmButtonText = "Sí",
                CancelButtonText = "No"
            });

            if (!string.IsNullOrEmpty(result.Value))
            {
                delete = await _usuarioServicio.Eliminar(user);
                if (delete)
                {
                    await Swal.FireAsync("¡Hecho!", "Usuario(a) eliminado con éxito", SweetAlertIcon.Success);
                    _navigationManager.NavigateTo("/Usuarios");
                }
                else
                {
                    await Swal.FireAsync("Error!!!", "No se pudo eliminar el usuario(a)", SweetAlertIcon.Error);
                }
            }
        }
    }
}
