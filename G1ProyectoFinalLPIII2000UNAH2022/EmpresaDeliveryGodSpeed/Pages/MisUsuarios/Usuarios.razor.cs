using EmpresaDeliveryGodSpeed.Interfaces;
using Entidades;
using Microsoft.AspNetCore.Components;

namespace EmpresaDeliveryGodSpeed.Pages.MisUsuarios
{
    partial class Usuarios
    {
        [Inject] private IUsuarioServicio _usuarioServicio { get; set; }
        private IEnumerable<Usuario> listaUsuarios { get; set; }
        protected override async Task OnInitializedAsync()
        {
            listaUsuarios = await _usuarioServicio.GetLista();
        }
    }
}
