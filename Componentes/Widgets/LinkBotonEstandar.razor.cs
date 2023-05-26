using Microsoft.AspNetCore.Components;

namespace ProyectoTFG.Componentes.Widgets
{
    public partial class LinkBotonEstandar
    {
        [Parameter] public string TextoBoton { get; set; } = "Falta texto";

        [Parameter] public string RutaAIr { get; set; } = "/";
    }
}
