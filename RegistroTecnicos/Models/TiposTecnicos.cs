using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models;

public class TiposTecnicos
{
	[Key]
	public int TipoDeTecnicosId { get; set; }

    [Required(ErrorMessage = "Completar este campo")]
    public String? Descripcion { get; set; }

}
