using Microsoft.AspNetCore.Components;
using ProyectoTFG.Componentes.Widgets.Toast;
using ProyectoTFG.Data;
using System.ComponentModel.DataAnnotations;

namespace ProyectoTFG.Componentes.Formularios
{
    public partial class FormCrearTrabajador : ComponentBase
    {
        private Trabajadores NuevoTrabajador = new();

        [Inject] public ToastService toastService { get; set; }

        [Inject] public NavigationManager Navigation { get; set; }

        [Inject] public TrabajadorService trabajadorService { get; private set; }

        [Required(ErrorMessage = "Falta un mensaje")]
        public string ErrorMessage { get; set; }

        private bool isEditing = true;

        private List<string> PuestosTrabajo = new List<string>
        {
            "Médico/a",
            "Enfermero/a",
            "T. Laboratorio",
            "T. Radiología",
            "Auxiliar de limpieza",
            "Fisioterapeuta"
        };

        private readonly List<string> Genero = new (){ "F", "M", "O" };
        private readonly List<string> Horario = new() { "M", "T", "N" };
        public async Task EnviarDatosNuevoTrab()
        {
            isEditing = false;
            try
            {
                await GuardarNuevoTrabajador();
                NuevoTrabajador = new();
                
                LimpiarYActualizarFormulario();
				Notificacion("Exito", "Trabajador Creado");
				isEditing = true;
            }
            catch (Exception ex)
            {
                Notificacion("Algo ha fallado", ex.ToString());
                ErrorMessage = ex.Message;
                StateHasChanged();
            }
        }

        async Task GuardarNuevoTrabajador()
        {
            NuevoTrabajador.TrabFechaContrato = DateTime.Now;
            await trabajadorService.AgregarTrabajador(NuevoTrabajador);
			StateHasChanged();
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
        private void Notificacion(string Titulo, string Contenido)
        {
            // Show the toast
            this.toastService.ShowToast(new ToastOption() { Title = Titulo, Content = Contenido });
        }

        private void NavigateBack()
        {
            Navigation.NavigateTo(RutasDefinidas.VistaTrabajadores);
        }
    }
}
