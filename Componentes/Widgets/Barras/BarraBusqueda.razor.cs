using Microsoft.AspNetCore.Components;

namespace ProyectoTFG.Componentes.Widgets.Barras
{
    public partial class BarraBusqueda
    {
        [Parameter] public string Placeholder { get; set; }
        private string itemBuscado;
        [Parameter]
        public string ItemBuscado
        {
            get => itemBuscado;
            set
            {
                if (itemBuscado != value) // this check is important to avoid stack overflow
                {
                    itemBuscado = value;
                    ItemBuscadoChanged.InvokeAsync(value);
                }
            }
        }
        [Parameter] public EventCallback<string> ItemBuscadoChanged { get; set; }
        [Parameter] public EventCallback OnBuscar { get; set; }
        [Parameter] public EventCallback OnReiniciarLista { get; set; }

        [Parameter] public string RutaPredefinida { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }

        public void IrAFormulario(string ruta)
        {
            NavigationManager.NavigateTo(ruta);
        }

        private void UpdateItemBuscado(ChangeEventArgs e)
        {
            ItemBuscado = e.Value.ToString();
        }
    }

}
