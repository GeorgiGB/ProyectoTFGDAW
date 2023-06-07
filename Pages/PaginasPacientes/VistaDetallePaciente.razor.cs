using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProyectoTFG.Componentes.Widgets.Toast;
using ProyectoTFG.Data;
using ProyectoTFG.Interfaces;

namespace ProyectoTFG.Pages.PaginasPacientes
{
    public partial class VistaDetallePaciente
    {
        [Parameter] public string IdPac { get; set; }
        [Inject] public PacientesService pacientesService { get; set;}

        [Inject] public ToastService toastService { get; set; }

        [Inject] public HospitalContext context { get; set; }
        [Inject] public NavigationManager Navigation { get; set; }

        private Pacientes pacienteSeleccionado;

        private bool isEditing = false;

        List<string> gruposSanguineos = new List<string>
        {
            "A+",
            "A-",
            "B+",
            "B-",
            "AB+",
            "AB-",
            "O+",
            "O-"
        };

        private List<string> Genero = new List<string> { "F", "M", "O" };
        protected override async Task OnParametersSetAsync()
        {
            // Obtener los detalles del trabajador del ID proporcionado
            pacienteSeleccionado = await context.Pacientes.FindAsync(int.Parse(IdPac));
        }

        private async void HandleValidSubmit()
        {
            isEditing = false;

            await pacientesService.UpdatePacientes(pacienteSeleccionado);

            ShowNotification();

            isEditing = false;

            StateHasChanged();

            //NavigateBack();
        }
        private void ShowNotification()
        {
            this.toastService.ShowToast(new ToastOption() { Title = "Exito", Content = "Trabajador actualizado correctamente" });   
        }

        private void NavigateBack()
        {
            Navigation.NavigateTo("/api/trabajadores");
        }
    }
}
