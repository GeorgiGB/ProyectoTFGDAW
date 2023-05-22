using Microsoft.AspNetCore.Components;
using ProyectoTFG.Data;

namespace ProyectoTFG.Componentes.Formularios
{
    public partial class FormPaciente
    {
        private HospitalContext _context;

        [Inject] public Notificator Notification { get; set; }

        private Pacientes paciente = new();

        public bool estaEnviando = false;

        public void LimpiarYActualizarFormulario()
        {
            paciente.PacNombre = string.Empty;
            paciente.PacApellido = string.Empty;
            paciente.PacDireccion= string.Empty;
            paciente.PacGs = string.Empty;//grupo sanguineo pasarlo con un dropdown
            StateHasChanged();
        }
    }
}
