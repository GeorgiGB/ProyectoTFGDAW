using Microsoft.AspNetCore.Components;

namespace ProyectoTFG.Componentes.Widgets.Barras
{
    public partial class BarraBusqueda
    {
        [Parameter] public string Placeholder { get; set; }
        [Parameter] public string Busqueda { get; set; }

    }
}
