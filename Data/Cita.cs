using System;
using System.Collections.Generic;

namespace ProyectoTFG.Data;

public partial class Cita
{
    public long IdCita { get; set; }

    public long PacienteId { get; set; }

    public long TrabajadorId { get; set; }

    public byte[] Fecha { get; set; } = null!;

    public long Duracion { get; set; }
}
