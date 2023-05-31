using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using ProyectoTFG.Data;
using ProyectoTFG.Data.Toast;

namespace ProyectoTFG.Pages.PaginasTrabajadores
{
    public partial class VistaTrabajadores
    {
        private List<Trabajadores> TrabajadoresMostrados = new();

        [Inject] HospitalContext context { get; set; }

        [Inject] NavigationManager SiguientePagina { get; set; }

        [Inject] public ToastService toastService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await ShowDatos();
        }

        private void VerDetalle(int id)
        {
            SiguientePagina.NavigateTo($"/api/trabajadores/{id}");
        }

        public void Informacion()
        {
            toastService.ShowToast(new ToastOption()
            {
                Title = "Borrando usuario",
                Content = "Usuario borrado",
            });
        }

        public async Task ShowDatos()
        {
            context ??= await HospitalDBContext.CreateDbContextAsync();

            if (context is not null)
            {
                TrabajadoresMostrados = await context.Trabajadores.ToListAsync();
            }
        }
    }
}
