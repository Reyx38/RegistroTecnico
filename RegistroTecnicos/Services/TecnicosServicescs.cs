using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services;

public class TecnicosServices(Contexto contexto)
{
    public readonly Contexto _contexto = contexto;

    public async Task<bool> ExisteNombre(String nombre)
    {
        return await _contexto.Tecnicos
            .AnyAsync(T => T.Nombres == nombre);
    }
    public async Task<bool> ExisteId(int id)
    {
        return await _contexto.Tecnicos.AnyAsync(t => t.TecnicoId == id);
    }
    private async Task<bool> Insertar(Tecnicos tecnicos)
    {
        await _contexto.Tecnicos.AddAsync(tecnicos);
        return await _contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Tecnicos tecnicos)
    {
        try
        {
            var entidadExistente = await _contexto.Tecnicos.FindAsync(tecnicos.TecnicoId);

            if (entidadExistente == null)
            {
                throw new InvalidOperationException("El técnico no existe en la base de datos.");
            }

            _contexto.Entry(entidadExistente).CurrentValues.SetValues(tecnicos);
            return await _contexto.SaveChangesAsync() > 0;
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }

    public async Task<bool> Guardar(Tecnicos tecnico)
    {
        if (!await ExisteNombre(tecnico.Nombres))
            return await Insertar(tecnico);

        return await Modificar(tecnico);
    }

    public async Task<bool> Eliminar(int id)
    {
        return await _contexto.Tecnicos.
            Where(p => p.TecnicoId == id).ExecuteDeleteAsync() > 0;

    }

    public async Task<Tecnicos?> Buscar(int id)
    {
        return await _contexto.Tecnicos.
            AsNoTracking()
            .FirstOrDefaultAsync(p => p.TecnicoId == id);
    }

    public async Task<List<Tecnicos>> Listar(Expression<Func<Tecnicos, bool>> criterio)
    {
        return await _contexto.Tecnicos
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}
