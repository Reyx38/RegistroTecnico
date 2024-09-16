using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroTecnicos.Models;
public class Clientes
{
	[Key]
	public int ClienteId { get; set; }

	[Required(ErrorMessage = "Campo Obligatorio")]
	[StringLength(50)]
	[RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Solo se permiten letras.")]
	public string? Nombres { get; set; }

	[Required(ErrorMessage = "Campo Obligatorio")]
	[RegularExpression (@"^\d+$", ErrorMessage = "Solo se permiten números.")]
	[StringLength(10)]
	public string? Telefono { get; set; }

	public ICollection<Trabajos>? Trabajos { get; set; }

}