﻿using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services;

public class TiposTecnicosServices(Contexto contexto)
{
    private readonly Contexto _contexto = contexto;

    public async Task<bool> ExisteId(int id)
    {
        return await _contexto.TiposTecnicos.AnyAsync(t => t.TipoDeTecnicosId == id);
    }
    public async Task<bool> ExisteDescripcion(String? descripcion)
    {
        return await _contexto.TiposTecnicos.AnyAsync(t => t.Descripcion == descripcion);
    }

    private async Task<bool> Insertar(TiposTecnicos tiposTecnicos)
    {
        await _contexto.TiposTecnicos.AddAsync(tiposTecnicos);
        return await _contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(TiposTecnicos tiposTecnicos)
    {
        _contexto.TiposTecnicos.Update(tiposTecnicos);
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(TiposTecnicos tiposTecnicos)
    {
        if(!await ExisteId(tiposTecnicos.TipoDeTecnicosId))
            return await Insertar(tiposTecnicos);

        return await Modificar(tiposTecnicos);

    }

    public async Task<bool> Eliminar(int id)
    {
        return await _contexto.TiposTecnicos.
            Where(t => t.TipoDeTecnicosId == id).ExecuteDeleteAsync() > 0;
    }
    public async Task<TiposTecnicos?> Buscar(int id)
    {
        return await _contexto.TiposTecnicos
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.TipoDeTecnicosId == id);
    }
    public async Task<List<TiposTecnicos>> Listar(Expression<Func<TiposTecnicos, bool>> criterio)
    {
        return await _contexto.TiposTecnicos
            .AsNoTracking()
            .Where(criterio) 
            .ToListAsync();
    }
}
