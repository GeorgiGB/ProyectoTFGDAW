using Microsoft.AspNetCore.Components;
using ProyectoTFG.Componentes.Widgets.Toast;
using ProyectoTFG.Data;
using System.ComponentModel.DataAnnotations;

namespace ProyectoTFG.Componentes.Formularios
{
    public partial class FormSolicitarCita
    {
        private Cita NuevaCita = new();

        [Inject] CitasService citaService { get; set; }

        [Inject] public ToastService toastService { get; set; }

        private async void SolicitarCita()
        {
            NuevaCita.Estado = "Pendiente";
            await citaService.AgregarCitas(NuevaCita);
        }

        private void Notificacion(string Titulo, string Contenido)
        {
            // Show the toast
            this.toastService.ShowToast(new ToastOption() { Title = Titulo, Content = Contenido });
        }
    }
}
