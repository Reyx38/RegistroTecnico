using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.Models;

namespace RegistroTecnicos.DAL;

public class Contexto(DbContextOptions<Contexto> options) : DbContext(options)
{
	public DbSet<Tecnicos> Tecnicos { get; set; }
	public DbSet<TiposTecnicos> TiposTecnicos { get; set; }
	public DbSet<Clientes> Clientes { get; set; }
	public DbSet<Trabajos> Trabajos { get; set; }
	public DbSet<Prioridades> Prioridades { get; set; }
	public DbSet<Articulos> Articulos { get; set; }
	public DbSet<TrabajosDetalles> TrabajosDetalles { get; set; }
    public DbSet<Cotizaciones> Cotizaciones { get; set; }
    public DbSet<CotizacionDetalles> CotizacionDetalles { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.Entity<Articulos>().HasData(new List<Articulos>()
		{
			new Articulos() {ArticuloId = 1, Descripcion = "Pasta termica", 
				Costo = 30, Precio = 40,Existencia = 20},
			new Articulos() {ArticuloId = 2, Descripcion = "Memoria RAM",
			    Costo = 100, Precio = 150, Existencia = 10 },
			new Articulos() {ArticuloId = 3, Descripcion = "Tarjeta grafica",
			    Costo = 80, Precio = 130, Existencia = 12}
		});
	}

}





