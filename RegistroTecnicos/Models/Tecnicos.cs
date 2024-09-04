﻿using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models;
public class Tecnicos
{
    [Key]
    public int TecnicoId { get; set; }
    [Required(ErrorMessage = "Campo obligatorio")]
    public string? Nombres { get; set; }
    [Range(0.01, double.MaxValue, ErrorMessage = "El sueldo por hora debe ser mayor a 0.")]
    public double SueldoHora { get; set; }
}