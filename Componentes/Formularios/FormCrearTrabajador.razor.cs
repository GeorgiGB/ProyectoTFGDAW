using Microsoft.AspNetCore.Components;
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
        [Inject] public NavigationManager navigationManager { get; set; }

        public bool estaEnviando = false;

        [Required(ErrorMessage = "Falta un mensaje")]
        public string ErrorMessage { get; set; }
        public async Task CrearTrabajador()
        {
            estaEnviando = true;
            try
            {
                await GuardarNuevoTrabajador();
                NuevoTrabajador = new();
               /*ShowToast();*/
                LimpiarYActualizarFormulario();
                estaEnviando = false;
                navigationManager.NavigateTo("/api/trabajadores");
            }
            catch(Exception ex)
                {
                ErrorMessage = ex.Message;
                estaEnviando = false;
                StateHasChanged();
            }
            StateHasChanged();
        }

        async Task GuardarNuevoTrabajador()
        {
            NuevoTrabajador.TrabFechaContrato = DateTime.Now;
            context?.Trabajadores.Add(NuevoTrabajador);
        }

        public void LimpiarYActualizarFormulario()
        {
            NuevoTrabajador.TrabNombre = string.Empty;
            NuevoTrabajador.TrabApellido = string.Empty;
            NuevoTrabajador.TrabDireccion = string.Empty;
            NuevoTrabajador.TrabPuesto = string.Empty;
            NuevoTrabajador.TrabHorario= string.Empty;
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
    }
}
