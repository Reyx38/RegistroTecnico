using System.ComponentModel.DataAnnotations;

namespace RegistroTecnico.Models
{
	public class Tecnicos
	{
		[Key]
		[Required(ErrorMessage = "Campo de nombre obligatorio")]
		public string? nombre { get; set; }
		[Required(ErrorMessage = "Campo de apellido obligatorio")]
		public string? Apellido { get; set; }
		public int tecniCold { get; set; }
		public double sueldoHora { get; set; }
	}
}
