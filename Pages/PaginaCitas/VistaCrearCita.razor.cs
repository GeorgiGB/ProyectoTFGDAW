using Microsoft.AspNetCore.Components;
using ProyectoTFG.Data;

namespace ProyectoTFG.Pages.PaginaCitas
{
    public partial class VistaCrearCita
    {
        private Cita cita = new();
        [Inject] public CitasService citasService { get; set; }
        private async Task OnSubmit()
        {
            await citasService.AgregarCitas(cita);
        }

    }
}
