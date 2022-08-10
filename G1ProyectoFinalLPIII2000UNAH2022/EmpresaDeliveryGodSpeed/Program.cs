using EmpresaDeliveryGodSpeed.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
//using EmpresaDeliveryGodSpeed.Interfaces; //Por ahora está en modo comentario hasta que se agreguen las respectivas clases.
//using EmpresaDeliveryGodSpeed.Servicios; //Por ahora está en modo comentario hasta que se agreguen las respectivas clases.
using CurrieTechnologies.Razor.SweetAlert2;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
var cadenaConexion = new MySQLConfiguracion(builder.Configuration.GetConnectionString("MySQL"));
builder.Services.AddSingleton(cadenaConexion);
builder.Services.AddControllers();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
builder.Services.AddHttpContextAccessor();
builder.Services.AddResponseCompression();
builder.Services.AddSweetAlert2();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
