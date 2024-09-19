using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services;

public class PrioridadesServices(Contexto contexto)
{
	private readonly Contexto _contexto = contexto;

	public async Task<bool> ExisteDescripcion(String descripcion)
	{
		return await _contexto.Prioridades.AnyAsync(p => p.Descripcion == descripcion);
	}
	public async Task<bool> ExisteId(int id)
	{
		return await _contexto.Prioridades.AnyAsync(p => p.PrioridadId == id);
	}
	private async Task<bool> Insertar(Prioridades prioridad)
	{
		await _contexto.Prioridades.AddAsync(prioridad);
		return await _contexto.SaveChangesAsync() > 0;
	}

	private async Task<bool> Modificar(Prioridades prioridad)
	{
		_contexto.Update(prioridad);
		return await _contexto.SaveChangesAsync() > 0;
	}

	public async Task<bool> Guardar(Prioridades prioridades)
	{
		if (!await ExisteId(prioridades.PrioridadId))
			return await Insertar(prioridades);

		return await Modificar(prioridades);
	}

	public async Task<bool> Eliminar(int id)
	{
		return await _contexto.Prioridades.
			Where(p => p.PrioridadId == id).ExecuteDeleteAsync() > 0;
	}

	public async Task<Prioridades?> Buscar(int id)
	{
		return await _contexto.Prioridades
			.FirstOrDefaultAsync(p => p.PrioridadId == id);
	}

	public async Task<List<Prioridades>> Listar(Expression<Func<Prioridades, bool>> criterio)
	{
		return await _contexto.Prioridades
			.AsNoTracking()
			.Where(criterio)
			.ToListAsync();
	}


}
