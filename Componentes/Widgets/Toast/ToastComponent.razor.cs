using Microsoft.AspNetCore.Components;
using ProyectoTFG.Componentes.Widgets.Toast;
using Syncfusion.Blazor.Notifications;

namespace ProyectoTFG.Componentes.Widgets.Toast
{
    public partial class ToastComponent
    {
        [Inject] public ToastService? ToastService { get; set; }

        public SfToast? Toast;

        private bool IsToastVisible { get; set; } = false;

        private ToastOption Options = new();

        protected override async void OnInitialized()
        {
            ToastService.ShowToastTrigger += (options) =>
            {
                InvokeAsync(() =>
                {
                    this.Options.Title = options.Title;
					this.Options.Content = options.Content;
					this.IsToastVisible = true;
					this.StateHasChanged();
					this.Toast.ShowAsync();
                });
            };
            base.OnInitialized();
        }
    }
}
