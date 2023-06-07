using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoTFG.Data;

public class Cita
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int idCita { get; set; }

    public int PacienteId { get; set; }

    public int TrabajadorId { get; set; }

    public DateTime Fecha { get; set; }
    public int Duracion { get; internal set; }
    public string Estado { get; set; }

    // Propiedades de navegación
    public Pacientes Paciente { get; set; }
    public Trabajadores Trabajador { get; set; }

    public enum EstadoCita
    {
        Pendiente,
        Aprobada,
        Denegada
    }
}
