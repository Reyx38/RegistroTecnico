using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services
{
    public class CotizacionServices(IDbContextFactory<Contexto> DbFactory)
    {
        public async Task<bool> ExisteId(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Articulos.AnyAsync(a => a.ArticuloId == id);
        }
        private async Task<bool> Insertar(Cotizaciones cotizacion)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            await contexto.Cotizaciones.AddAsync(cotizacion);
            return await contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Cotizaciones cotizacion)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Update(cotizacion);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(Cotizaciones cotizacion)
        {
            if (!await ExisteId(cotizacion.CotizacionId))
                return await Insertar(cotizacion);

            return await Modificar(cotizacion);
        }

        public async Task<bool> Eliminar(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
			var Cotizacion = contexto.Cotizaciones.Find(id);

			contexto.CotizacionDetalles.RemoveRange(Cotizacion.CotizacionDetalles);
			contexto.Cotizaciones.Remove(Cotizacion);

			var cantidad = await contexto.SaveChangesAsync();
			return cantidad > 0;
		}

        public async Task<Cotizaciones?> Buscar(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Cotizaciones
				.Include(c => c.CotizacionDetalles)
				.Include(c => c.Clientes)
				.FirstOrDefaultAsync(A => A.CotizacionId == id);
        }

        public async Task<List<Cotizaciones>> Listar(Expression<Func<Cotizaciones, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Cotizaciones
                .Include(c => c.Clientes)
                .Include(c => c.CotizacionDetalles)
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }

    }
}
