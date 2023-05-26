using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using ProyectoTFG.Data;

namespace ProyectoTFG.Pages.PaginasPacientes
{
    public partial class VistaPacientes
    {
        private List<Pacientes> PacientesMostrados = new ();

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
                PacientesMostrados = await context.Pacientes.ToListAsync();
            }

            //if (true) await _context.DisposeAsync();
        }
    }
}
