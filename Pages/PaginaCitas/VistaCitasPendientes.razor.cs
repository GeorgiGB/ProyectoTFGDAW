using Microsoft.AspNetCore.Components;
using ProyectoTFG.Data;

namespace ProyectoTFG.Pages.PaginaCitas
{
    public partial class VistaCitasPendientes
    {   
        List<Cita> citas = new();
        [Inject] public CitasService citaService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            citas = (List<Cita>)await citaService.GetAllCitas();
        }
        private async Task AprobarCita(Cita cita)
        {
            cita.Estado = "Aprobada";
            await citaService.UpdateCitas(cita);
        }

        private async Task DenegarCita(Cita cita)
        {
            cita.Estado = "Denegada";
            await citaService.UpdateCitas(cita);
        }

    }
}
