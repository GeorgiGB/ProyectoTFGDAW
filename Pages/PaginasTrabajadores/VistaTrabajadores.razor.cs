using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using ProyectoTFG.Data;

namespace ProyectoTFG.Pages.PaginasTrabajadores
{
    public partial class VistaTrabajadores
    {
        private List<Trabajadores> TrabajadoresMostrados = new();

        [Inject] HospitalContext context { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await ShowDatos();
        }

        public async Task ShowDatos()
        {
            context ??= await HospitalDBContext.CreateDbContextAsync();

            if (context is not null)
            {
                TrabajadoresMostrados = await context.Trabajadores.ToListAsync();
            }

            //if (true) await _context.DisposeAsync();
        }
    }
}
