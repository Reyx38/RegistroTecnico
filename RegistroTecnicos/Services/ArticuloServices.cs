using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services;

public class ArticuloServices(Contexto contexto)
{
	private readonly Contexto _contexto = contexto;

		public async Task<bool> ExisteId(int id)
		{
			return await _contexto.Articulos.AnyAsync(a => a.ArticuloId == id);
		}
		private async Task<bool> Insertar(Articulos articulo)
		{
			await _contexto.Articulos.AddAsync(articulo);
			return await _contexto.SaveChangesAsync() > 0;
		}

		private async Task<bool> Modificar(Articulos articulos)
		{
			_contexto.Update(articulos);
			return await _contexto.SaveChangesAsync() > 0;
		}

		public async Task<bool> Guardar(Articulos articulos)
		{
			if (!await ExisteId(articulos.ArticuloId))
				return await Insertar(articulos);

			return await Modificar(articulos);
		}

		public async Task<bool> Eliminar(int id)
		{
			return await _contexto.Articulos.
				Where(a => a.ArticuloId == id).ExecuteDeleteAsync() > 0;
		}

		public async Task<Articulos?> Buscar(int id)
		{
			return await _contexto.Articulos
				.FirstOrDefaultAsync(A => A.ArticuloId == id);
		}

		public async Task<List<Articulos>> Listar(Expression<Func<Articulos, bool>> criterio)
		{
			return await _contexto.Articulos
				.AsNoTracking()
				.Where(criterio)
				.ToListAsync();
		}
}

