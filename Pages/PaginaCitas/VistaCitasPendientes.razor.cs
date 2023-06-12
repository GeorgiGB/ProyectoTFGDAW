using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using ProyectoTFG.Data;

namespace ProyectoTFG.Pages.PaginaCitas
{
    [Authorize]
    public partial class VistaCitasPendientes : ComponentBase
    {
        List<Cita> citasPendientes = new();
        List<Cita> citasAprobadas = new();

        [Inject] public CitasService citasService { get; set; }

        protected async Task OnInitialized()
        {
            /*Invocar las listas de citas*/
            citasPendientes = (List<Cita>)await citasService.GetAllCitas();
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


        
    }

}
