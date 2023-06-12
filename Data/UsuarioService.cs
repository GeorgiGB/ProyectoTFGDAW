using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProyectoTFG.Interfaces;

namespace ProyectoTFG.Data
{
	public class UsuarioService
	{
		private readonly UserManager<IdentityUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;

		public UsuarioService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			_userManager = userManager;
			_roleManager = roleManager;
		}

		public async Task AddUserToRoleAsync(IdentityUser usuario, string rol)
		{
			var result = await _userManager.AddToRoleAsync(usuario, rol);

			if (!result.Succeeded)
			{
				throw new Exception("No se pudo agregar el usuario al rol.");
			}
		}

		public async Task<bool> IsUserInRoleAsync(IdentityUser usuario, string rol)
		{
			return await _userManager.IsInRoleAsync(usuario, rol);
		}

		public static async Task InitializeRoles(IServiceProvider serviceProvider)
		{
			var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

			string[] roleNames = { "Admin", "Trabajador", "Usuario" };

			foreach (var roleName in roleNames)
			{
				var roleExist = await roleManager.RoleExistsAsync(roleName);
				if (!roleExist)
				{
					await roleManager.CreateAsync(new IdentityRole(roleName));
				}
			}
		}
	}
}
