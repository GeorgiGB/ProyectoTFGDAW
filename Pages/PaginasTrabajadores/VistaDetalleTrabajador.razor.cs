using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using ProyectoTFG.Componentes.Widgets.Toast;
using ProyectoTFG.Data;

namespace ProyectoTFG.Pages.PaginasTrabajadores
{
    [Authorize]
    public partial class VistaDetalleTrabajador : ComponentBase
    {
        [Parameter] public string TrabId { get; set; }

        [Inject] public HospitalContext context { get; set; }

        [Inject] public TrabajadorService trabajadorService { get; set; }

        [Inject] public ToastService toastService { get; set; }

        [Inject] public NavigationManager Navigation { get; set; }

        private Trabajadores trabajadorSeleccionado;

        private bool isEditing = false;

        private string InputClass => "peer h-full w-full rounded-[7px] border border-blue-200 border-t-transparent bg-transparent px-3 py-2.5 font-sans text-sm font-normal text-blue-700 outline outline-0 transition-all placeholder-shown:border placeholder-shown:border-cyan-200 placeholder-shown:border-t-cyan-200 focus:border-2 focus:border-purple-500 focus:border-t-transparent focus:outline-0 disabled:border-0 disabled:bg-gray-50";

        private List<string> PuestosTrabajo = new List<string>
        {
            "Médico/a",
            "Enfermero/a",
            "T. Laboratorio",
            "T. Radiología",
            "Auxiliar de limpieza",
            "Fisioterapeuta"
        };

        private List<string> Genero = new List<string> { "F", "M", "O" };
        private List<string> Horario = new List<string> { "M", "T", "N" };

        protected override async Task OnParametersSetAsync()
        {
            // Obtener los detalles del trabajador del ID proporcionado
            trabajadorSeleccionado = await context.Trabajadores.FindAsync(int.Parse(TrabId));
        }

        private async void HandleValidSubmit()
        {

            await trabajadorService.UpdateTrabajador(trabajadorSeleccionado);

            ShowNotification();
            
            isEditing = false;

            //NavigateBack();
        }

        private void ShowNotification()
        {
            this.toastService.ShowToast(new ToastOption() { Title="Exito",Content="Trabajador actualizado correctamente"});
            StateHasChanged();
        }

        private void NavigateBack()
        {
            Navigation.NavigateTo("/api/trabajadores");
        }
    }
}
