using System;
using System.Collections.Generic;

namespace ProyectoTFG.Data;

public class Cita
{
    public int IdCita { get; set; }

    public int PacienteId { get; set; }

    public int TrabajadorId { get; set; }

    public DateTime Fecha { get; set; }
    public int Duracion { get; internal set; }
    public string Estado { get; set; }

    // Propiedades de navegación
    public Pacientes Paciente { get; set; }
    public Trabajadores Trabajador { get; set; }
}
