using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MinimalPetShelter.Datos;
using MinimalPetShelter.db;
using MinimalPetShelter.Modelos;


namespace MinimalPetShelter.Rutas
{
    public static class RutasAdoptador
    {
        public static void Adoptador(WebApplication app)
        {
            app.MapGet("/api/v1/adoptador/", async (AppDbContext dbContext) =>
            {
                return await dbContext.Adoptadores.ToListAsync();
            })
            .RequireAuthorization() //Configura la ruta para solicitar un JWT - Bearer
            .WithTags(["Adoptador"])
            .WithOpenApi(operation => new(operation)
            {
                Summary = "Ruta para obtener un arreglo de todos los adoptadores registrados"
            })
            .Produces<List<AdoptadorSalida>>();

            app.MapGet("/api/v1/adoptador/{id}", async (int id, AppDbContext dbContext) =>
            {
                var adoptador = await dbContext.Adoptadores.FindAsync(id);

                if (adoptador == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(adoptador);
            })
            .RequireAuthorization()
            .WithTags(["Adoptador"])
            .WithOpenApi(operation => new(operation)
            {
                Summary = "Ruta para obtener un arreglo de todos los adoptadores registrados"
            })
            .Produces<AdoptadorSalida>()
            .Produces(400);

            app.MapPost("/api/v1/adoptador/crear", async (AdoptadorIn adoptadorIn, AppDbContext dbContext) =>
            {
                var adoptadorDb = new Adoptador
                {
                    Nombre = adoptadorIn.Nombre,
                    CorreoElectronico = adoptadorIn.Correo,
                    Direccion = adoptadorIn.Direccion,
                    Telefono = adoptadorIn.Telefono
                };

                dbContext.Adoptadores.Add(adoptadorDb);

                await dbContext.SaveChangesAsync();

                return Results.Ok(adoptadorDb);
            })
            .RequireAuthorization()
            .WithTags(["Adoptador"])
            .WithOpenApi(operation => new(operation)
            {
                Summary = "Ruta para registrar un nuevo adoptador"
            })
            .Produces<AdoptadorSalida>();
        }
    }
}
