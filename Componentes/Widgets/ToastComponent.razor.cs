using Microsoft.AspNetCore.Components;
using ProyectoTFG.Data.Toast;
using Syncfusion.Blazor.Notifications;

namespace ProyectoTFG.Componentes.Widgets
{
    public partial class ToastComponent
    {
        [Inject] public ToastService? ToastService { get; set; }

        public SfToast? Toast;

        private bool IsToastVisible { get; set; } = false;

        private ToastOption Options = new();

        protected override async void OnInitialized()
        {
            ToastService.ShowToastTrigger += (ToastOption options) =>
            {
                InvokeAsync(() =>
                {
                    this.Options.Title = options.Title;
                    this.Options.Content = options.Content;
                    this.IsToastVisible = true;
                    this.StateHasChanged();
                    Toast.ShowAsync();
                });
            };
            base.OnInitialized();
        }
    }
}
