using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models;

public class TiposTecnicos
{
	[Key]
	public int TipoDeTecnicosId { get; set; }

    [Required(ErrorMessage = "Completar este campo")]
	[RegularExpression("^[a-zA-ZÀ-ÿ\\s]+$", ErrorMessage = "Solo se permiten letras.")]
	[StringLength(30)]
	public String? Descripcion { get; set; }

}
