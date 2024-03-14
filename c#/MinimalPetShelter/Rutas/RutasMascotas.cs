using Microsoft.EntityFrameworkCore;
using MinimalPetShelter.Datos;
using MinimalPetShelter.db;
using MinimalPetShelter.Modelos;

namespace MinimalPetShelter.Rutas
{
    public static class RutasMascotas
    {
        public static void Mascota(WebApplication app)
        {
            app.MapGet("/api/v1/mascota/", async (AppDbContext dbContext) =>
            {
                var mascotasDb = await dbContext.Mascotas.ToListAsync();
                return mascotasDb.Select(a => new MascotaSalida
                {
                    CodigoMascota = a.CodigoMascota,
                    CodigoRaza = a.CodigoRaza,
                    CodigoTipoMascota = a.CodigoTipoMascota,
                    FechaIngreso = a.FechaIngreso,
                    FechaNacimiento = a.FechaNacimiento,
                    Nombre = a.Nombre,
                    Observaciones = a.Observaciones
                }).ToList();
            })
            .RequireAuthorization() //Configura la ruta para solicitar un JWT - Bearer
            .WithTags(["Mascotas"])
            .WithOpenApi(operations => new(operations)
            {
                Summary = "Devuelve una lsita de todas las mascotas registradas"
            })
            .Produces<List<MascotaSalida>>();

            app.MapGet("/api/v1/mascota/{id}", async (int id, AppDbContext dbContext) =>
            {
                var mascota = await dbContext.Mascotas.FindAsync(id);

                if (mascota == null)
                {
                    return Results.NotFound();
                }

                var mascotaSalida = new MascotaSalida
                {
                    CodigoMascota = mascota.CodigoMascota,
                    CodigoRaza = mascota.CodigoRaza,
                    CodigoTipoMascota = mascota.CodigoTipoMascota,
                    FechaIngreso = mascota.FechaIngreso,
                    FechaNacimiento = mascota.FechaNacimiento,
                    Nombre = mascota.Nombre,
                    Observaciones = mascota.Observaciones
                };

                return Results.Ok(mascotaSalida);
            })
            .RequireAuthorization() //Configura la ruta para solicitar un JWT - Bearer
            .WithTags(["Mascotas"])
            .WithOpenApi(operations => new(operations)
            {
                Summary = "Busca una mascota por su id"
            })
            .Produces<MascotaSalida>();

            app.MapPost("/api/v1/mascota/crear", async (AppDbContext dbContext, MascotaIn mascotaIn) =>
            {
                var mascotaDb = new Mascota
                {
                    CodigoRaza = mascotaIn.CodigoRaza,
                    CodigoTipoMascota = mascotaIn.CodigoTipoRaza,
                    FechaIngreso = mascotaIn.FechaIngreso,
                    FechaNacimiento = mascotaIn.FechaNacimiento,
                    Nombre = mascotaIn.Nombre,
                    Observaciones = mascotaIn.Observaciones,
                };

                dbContext.Mascotas.Add(mascotaDb);

                await dbContext.SaveChangesAsync();

                return Results.Ok(mascotaDb);
            })
            .RequireAuthorization() //Configura la ruta para solicitar un JWT - Bearer
            .WithTags(["Mascotas"])
            .WithOpenApi(operations => new(operations)
            {
                Summary = "Busca una mascota por su id"
            })
            .Produces<MascotaSalida>();
        }
    }
}
