using Syncfusion.Blazor.Notifications;

namespace ProyectoTFG.Componentes
{
    public partial class Notificador
    {
        //Notificacion emergente
        private SfToast? ToastObj;
        private string toastContent = "";
        private string toastClass = "";
        private int toastDuration = 3000;

        /*
         * Notificacion flotante que constara de un titulo y un cuerpo
        */
        private async Task NotificacionFlotante(string content, string cssClass, int duration)
        {
            // Set the content of the toast
            toastContent = content;

            // Set the color of the toast using Tailwind CSS classes
            toastClass = cssClass;

            // Set the duration of the toast (in milliseconds)
            toastDuration = duration;

            // Show the toast
            await ToastObj.ShowAsync(new ToastModel
            {
                Title = toastContent,
                Content = toastContent,
                Timeout = toastDuration,
                Icon = "success"

            });

        }
    }
}
