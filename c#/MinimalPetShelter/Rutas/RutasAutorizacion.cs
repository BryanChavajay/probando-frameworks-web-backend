using Microsoft.EntityFrameworkCore;
using MinimalPetShelter.Datos;
using MinimalPetShelter.db;
using MinimalPetShelter.Controladores;

namespace MinimalPetShelter.Rutas
{
    public class RutasAutorizacion
    {
        public static void Autorizacion(WebApplication app)
        {
            app.MapPost("/api/auth/token", async (UsuarioLogin usuario, AppDbContext dbContext) =>
            {
                var usuarioEncontrado = await dbContext.Usuarios.FirstOrDefaultAsync(
                    u => u.CorreoElectronico == usuario.Username || u.NombreUsuario == usuario.Username);

                // Verificamos si se encontro al usuario
                if (usuarioEncontrado == null)
                {
                    // Retornamos un error
                    return Results.Unauthorized();
                }

                var verificarContrasenia = BCrypt.Net.BCrypt.Verify(usuario.Password, usuarioEncontrado.Contrasenia);

                if (!verificarContrasenia)
                {
                    return Results.Unauthorized();
                }

                var token = JWTHandler.GenerateToken(usuarioEncontrado.NombreUsuario);
                return Results.Ok(new { Token = token, Type = "Bearer" });
            })
            .WithTags(["Autorizacion"])
            .WithOpenApi(operation => new(operation)
            {
                Summary = "Ruta para obtener obtener el tokend de acceso"
            });
        }
    }
}
