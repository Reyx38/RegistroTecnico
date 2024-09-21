using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models;

public class Prioridades
{
    [Key]
    public int PrioridadId { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio")]
    [RegularExpression("^[a-zA-ZÀ-ÿ\\s]+$", ErrorMessage = "Solo se permiten letras.")]
    [StringLength(30)]
    public string? Descripcion { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El sueldo por hora debe ser mayor a 0.")]
    [RegularExpression(@"^\d{6}$", ErrorMessage = "Solo se permiten 6 números.")]
	public int Tiempo { get; set; }
}
