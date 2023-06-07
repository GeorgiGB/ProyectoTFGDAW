using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using ProyectoTFG.Componentes;
using ProyectoTFG.Componentes.Widgets.Toast;
using ProyectoTFG.Data;

namespace ProyectoTFG.Pages.PaginasTrabajadores
{
    public partial class VistaTrabajadores : ComponentBase
    {
        private List<Trabajadores> TrabajadoresMostrados = new();
        private List<Trabajadores> TrabajadoresFiltrados = new();
        [Inject] HospitalContext context { get; set; }

        [Inject] NavigationManager SiguientePagina { get; set; }

        [Inject] public ToastService toastService { get; set; }

        [Inject] public TrabajadorService trabajadorService { get; set; }

        [Inject] IDbContextFactory<HospitalContext> HospitalDBContext { get; set; }
		[Inject] public NavigationManager NavigationManager { get; set; }

		public string trabajadorBuscado = "";
        

        protected override async Task OnInitializedAsync()
        {
            await ShowDatos();
        }

        private void VerDetalle(int id)
        {
            SiguientePagina.NavigateTo($"/api/trabajadores/{id}");
        }

        // Método para borrar el trabajador
        private async void BorrarTrabajador(Trabajadores trabajador)
        {
            if (trabajador?.idTrab != null)
            {
                await trabajadorService.DeleteTrabajador(trabajador.idTrab);
                ShowNotification("Borrado", "Trabajador Eliminado");
                ShowDatos();
            }
            StateHasChanged();
        }

        private void ShowNotification(string t, string c)
        {
            this.toastService.ShowToast(new ToastOption() { Title = t, Content = c });
            StateHasChanged();
        }

        public async Task ShowDatos()
        {
            context ??= await HospitalDBContext.CreateDbContextAsync();

            if (context is not null)
            {
                TrabajadoresMostrados = (List<Trabajadores>)await trabajadorService.GetAllTrabajadores();
                
            }
        }

        private async Task BuscarTrabajador()
        {
            if (!string.IsNullOrEmpty(trabajadorBuscado))
            {
                TrabajadoresMostrados = (List<Trabajadores>)await trabajadorService.BuscarTrabajadoresPorNombre(trabajadorBuscado);
            }
            else
            {
                await ShowDatos();
            }
        }

        private async Task ReiniciarLista()
        {
            trabajadorBuscado = string.Empty;
            ShowNotification("Exito", "Reiniciando Lista");
            await ShowDatos();
        }

		public void IrAFormulario(string ruta)
		{
			NavigationManager.NavigateTo(RutasDefinidas.CrearTrabajador);
		}


	}
}
