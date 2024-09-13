﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroTecnicos.Models;

public class Trabajos
{
	[Key]
	public int TrabajoId { get; set; }

	[StringLength(250)]
	[Required (ErrorMessage ="Campo obligatario")]
	public string? Descripcion { get;set; }

	public DateTime? Fecha { get; set; } = DateTime.Now;
    [Required (ErrorMessage ="Campo Obligatorio")]
	public double Monto { get; set; }

	[ForeignKey("Tecnicos")]
	[Required (ErrorMessage = "Debe de elegir un tecnico")]
	public int TecnicoId { get; set; }
	public Tecnicos? Tecnicos { get; set; }

	[Required (ErrorMessage = "Debe de elegir un cliente")]
    public int? ClienteId { get; set; }
    public Clientes? Cliente { get; set; }
}
