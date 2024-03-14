using Microsoft.EntityFrameworkCore;
using MinimalPetShelter.Datos;
using MinimalPetShelter.db;
using MinimalPetShelter.Modelos;

namespace MinimalPetShelter.Rutas
{
    public static class RutasAdopcion
    {
        public static void Adopciones(WebApplication app)
        {
            app.MapGet("/api/v1/adopcion/", async (AppDbContext dbContext) =>
            {
                var adopciones = await dbContext.Adopciones.ToListAsync();

                return adopciones.Select(a => new AdopcionSalida
                {
                    CodigoAdopcion = a.CodigoAdopcion,
                    CodigoAdoptador = a.CodigoAdoptador,
                    CodigoMascota = a.CodigoMascota,
                    CodigoUsuario = a.CodigoUsuario,
                    FechaAdopcion = a.FechaAdopcion,
                    observaciones = a.Observaciones
                }).ToList();
            })
            .RequireAuthorization() //Configura la ruta para solicitar un JWT - Bearer
            .WithTags(["Adopciones"])
            .WithOpenApi(operations => new(operations)
            {
                Summary = "Lista todas las adopciones registradas"
            })
            .Produces<List<AdopcionSalida>>();

            app.MapGet("/api/v1/adopcion/{id}", async (int id, AppDbContext dbContext) =>
            {
                var adopcion = await dbContext.Adopciones.FindAsync(id);

                if (adopcion == null)
                {
                    return Results.NotFound();
                }

                var adopcionSalida = new AdopcionSalida
                {
                    CodigoAdopcion = adopcion.CodigoAdopcion,
                    CodigoAdoptador = adopcion.CodigoAdoptador,
                    CodigoMascota = adopcion.CodigoMascota,
                    CodigoUsuario = adopcion.CodigoUsuario,
                    FechaAdopcion = adopcion.FechaAdopcion,
                    observaciones = adopcion.Observaciones
                };

                return Results.Ok(adopcionSalida);
            })
            .RequireAuthorization() //Configura la ruta para solicitar un JWT - Bearer
            .WithTags(["Adopciones"])
            .WithOpenApi(operations => new(operations)
            {
                Summary = "Buscar una adopción por su ID"
            })
            .Produces<AdopcionSalida>()
            .Produces(400);

            app.MapPost("/api/v1/adopcion/crear", async (AdopcionIn adopcionIn, AppDbContext dbContext) =>
            {
                var adopcionDb = new Adopcion
                {
                    CodigoAdoptador = adopcionIn.CodigoAdoptador,
                    CodigoMascota = adopcionIn.CodigoMascota,
                    CodigoUsuario = adopcionIn.CodigoUsuario,
                    FechaAdopcion = adopcionIn.FechaAdopcion,
                    Observaciones = adopcionIn.observaciones
                };

                dbContext.Adopciones.Add(adopcionDb);

                await dbContext.SaveChangesAsync();

                var adopcionSalida = new AdopcionSalida
                {
                    CodigoAdopcion = adopcionDb.CodigoAdopcion,
                    CodigoAdoptador = adopcionDb.CodigoAdoptador,
                    CodigoMascota = adopcionDb.CodigoMascota,
                    CodigoUsuario = adopcionDb.CodigoUsuario,
                    FechaAdopcion = adopcionDb.FechaAdopcion,
                    observaciones = adopcionDb.Observaciones
                };

                return adopcionSalida;
            })
            .RequireAuthorization() //Configura la ruta para solicitar un JWT - Bearer
            .WithTags(["Adopciones"])
            .WithOpenApi(operations => new(operations)
            {
                Summary = "Registrar una nueva adopcion"
            })
            .Produces<AdopcionSalida>();
        }
    }
}
