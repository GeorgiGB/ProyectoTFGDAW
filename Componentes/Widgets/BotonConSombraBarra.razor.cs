using Microsoft.AspNetCore.Components;

namespace ProyectoTFG.Componentes.Widgets
{
    public partial class BotonConSombraBarra
    {
        [Parameter] public string TextoBoton { get; set; }

        [Parameter] public string ColorBoton { get; set; } = "blue";
    }
}
