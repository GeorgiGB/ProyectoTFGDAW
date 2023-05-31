using Microsoft.AspNetCore.Components;

namespace ProyectoTFG.Componentes.Widgets.Botones
{
    public partial class BotonConSombra
    {
        [Parameter] public string TextoBoton { get; set; }

        [Parameter] public string ColorBoton { get; set; } = "blue";

        [Parameter] public string Ruta { get; set; } = "/";

        [Inject] private NavigationManager NavigationManager { get; set; }

        public async Task RutaAIr(string ruta)
        {
            NavigationManager.NavigateTo(ruta);
        }
    }
}
