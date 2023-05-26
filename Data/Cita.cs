using System;
using System.Collections.Generic;

namespace ProyectoTFG.Data;

public partial class Cita
{
    public int IdCita { get; set; }

    public int PacienteId { get; set; }

    public int TrabajadorId { get; set; }

    public DateTime Fecha { get; set; }

    public int Duracion { get; set; }
}
