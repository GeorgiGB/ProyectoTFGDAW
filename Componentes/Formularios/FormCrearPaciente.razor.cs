using Microsoft.AspNetCore.Components;
using ProyectoTFG.Componentes.Widgets.Toast;
using ProyectoTFG.Data;

namespace ProyectoTFG.Componentes.Formularios
{
    public partial class FormCrearPaciente : ComponentBase
    {
        private Pacientes NuevoPaciente = new();
        [Inject] public PacientesService pacService { get; set; }

        [Inject] public NavigationManager Navigation { get; set; }

        [Inject] public ToastService toastService { get; set; }

        private List<string> Genero = new List<string> { "F", "M", "O" };

        public bool isEditing = true;

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


        public async Task EnviarDatosNuevoPac()
        {
			isEditing = false;
            try
            {
				await CrearPaciente();
				NuevoPaciente = new();
				
                LimpiarYActualizarFormulario();
				Notificacion("Exito", "Paciente Creado");
				isEditing = true;
			}
            catch(Exception e)
                {
                Notificacion("Exito", e.Message);
                LimpiarYActualizarFormulario();
            }
        }

        async Task CrearPaciente()
        {
            NuevoPaciente.PacFechRegistro = DateTime.Now;
            await pacService.AgregarPacientes(NuevoPaciente);
            StateHasChanged();
        }

        

        private void NavigateBack()
        {
            Navigation.NavigateTo(RutasDefinidas.VistaPacientes);
        }


        public void LimpiarYActualizarFormulario()
        {
            NuevoPaciente.PacNombre = string.Empty;
            NuevoPaciente.PacApellido = string.Empty;
            NuevoPaciente.PacDireccion = string.Empty;
            NuevoPaciente.PacSexo = string.Empty;
            NuevoPaciente.PacGs = string.Empty;//grupo sanguineo pasarlo con un dropdown
            StateHasChanged();
        }

		private void Notificacion(string Titulo, string Contenido)
		{
			// Show the toast
			this.toastService.ShowToast(new ToastOption() { Title = Titulo, Content = Contenido });
		}
	}
}
