﻿using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.Models;

namespace RegistroTecnicos.DAL;

public class Contexto(DbContextOptions<Contexto> options) : DbContext(options)
{
	public DbSet<Tecnicos> Tecnicos { get; set; }
	public DbSet<TiposTecnicos> TiposTecnicos { get; set; }
	public DbSet<Clientes> Clientes { get; set; }
}

	

	

