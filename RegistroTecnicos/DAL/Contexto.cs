using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.Models;

namespace RegistroTecnicos.DAL;

public class Contexto(DbContextOptions<Contexto> options) : DbContext(options)
{
    public DbSet<Tecnicos> Tecnicos { get; set; }
}
