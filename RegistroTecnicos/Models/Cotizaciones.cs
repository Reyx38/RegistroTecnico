using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroTecnicos.Models
{
    public class Cotizaciones
    {

        [Key]
        public int CotizacionId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;

        [StringLength(250)]
        [Required(ErrorMessage = "Campo obligatario")]
        public string Observacion { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El sueldo por hora debe ser mayor a 0.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Solo se permiten números.")]
        public double Monto { get; set; }

        [ForeignKey("Clientes")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Debe seleccionar un Cliente")]
        public int ClientesId { get; set; }
        public Clientes? Clientes{ get; set; }

		public ICollection<CotizacionDetalles> CotizacionDetalles { get; set; } = [];

	}
}
