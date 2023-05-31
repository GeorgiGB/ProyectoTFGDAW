using Microsoft.AspNetCore.Components;

namespace ProyectoTFG.Componentes.Widgets
{
    public partial class RutaConIcono
    {
        [Parameter] public string NombreRuta { get; set; } = "/";
        [Parameter] public string icono { get; set; }
    }
}
