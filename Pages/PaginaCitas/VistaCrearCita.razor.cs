using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using ProyectoTFG.Componentes.Widgets.Toast;
using ProyectoTFG.Data;
using ProyectoTFG.Interfaces;

namespace ProyectoTFG.Pages.PaginaCitas
{
    [Authorize]
    public partial class VistaCrearCita
    {
        private Cita NuevaCita = new () {PacienteId = 1, TrabajadorId = 1, Estado = "Pendiente", Duracion = 30};

        [Inject] public CitasService citasService { get; set; }

        [Inject] public ToastService toastService { get; set; }
        private async Task OnSubmit()
        {
            try
            {
                bool resultado = await citasService.AgregarCitas(NuevaCita);

                if (resultado)
                {
                    Notificacion("Éxito", "La cita se ha creado exitosamente.");
                }
                else
                {
                    Notificacion("Error", "No se pudo crear la cita, por favor intente de nuevo.");
                }
            }
            catch (Exception ex)
            {
                Notificacion("Error", $"Ha ocurrido un error inesperado: {ex.Message}");
            }

            NuevaCita = new Cita() { Estado = Cita.EstadoCita.Pendiente.ToString() }; // Reset NuevaCita

        }

        private void Notificacion(string Titulo, string Contenido)
        {
            // Show the toast
            this.toastService.ShowToast(new ToastOption() { Title = Titulo, Content = Contenido });
        }

    }
}
