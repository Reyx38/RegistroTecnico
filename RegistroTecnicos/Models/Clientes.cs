using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models;
public class Clientes
{
	[Key]
	public int ClienteId { get; set; }

	[Required(ErrorMessage ="Campo Obligatorio")]
	[StringLength(50)]
	public string Nombres { get; set; }

	[Required(ErrorMessage = "Campo Obligatorio")]
	[RegularExpression(@"\")]


}
