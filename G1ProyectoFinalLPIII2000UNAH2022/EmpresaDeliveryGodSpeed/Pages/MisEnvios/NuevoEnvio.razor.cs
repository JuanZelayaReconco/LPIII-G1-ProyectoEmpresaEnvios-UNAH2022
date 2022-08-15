using CurrieTechnologies.Razor.SweetAlert2;
using EmpresaDeliveryGodSpeed.Interfaces;
using Entidades;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;

namespace EmpresaDeliveryGodSpeed.Pages.MisEnvios
{
    partial class NuevoEnvio
    {
        [Inject] private IEnvioReciboServicio envioReciboServicio { get; set; }
        [Inject] private IRepartidorServicio repartidorServicio { get; set; }
        [Inject] private IDetalleEnvioServicio detalleEnvioServicio { get; set; }
        [Inject] private SweetAlertService Swal { get; set; }
        [Inject] private NavigationManager _navigationManager { get; set; }
        [Inject] private IHttpContextAccessor httpcontextAccessor { get; set; } //Nos sirve para 
        //acceder al código de usuario el cual está logueado.
        [Inject] private IUsuarioServicio _usuarioServicio { get; set; }

        private EnvioRecibo envio = new EnvioRecibo();
        private DetalleEnvio detalleEnvio = new DetalleEnvio();
        private Usuario user = new Usuario();
        public Repartidor repartidor = new Repartidor();
        private string codigoRepartidor { get; set; }

        protected override async Task OnInitializedAsync()
        {
            user = await _usuarioServicio.GetPorCodigo(httpcontextAccessor.HttpContext.User.Identity.Name);
            envio.FechaHora = DateTime.Now;
        }

        private async void BuscarRepartidor(KeyboardEventArgs args)
        {
            if (args.Key == "Enter")
            {
                repartidor = await repartidorServicio.GetPorCodigo(codigoRepartidor);
            }
        }

        protected async Task Guardar(MouseEventArgs args)
        {
            if (args.Detail != 0)
            {
                if (!string.IsNullOrEmpty(envio.IdentidadCliente) && !string.IsNullOrEmpty(envio.NombreCliente) 
                    && !string.IsNullOrEmpty(repartidor.CodigoRepartidor) && !string.IsNullOrEmpty(repartidor.Nombre)
                    && !string.IsNullOrEmpty(envio.DireccionEnvio) && !string.IsNullOrEmpty(envio.Telefono))
                {
                    envio.CodigoRepartidor = repartidor.CodigoRepartidor;
                    envio.CodigoUsuario = httpcontextAccessor.HttpContext.User.Identity.Name;

                    if (envio.Costo == 0)
                    {
                        await Swal.FireAsync("Atención!", "Debe ingresar un valor mayor a cero", SweetAlertIcon.Warning);
                        return;
                    }

                    if (detalleEnvio.TipoServicio == null)
                    {
                        await Swal.FireAsync("Atención!", "Elija el tipo de servicio", SweetAlertIcon.Warning);
                        return;
                    }

                    if (detalleEnvio.FormaPago == null)
                    {
                        await Swal.FireAsync("Atención!", "Elija la forma de pago", SweetAlertIcon.Warning);
                        return;
                    }

                    int idEnvio = await envioReciboServicio.Nuevo(envio);

                    if (idEnvio != 0)
                    {
                        detalleEnvio.IdEnvio = idEnvio;
                        await detalleEnvioServicio.Nuevo(detalleEnvio);

                        await Swal.FireAsync("¡Felicidades!", "El envío se ha registrado exitosamente", SweetAlertIcon.Success);
                    }
                    else
                    {
                        await Swal.FireAsync("Error!!!", "No se pudo registrar el envío", SweetAlertIcon.Error);
                    }
                }
                else
                {
                    await Swal.FireAsync("Atención!", "Debe ingresar todos los campos, son requeridos", SweetAlertIcon.Warning);
                    return;
                }

                _navigationManager.NavigateTo("/");
            }
        }

        protected void Cancelar()
        {
            _navigationManager.NavigateTo("/");
        }
    }
}

//El método siguiente hace la enumeración de las opciones que debe tener un "ComboBox".
public enum TipoServicios
{
    Seleccionar,
    Farmacia,
    Supermercado,
    Restaurantes,
    Tiendas_Por_Departamento,
    Electrónica
}

public enum FormaPago
{
    Seleccionar,
    Efectivo,
    Tarjeta,
    Billetera_Electronica
}
