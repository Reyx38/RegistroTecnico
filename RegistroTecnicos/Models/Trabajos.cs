using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroTecnicos.Models;

public class Trabajos
{
	[Key]
	public int TrabajoId { get; set; }

	[StringLength(250)]	
	public string? Descripcion { get;set; }

	public DateTime? Fecha { get; set; }
	[Required (ErrorMessage ="Campo Obligatorio")]
	public double Monto { get; set; }

	[ForeignKey("TecnicoId")]
	public int TecnicoId { get; set; }
	public Tecnicos? Tecnicos { get; set; } 


}
