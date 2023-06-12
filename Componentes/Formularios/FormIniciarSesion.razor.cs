using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using ProyectoTFG.Componentes.Widgets.Toast;
using ProyectoTFG.Data;
using ProyectoTFG.Data.Autentificacion;
using System.ComponentModel.DataAnnotations;

namespace ProyectoTFG.Componentes.Formularios
{
    public partial class FormIniciarSesion
    {
        [Inject] public ToastService? Toast { get; set; }

        [Inject] public NavigationManager Navigation { get; set; }

        [Inject] public UserManager<IdentityUser> userManager { get; set; }

        [Inject] public SignInManager<IdentityUser> signInManager { get; set; }

        private EstandarModel loginModel = new EstandarModel();

       
        private async Task HandleValidSubmit()
        {
            var result = await signInManager.PasswordSignInAsync(loginModel.Username, loginModel.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                Navigation.NavigateTo("/api/trabajadores");
                Toast?.ShowToast(new ToastOption() { Title = "Exito!", Content = "Se ha enviado la notificacion" });
            }
            else
            {
                Toast?.ShowToast(new ToastOption() { Title = "Fallido!", Content = "No se ha podido iniciar sesion" });
            }
        }
    }
}
