using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProyectoTFG.Componentes;
using ProyectoTFG.Componentes.Widgets.Toast;
using ProyectoTFG.Data;
using ProyectoTFG.Interfaces;

namespace ProyectoTFG.Pages.PaginaCitas
{
    public partial class VistaGestionarCita : ComponentBase
    {
        [Parameter] public string? idCita { get; set; }

        [Inject] public CitasService citasService { get; set; }
        [Inject] public TrabajadorService TrabajadorService{ get; set; }
        [Inject] public PacientesService PacientesService{ get; set; }


        [Inject] NavigationManager Navigation { get; set; }

        [Inject] public ToastService toastService { get; set; }

        private Cita citaSeleccionada = new();

        private bool isEditing = false;

        private List<Trabajadores> trabajadores = new List<Trabajadores>();
        private List<Pacientes> pacientes = new List<Pacientes>();

        private List<string> Estado = new List<string> { "Aceptada", "Rechazada", "Pendiente"};


        private async Task HandleValidSubmit()
        {
            try
            {
                // Primero, obtenemos la última versión de la cita de la base de datos.
                var cita = await citasService.GetCitas(citaSeleccionada.idCita);
                // Luego, copiamos los valores que queremos cambiar desde `citaSeleccionada`.
                cita.TrabajadorId = citaSeleccionada.TrabajadorId;
                cita.PacienteId = citaSeleccionada.PacienteId;
                cita.Fecha = citaSeleccionada.Fecha;
                cita.Estado = citaSeleccionada.Estado;
                // Por último, intentamos actualizar la cita en la base de datos.
                await citasService.UpdateCitas(cita);
                ShowNotification("Exito","Cita actualizada correctamente.");
            }
            catch (DbUpdateConcurrencyException)
            {
                ShowNotification("Error inespera", "La cita a sido modificada por otro usuario");
            }
            catch (Exception e)
            {
                ShowNotification("Error",e.ToString());
            }
        }


        private void ShowNotification(string t, string c)
        {
            this.toastService.ShowToast(new ToastOption() { Title = t, Content = c });
            StateHasChanged();
        }
        protected override async Task OnInitializedAsync()
        {

            citaSeleccionada = await citasService.GetCitas(int.Parse(idCita));
            trabajadores = (List<Trabajadores>)await TrabajadorService.GetAllTrabajadores();
            pacientes = (List<Pacientes>)await PacientesService.GetAllPacientes();
        }

        private void NavigateBack()
        {
            Navigation.NavigateTo(RutasDefinidas.VistaCitas);
        }
    }

}
