using Microsoft.AspNetCore.Components;

namespace ProyectoTFG.Componentes.Widgets.Barras
{
    public partial class BarraSuperior
    {
        [Parameter] public bool MostrarAtras { get; set; } = false;
        [Inject] public NavigationManager Navigation { get; set; }
        void IrAPaginaAnterior()
        {
            string rutaAnterior = Navigation.Uri.Replace(Navigation.Uri.Split('/').Last(), "");
            if (rutaAnterior == RutasDefinidas.VistaTrabajadores || rutaAnterior == RutasDefinidas.CrearTrabajador)
            {
                // Redirigir a la página de lista de trabajadores
                Navigation.NavigateTo(RutasDefinidas.VistaTrabajadores);
            }
            else if (rutaAnterior == RutasDefinidas.CrearTrabajador)
            {
                // Redirigir a la página de creación de trabajador
                Navigation.NavigateTo(RutasDefinidas.CrearTrabajador);
            }
            else
            {
                // Redirigir a una página por defecto o mostrar un mensaje de error
                Navigation.NavigateTo("/");
            }
        }

    }
}
