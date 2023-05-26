using Microsoft.AspNetCore.Components;

namespace ProyectoTFG.Componentes.Widgets
{
    public partial class InputEstandar
    {
        [Parameter] public string TextoMostrado { get; set; } = string.Empty;

        [Parameter] public string ReciboValor { get; set; } = string.Empty;

        [Parameter] public string? TipoInput { get; set; } = "text";

        private string InputClass => "peer h-full w-full rounded-[7px] border border-blue-gray-200 border-t-transparent bg-transparent px-3 py-2.5 font-sans text-sm font-normal text-blue-gray-700 outline outline-0 transition-all placeholder-shown:border placeholder-shown:border-blue-gray-200 placeholder-shown:border-t-blue-gray-200 focus:border-2 focus:border-pink-500 focus:border-t-transparent focus:outline-0 disabled:border-0 disabled:bg-blue-gray-50";
    }
}
