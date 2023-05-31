﻿namespace ProyectoTFG.Data.Toast
{
    public class ToastService
    {
        public event Action<ToastOption> ShowToastTrigger;
        public void ShowToast(ToastOption options)
        {
            //Invoke ToastComponent to update and show the toast with messages  
            ShowToastTrigger.Invoke(options);
        }
    }
}
