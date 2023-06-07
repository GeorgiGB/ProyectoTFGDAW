using Microsoft.AspNetCore.Components;

namespace ProyectoTFG.Componentes.Widgets
{
    public partial class DropdownEstandar<TValue>
    {
        [Parameter] public List<TValue> Options { get; set; }
        [Parameter] public TValue SelectedValue { get; set; }
        [Parameter] public EventCallback<TValue> SelectedValueChanged { get; set; }
        [Parameter] public bool Disabled { get; set; }

        /*protected override async Task OnParametersSetAsync()
        {
            await SelectedValueChanged.InvokeAsync(SelectedValue);
        }*/
    }
}
