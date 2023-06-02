using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProyectoTFG.Data;
using ProyectoTFG.Data.Toast;
using System.ComponentModel.DataAnnotations;

namespace ProyectoTFG.Componentes.Formularios
{
    public partial class FormCrearTrabajador
    {
        private Trabajadores NuevoTrabajador = new();
        [Inject] public HospitalContext context { get; set; }

        [Inject] public ToastService toastService { get; set; }

        [Inject] public NavigationManager Navigation { get; set; }

        public bool isEditing = false;

        [Required(ErrorMessage = "Falta un mensaje")]
        public string ErrorMessage { get; set; }

        private List<string> PuestosTrabajo = new List<string>
        {
            "Médico/a",
            "Enfermero/a",
            "T. Laboratorio",
            "T. Radiología",
            "Auxiliar de limpieza",
            "Fisioterapeuta"
        };

        private List<string> Genero = new List<string>{"F","M","O"};
        private List<string> Horario = new List<string>{"M","T","N"};
        public async Task CrearTrabajador()
        {
            isEditing = true;
            try
            {
                await GuardarNuevoTrabajador();
                NuevoTrabajador = new();
                /*ShowToast();*/
                isEditing = false;
                Navigation.NavigateTo("/api/trabajadores");
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                isEditing = false;
                LimpiarYActualizarFormulario();
                StateHasChanged();
            }
            StateHasChanged();
        }

        async Task GuardarNuevoTrabajador()
        {
            NuevoTrabajador.TrabFechaContrato = DateTime.Now;
            context?.Trabajadores.Add(NuevoTrabajador);
            context?.SaveChanges();
        }

        public void LimpiarYActualizarFormulario()
        {
            NuevoTrabajador.TrabNombre = "";
            NuevoTrabajador.TrabApellido = string.Empty;
            NuevoTrabajador.TrabDireccion = string.Empty;
            NuevoTrabajador.TrabPuesto = string.Empty;
            NuevoTrabajador.TrabHorario = string.Empty;
            NuevoTrabajador.TrabCorreo = string.Empty;
            NuevoTrabajador.TrabSexo = string.Empty;
            NuevoTrabajador.TrabTel = string.Empty;
            StateHasChanged();
        }


        /*
         * Notificacion flotante que constara de un titulo y un cuerpo
        */
        private void ShowToast()
        {
            // Show the toast
            this.toastService.ShowToast(new ToastOption() { Title = "Exito!", Content = "Se ha guardado el usuario" });
            StateHasChanged();
        }

        private void NavigateBack()
        {
            Navigation.NavigateTo("/api/trabajadores");
        }
    }
}
