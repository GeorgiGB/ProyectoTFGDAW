using Microsoft.AspNetCore.Components;
using ProyectoTFG.Data;

namespace ProyectoTFG.Pages.PaginaCitas
{
    public partial class VistaCrearCita
    {
        private Cita nuevaCita = new Cita() { Estado = Cita.EstadoCita.Pendiente.ToString()};
        [Inject] public CitasService citasService { get; set; }
        private async Task OnSubmit()
        {
            await citasService.AgregarCitas(nuevaCita);
        }

    }
}
