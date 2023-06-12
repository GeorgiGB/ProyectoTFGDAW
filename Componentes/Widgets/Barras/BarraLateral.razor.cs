using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace ProyectoTFG.Componentes.Widgets.Barras
{
    public partial class BarraLateral : ComponentBase
    {
        [Inject] public SignInManager<IdentityUser> SignInManager { get; set; }
        [Inject] public UserManager<IdentityUser> UserManager { get; set; }
        [Inject] public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject] public NavigationManager NavigationManager { get; set; }
        

        private string username;


        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            if (user.Identity.IsAuthenticated)
            {
                IdentityUser identityUser = await UserManager.GetUserAsync(user);
                username = identityUser?.UserName;
            }
        }
        public async Task Logout()
        {
            await SignInManager.SignOutAsync();
            NavigationManager.NavigateTo("/"); // Navega a la página que quieras después del cierre de sesión.
        }

    }
}
