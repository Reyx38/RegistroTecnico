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
	public string? Telefono { get; set; }

	public ICollection<Trabajos>? Trabajos { get; set; }

}