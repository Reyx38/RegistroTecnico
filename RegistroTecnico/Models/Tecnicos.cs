using System.ComponentModel.DataAnnotations;

namespace RegistroTecnico.Models
{
	public class Tecnicos
	{
		[Key]
		public int tecniCold { get; set; }
		[Required(ErrorMessage = "Campo obligatorio")]
		public string? nombre { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "El sueldo por hora debe ser mayor a 0.")]
        public double sueldoHora { get; set; }
	}
}
