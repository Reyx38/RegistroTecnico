using Microsoft.EntityFrameworkCore;
using RegistroTecnico.DAL;
using RegistroTecnico.Models;
using System.Linq.Expressions;

namespace RegistroTecnico.Services
{
	public class TecnicosServices
	{
		public readonly Contexto _Contexto;
		public TecnicosServices(Contexto Contexto)
		{
			_Contexto = Contexto;

		}
		public async Task<bool> ExisteNombre(String nombre)
		{
			return await _Contexto.Tecnicos
				.AnyAsync(T => T.nombre == nombre);
		}
        public async Task<bool> NombreExiste(int id)
        {
            return await _Contexto.Tecnicos.AnyAsync(t => t.tecniCold == id);
        }
        public async Task<bool> Insertar(Tecnicos tecnicos)
		{
			await _Contexto.Tecnicos.AddAsync(tecnicos);
			return await _Contexto.SaveChangesAsync() > 0;
		}

		public async Task<bool> Modificar(Tecnicos tecnicos)
		{
			try
			{
				var entidadExistente = await _Contexto.Tecnicos.FindAsync(tecnicos.tecniCold);

				if (entidadExistente == null)
				{
					throw new InvalidOperationException("El técnico no existe en la base de datos.");
				}

				_Contexto.Entry(entidadExistente).CurrentValues.SetValues(tecnicos);
				return await _Contexto.SaveChangesAsync() > 0;
			}
			catch (InvalidOperationException ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
				throw;
			}
		}

		public async Task<bool> Guardar(Tecnicos tecnico
		{
			if(!await ExisteNombre(tecnicos.nombre))
				return await Insertar(tecnicos);

			return await Modificar(tecnicos);
		}

		public async Task<bool> Eliminar(int tecniCold)
		{
			var tecnicos = _Contexto.Tecnicos.
				Where(p => p.tecniCold == tecniCold).ExecuteDeleteAsync();
			return await tecnicos > 0;

		}

		public async Task<Tecnicos?> Buscar(int tecnicold)
		{
			return await _Contexto.Tecnicos.
				AsNoTracking()
				.FirstOrDefaultAsync(p => p.tecniCold == tecnicold);
		}

		public async Task<List<Tecnicos>> Listar(Expression<Func<Tecnicos, bool>> criterio)
		{
			return await _Contexto.Tecnicos
				.AsNoTracking()
				.Where(criterio)
				.ToListAsync();
		}
	}
}
