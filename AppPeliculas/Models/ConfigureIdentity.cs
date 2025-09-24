using Microsoft.AspNetCore.Identity;

namespace AppPeliculas.Models
{
    // Clase para configurar la identidad y crear un usuario administrador
    public class ConfigureIdentity
    {
        public static async Task CrearUsuarioAdmin(IServiceProvider serviceProvider)
        {
            // Obtener los servicios necesarios
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            // Definir el nombre del rol y del usuario administrador
            string roleName = "Administrador";
            string adminUserName = "Administrador";
            string password = "Admin123";

            // Crear el rol si no existe
            if (await roleManager.FindByNameAsync(roleName) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }

            // Crear el usuario administrador si no existe
            if (await userManager.FindByNameAsync(adminUserName) == null)
            {
                var adminUser = new User
                {
                    UserName = adminUserName
                };

                var result = await userManager.CreateAsync(adminUser, password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, roleName);
                }

                
            }

        }
    }
}
