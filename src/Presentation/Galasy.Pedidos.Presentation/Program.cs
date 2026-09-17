using Galasy.Pedidos.Business.Implementations;
using Galasy.Pedidos.Business.Interfaces;
using Galasy.Pedidos.DataAccess.Extensions;
using Galasy.Pedidos.Presentation.Components;
using Galasy.Pedidos.Repositories.Implementations;
using Galasy.Pedidos.Repositories.Interfaces;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDataAccessExtension(builder.Configuration);

builder.Services.AddScoped<IMaestroRepository, MaestroRepository>();
builder.Services.AddScoped<IMaestroDetalleRepository, MaestroDetalleRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IProductoRepository, ProductRepository>();
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IPedidoService, PedidoService>();
builder.Services.AddMudServices();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
