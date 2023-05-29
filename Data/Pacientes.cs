using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoTFG.Data;

public partial class Pacientes
{
    public int IdPac { get; set; }

    public string PacNombre { get; set; } = null!;

    public string PacApellido { get; set; } = null!;

    public string? PacDireccion { get; set; }

    public string? PacSexo { get; set; }

    public string? PacGs { get; set; } //Grupo sanguineo

    public DateTime PacFechRegistro { get; set; }
}
