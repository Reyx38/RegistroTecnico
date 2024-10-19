using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 

namespace RegistroTecnicos.Models;
public class Tecnicos
{
    [Key]
    public int TecnicoId { get; set; }
    [Required(ErrorMessage = "Campo obligatorio")]
    [StringLength(50)]
	[RegularExpression("^[a-zA-ZÀ-ÿ\\s]+$", ErrorMessage = "Solo se permiten letras.")]
	public string? Nombres { get; set; }

	[Required(ErrorMessage = "Campo obligatorio")]
	[Range(0.01, double.MaxValue, ErrorMessage = "El sueldo por hora debe ser mayor a 0.")]
	[RegularExpression(@"^\d+$", ErrorMessage = "Solo se permiten números.")]
	public double SueldoHora { get; set; }

    [ForeignKey("TipoTecnico")] 
    [Required(ErrorMessage = "Debe seleccionar un tipo")]
    public int TipoTecnicoId { get; set; }
    public TiposTecnicos? TipoTecnico { get; set; }
}
