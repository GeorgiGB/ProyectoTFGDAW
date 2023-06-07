using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using ProyectoTFG.Componentes.Widgets.Toast;
using ProyectoTFG.Data;
using ProyectoTFG.Interfaces;

namespace ProyectoTFG.Pages.PaginasPacientes
{
    public partial class VistaPacientes : ComponentBase
    {
        private List<Pacientes> PacientesMostrados = new();
        private List<Pacientes> PacientesFiltrados = new();

        private string pacienteFiltrado = "";

        [Inject] HospitalContext context { get; set; }

        [Inject] IDbContextFactory<HospitalContext> HospitalDBContext { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }

        [Inject] public ToastService toastService { get; set; }

		[Inject] PacientesService pacientesService { get; set; }

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

        }
		private async void BorrarPaciente(Pacientes pacientes)
		{
			if (pacientes?.idPac != null)
			{
				await pacientesService.DeletePacientes(pacientes.idPac);

                await ShowDatos();

			}
			StateHasChanged();
		}

		private void ShowNotification(string t, string c)
		{
			this.toastService.ShowToast(new ToastOption() { Title = t, Content = c });
			StateHasChanged();
		}

		private async Task ReiniciarLista()
        {
            pacienteFiltrado = string.Empty;
            await ShowDatos();
        }

        private async Task BuscarTrabajador()
        {
            if (!string.IsNullOrEmpty(pacienteFiltrado))
            {
                PacientesMostrados = (List<Pacientes>)await pacientesService.BuscarPacientesPorNombre(pacienteFiltrado);
            }
            else
            {
                await ShowDatos();
            }
        }

        private void VerDetalle(int id)
        {
            NavigationManager.NavigateTo($"/api/pacientes/{id}");
        }
        
    }
}
