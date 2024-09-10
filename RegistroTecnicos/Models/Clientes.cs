using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroTecnicos.Models;
public class Clientes
{
	[Key]
	public int ClienteId { get; set; }

	[Required(ErrorMessage = "Campo Obligatorio")]
	[StringLength(50)]
	public string? Nombres { get; set; }

	[Required(ErrorMessage = "Campo Obligatorio")]
	[RegularExpression(@"(?\d{3}\)?[-.\s]?\d{3}[-.\s]?\d{4}", ErrorMessage ="El numero de telefono no es valido")]
	public string? Telefono { get; set; }

	[ForeignKey("--")]
	public int TrabajoId { get; set;}

	public Trabajos? Trabajos { get; set;}

}