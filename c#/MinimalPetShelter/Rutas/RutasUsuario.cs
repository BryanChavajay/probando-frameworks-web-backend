using Microsoft.EntityFrameworkCore;
using MinimalPetShelter.Datos;
using MinimalPetShelter.db;
using MinimalPetShelter.Modelos;

namespace MinimalPetShelter.Rutas
{
    public static class RutasUsuario
    {
        public static void Usuarios(WebApplication app)
        {
            app.MapGet("/api/v1/usuario/", async (AppDbContext dbContext) =>
            {
                var usuarios = await dbContext.Usuarios.ToListAsync();

                return usuarios.Select(a => new UsuarioSalida
                {
                    CodigoUsuario = a.CodigoUsuario,
                    PrimerNombre = a.PrimerNombre,
                    SegundoNombre = a.SegundoNombre,
                    OtrosNombres = a.OtrosNombres,
                    PrimerApellido = a.PrimerApellido,
                    SegundoApellido = a.SegundoApellido,
                    Correo = a.CorreoElectronico,
                    Usuario = a.NombreUsuario
                });
            })
            .RequireAuthorization() //Configura la ruta para solicitar un JWT - Bearer
            .WithTags(["Usuarios"])
            .WithOpenApi(operations => new(operations)
            {
                Summary = "Lista todas los usuarios registrados"
            })
            .Produces<List<UsuarioSalida>>();

            app.MapGet("/api/v1/usuario/{id}", async (int id, AppDbContext dbContext) =>
            {
                var usuario = await dbContext.Usuarios.FindAsync(id);

                if (usuario == null)
                {
                    return Results.NotFound();
                }

                var usuarioSalida = new UsuarioSalida
                {
                    CodigoUsuario = usuario.CodigoUsuario,
                    PrimerNombre = usuario.PrimerNombre,
                    SegundoNombre = usuario.SegundoNombre,
                    OtrosNombres = usuario.OtrosNombres,
                    PrimerApellido = usuario.PrimerApellido,
                    SegundoApellido = usuario.SegundoApellido,
                    Correo = usuario.CorreoElectronico,
                    Usuario = usuario.NombreUsuario
                };

                return Results.Ok(usuarioSalida);
            })
            .RequireAuthorization() //Configura la ruta para solicitar un JWT - Bearer
            .WithTags(["Usuarios"])
            .WithOpenApi(operations => new(operations)
            {
                Summary = "Busca a un usuario por su ID"
            })
            .Produces<UsuarioSalida>()
            .Produces(404);

            app.MapPost("/api/v1/usuario/crear", async (UsuarioIngreso usuarioIn, AppDbContext dbContext) =>
            {
                var passwordHashed = BCrypt.Net.BCrypt.HashPassword(usuarioIn.Contrasenia);

                var usuarioDb = new Usuario
                {
                    PrimerNombre = usuarioIn.PrimerNombre,
                    SegundoNombre = usuarioIn.SegundoNombre,
                    OtrosNombres = usuarioIn.OtrosNombres,
                    PrimerApellido = usuarioIn.PrimerApellido,
                    SegundoApellido = usuarioIn.SegundoApellido,
                    CorreoElectronico = usuarioIn.Correo,
                    NombreUsuario = usuarioIn.Usuario,
                    Contrasenia = passwordHashed
                };

                dbContext.Usuarios.Add(usuarioDb);

                await dbContext.SaveChangesAsync();

                var usuarioSalida = new UsuarioSalida
                {
                    CodigoUsuario = usuarioDb.CodigoUsuario,
                    PrimerNombre = usuarioDb.PrimerNombre,
                    SegundoNombre = usuarioDb.SegundoNombre,
                    OtrosNombres = usuarioDb.OtrosNombres,
                    PrimerApellido = usuarioDb.PrimerApellido,
                    SegundoApellido = usuarioDb.SegundoApellido,
                    Correo = usuarioDb.CorreoElectronico,
                    Usuario = usuarioDb.NombreUsuario
                };

                return usuarioSalida;
            })
            .WithTags(["Usuarios"])
            .WithOpenApi(operations => new(operations)
            {
                Summary = "Registra un nuevo usuario"
            })
            .Produces<UsuarioSalida>();
        }
    }
}
