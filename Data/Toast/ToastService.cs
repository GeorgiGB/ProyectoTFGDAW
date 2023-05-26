namespace ProyectoTFG.Data.Toast
{
    public class ToastService
    {
        public event Action<ToastOption> ShowToastTrigger;
        public async Task ShowToast(ToastOption options)
        {
            //Invoke ToastComponent to update and show the toast with messages  
            this.ShowToastTrigger.Invoke(options);
        }
    }
}
