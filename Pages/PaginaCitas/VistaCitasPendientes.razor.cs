using Microsoft.AspNetCore.Components;
using ProyectoTFG.Data;

namespace ProyectoTFG.Pages.PaginaCitas
{
    public partial class VistaCitasPendientes : ComponentBase
    {
        List<Cita> citasPendientes;
        List<Cita> citasAprobadas;

        protected override void OnInitialized()
        {
            // Obtener las citas pendientes y aprobadas desde el servicio o repositorio
            citasPendientes = ObtenerCitasPendientes();
            citasAprobadas = ObtenerCitasAprobadas();
        }

        private void AprobarCita(Cita cita)
        {
            // Lógica para aprobar la cita
            cita.Estado = Cita.EstadoCita.Aprobada.ToString();
            // Actualizar la cita en el servicio o repositorio

            // Actualizar la lista de citas pendientes y aprobadas
            citasPendientes.Remove(cita);
            citasAprobadas.Add(cita);
        }

        private void DenegarCita(Cita cita)
        {
            // Lógica para denegar la cita
            cita.Estado = Cita.EstadoCita.Denegada.ToString();
            // Actualizar la cita en el servicio o repositorio

            // Actualizar la lista de citas pendientes
            citasPendientes.Remove(cita);
        }

        // Método simulado para obtener las citas pendientes desde el servicio o repositorio
        private List<Cita> ObtenerCitasPendientes()
        {
            // Lógica para obtener las citas pendientes
            // Puedes reemplazar esta lógica simulada con tu implementación real
            return new List<Cita>
        {
            new Cita { idCita = 1, PacienteId = 1, Fecha = DateTime.Now.AddDays(1), Duracion = 30, Estado = Cita.EstadoCita.Pendiente.ToString() },
            new Cita { idCita = 2, PacienteId = 2, Fecha = DateTime.Now.AddDays(2), Duracion = 30, Estado = Cita.EstadoCita.Pendiente.ToString() }
        };
        }

        // Método simulado para obtener las citas aprobadas desde el servicio o repositorio
        private List<Cita> ObtenerCitasAprobadas()
        {
            // Lógica para obtener las citas aprobadas
            // Puedes reemplazar esta lógica simulada con tu implementación real
            return new List<Cita>
        {
            new Cita { idCita = 3, PacienteId = 3, Fecha = DateTime.Now.AddDays(3), Duracion = 45, Estado = Cita.EstadoCita.Aprobada.ToString() }
        };
        }
    }

}
