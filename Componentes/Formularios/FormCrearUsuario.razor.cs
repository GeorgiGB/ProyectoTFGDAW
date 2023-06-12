using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using ProyectoTFG.Componentes.Widgets.Toast;
using ProyectoTFG.Data;
using ProyectoTFG.Data.Autentificacion;
using System.ComponentModel.DataAnnotations;

namespace ProyectoTFG.Componentes.Formularios
{
    public partial class FormCrearUsuario
    {
        private EstandarModel registroModel = new EstandarModel();

        [Inject] public NavigationManager Navigation { get; set; }
        [Inject] public ToastService? Toast { get; set; }

        [Inject] public UserManager<IdentityUser> userManager { get; set; }

        [Inject] public SignInManager<IdentityUser> signInManager { get; set; }

        [Inject] public UsuarioService usuarioService { get; set; }

        private async Task HandleValidSubmit()
        {
            var user = new IdentityUser { UserName = registroModel.Username };
            var result = await userManager.CreateAsync(user, registroModel.Password);

            if (result.Succeeded)
            {
                await usuarioService.AddUserToRoleAsync(user, "Admin");
                Toast?.ShowToast(new ToastOption() { Title = "Exito!", Content = "Se ha enviado la notificacion" });
                Navigation.NavigateTo("/login");
            }
            else
            {
                Toast?.ShowToast(new ToastOption() { Title = "Fallido!", Content = "No se ha podido iniciar sesion" });
            }
        }
    }
}
