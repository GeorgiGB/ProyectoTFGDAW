using Microsoft.AspNetCore.Components;

namespace ProyectoTFG.Componentes.Widgets.GraficoDonut
{
    public partial class GraficoDonut<TItem>: ComponentBase
    {
        [Parameter] public string NombreTitulo { get; set; }
        [Parameter] public string TituloPrincipal { get; set; }
        [Parameter] public string XName { get; set; }
        [Parameter] public string YName { get; set; }

        [Parameter] public IEnumerable<TItem> DatosMostrar { get; set; }

        public IEnumerable<object> DatosMostrarAsObject
        {
            get
            {
                return DatosMostrar.Cast<object>();
            }
        }
    }
}
