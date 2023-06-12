using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using ProyectoTFG.Data;

namespace ProyectoTFG.Pages.PaginaUsuario
{
    public partial class Logout : ComponentBase
	{
        [Inject] public SignInManager<IdentityUser> SignInManager { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }


        protected override async Task OnInitializedAsync()
        {
            await SignInManager.SignOutAsync();
            NavigationManager.NavigateTo("/login");
        }


    }
}
