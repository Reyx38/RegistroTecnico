using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models
{
	public class TrabajosDetalles
	{
		[Key]
		public int DetalleId { get; set; }
		
		[Required (ErrorMessage = "campo obligarior")]
		public int TrabajoId { get; set; }

		[Required(ErrorMessage = "campo obligarior")]
		public int ArticuloId { get; set; }
		
		[Required(ErrorMessage = "campo obligarior")]
		public int cantidad { get; set; }
		
		[Required(ErrorMessage = "campo obligarior")]
		public double? costo { get; set; }
		
		[Required(ErrorMessage = "campo obligarior")]
		public double? precio { get; set; }

	}
}
