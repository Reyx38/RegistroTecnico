using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services;

public class TecnicosServices(Contexto Contexto)
{
    public readonly Contexto _Contexto = Contexto;

    public async Task<bool> ExisteNombre(String nombre)
    {
        return await _Contexto.Tecnicos
            .AnyAsync(T => T.nombre == nombre);
    }
    public async Task<bool> ExisteId(int id)
    {
        return await _Contexto.Tecnicos.AnyAsync(t => t.tecniCold == id);
    }
    private async Task<bool> Insertar(Tecnicos tecnicos)
    {
        await _Contexto.Tecnicos.AddAsync(tecnicos);
        return await _Contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Tecnicos tecnicos)
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

    public async Task<bool> Guardar(Tecnicos tecnico)
    {
        if (!await ExisteNombre(tecnico.nombre))
            return await Insertar(tecnico);

        return await Modificar(tecnico);
    }

    public async Task<bool> Eliminar(int tecniCold)
    {
        return await _Contexto.Tecnicos.
            Where(p => p.tecniCold == tecniCold).ExecuteDeleteAsync() > 0;

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
