using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using ProyectoTFG.Data;
using ProyectoTFG.Interfaces;

namespace ProyectoTFG.Pages.PaginaCitas
{
    public partial class VistaCitas
    {
        private List<Cita> CitasMostradas = new();
        [Inject] HospitalContext context { get; set; }
        [Inject] public CitasService citasService { get; set; }
        [Inject] NavigationManager SiguientePagina { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await ShowCitas();
        }

        private void VerDetalle(int id)
        {
            SiguientePagina.NavigateTo($"/api/citas/{id}");
        }

        public async Task ShowCitas()
        {
            if (context is not null)
            {
                CitasMostradas = await context.Citas.ToListAsync();
            }
        }
    }
}
