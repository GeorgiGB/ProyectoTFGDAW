using Microsoft.AspNetCore.Components;

namespace ProyectoTFG.Componentes.Widgets.Barras
{
    public partial class BarraBusqueda
    {
        [Parameter] public string Placeholder { get; set; }
        [Parameter] public string Busqueda { get; set; }
        [Parameter] public string RutaPredefinida { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }

        public void IrAFormulario(string ruta)
        {
            NavigationManager.NavigateTo(ruta);
        }

    }
}
