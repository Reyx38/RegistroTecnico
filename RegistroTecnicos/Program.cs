using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.Components;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents();

//obtenemos el ContStr
var ConStr = builder.Configuration.GetConnectionString("SqlConStr");
//Agregamos el contexto
builder.Services.AddDbContextFactory<Contexto>(o => o.UseSqlServer(ConStr));

builder.Services.AddScoped<TecnicosServices>();
builder.Services.AddScoped<TiposTecnicosServices>();
builder.Services.AddScoped<ClienteServices>();
builder.Services.AddScoped<TrabajoServices>();
builder.Services.AddScoped<PrioridadesServices>();
builder.Services.AddScoped<ArticuloServices>();
builder.Services.AddScoped<CotizacionServices>();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode();

app.Run();
