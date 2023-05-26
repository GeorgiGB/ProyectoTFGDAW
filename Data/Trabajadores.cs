using System;
using System.Collections.Generic;

namespace ProyectoTFG.Data;

public partial class Trabajadores
{
    public int Idtrab { get; set; }

    public string TrabNombre { get; set; } = null!;

    public string TrabApellido { get; set; } = null!;

    public string? TrabDireccion { get; set; }

    public string? TrabPuesto { get; set; }

    public string? TrabHorario { get; set; }

    public string? TrabCorreo { get; set; }

    public string? TrabSexo { get; set; }

    public string? TrabTel { get; set; }

    public DateTime TrabFechNa { get; set; }
}
