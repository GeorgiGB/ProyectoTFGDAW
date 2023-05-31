using Microsoft.AspNetCore.Components;
using ProyectoTFG.Data;
using ProyectoTFG.Data.Toast;

namespace ProyectoTFG.Pages.PaginasTrabajadores
{
    public partial class VistaDetalleTrabajador : ComponentBase
    {
        [Parameter] public string TrabId { get; set; }

        [Inject] public HospitalContext context { get; set; }

        [Inject] public TrabajadorService TrabajadorService { get; set; }

        [Inject] public ToastService ToastService { get; set; }

        [Inject] public NavigationManager RutaIr { get; set; }

        private Trabajadores trabajadorSeleccionado;

        // Método para borrar el trabajador
        private async void BorrarTrabajador()
        {
            if (trabajadorSeleccionado.IdTrab != null)
            {
                await TrabajadorService.DeleteTrabajador((int)trabajadorSeleccionado.IdTrab);
            }
            
        }


        protected override async Task OnParametersSetAsync()
        {
            // Obtener los detalles del trabajador del ID proporcionado
            trabajadorSeleccionado = await context.Trabajadores.FindAsync(int.Parse(TrabId));
        }

        private void NavigateBack()
        {
            RutaIr.NavigateTo("/api/trabajadores");
        }

        private async void HandleValidSubmit()
        {
            await TrabajadorService.UpdateTrabajador(trabajadorSeleccionado);
            ToastService.ShowToast(new ToastOption
            {
                Title = "Exito",
                Content = "El trabajador se ha actualizado correctamente"
            });
        }
    }
}
