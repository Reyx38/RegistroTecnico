using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services;

public class ClienteService(Contexto contexto)
{
	private readonly Contexto _contexto = contexto;
	public async Task<bool> ExisteNombre(String nombre)
	{
		return await _contexto.Clientes.AnyAsync(T => T.Nombres == nombre);
	}
	public async Task<bool> ExisteId(int id)
	{
		return await _contexto.Clientes.AnyAsync(t => t.ClienteId == id);
	}
	private async Task<bool> Insertar(Clientes cliente)
	{
		await _contexto.Clientes.AddAsync(cliente);
		return await _contexto.SaveChangesAsync() > 0;
	}

	private async Task<bool> Modificar(Clientes cliente)
	{
		_contexto.Update(cliente);
		return await _contexto.SaveChangesAsync() > 0;
	}

	public async Task<bool> Guardar(Clientes cliente)
	{
		if (!await ExisteId(cliente.ClienteId))
			return await Insertar(cliente);

		return await Modificar(cliente);
	}

	public async Task<bool> Eliminar(int id)
	{
		return await _contexto.Clientes.
			Where(p => p.ClienteId == id).ExecuteDeleteAsync() > 0;
	}

	public async Task<Clientes?> Buscar(int id)
	{
		return await _contexto.Clientes
			.FirstOrDefaultAsync(p => p.ClienteId == id);
	}

	public async Task<List<Clientes>> Listar(Expression<Func<Clientes, bool>> criterio)
	{
		return await _contexto.Clientes
			.AsNoTracking()
			.Where(criterio)
			.ToListAsync();
	}
}
