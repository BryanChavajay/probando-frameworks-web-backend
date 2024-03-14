using Microsoft.EntityFrameworkCore;
using MinimalPetShelter.Datos;
using MinimalPetShelter.db;
using MinimalPetShelter.Modelos;

namespace MinimalPetShelter.Controladores
{
    public class ControlAdoptador
    {
        public async Task<List<AdoptadorSalida>> ObtenerAdoptadores(AppDbContext dbContext)
        {
            var adoptadores = await dbContext.Adoptadores.ToListAsync();

            return adoptadores.Select(a => new AdoptadorSalida
            {
                CodigoAdoptador = a.CodigoAdoptador,
                Nombre = a.Nombre,
                Direccion = a.Direccion,
                Telefono = a.Telefono,
                Correo = a.CorreoElectronico
            }).ToList();
        }

        public async Task<AdoptadorSalida?> ObtenerAdoptadorPorId(AppDbContext dbContext, int id)
        {
            var adoptador = await dbContext.Adoptadores.FindAsync(id);

            if (adoptador == null) { return null; }

            return new AdoptadorSalida 
            {
                CodigoAdoptador = adoptador.CodigoAdoptador,
                Nombre = adoptador.Nombre, 
                Direccion = adoptador.Direccion, 
                Correo = adoptador.CorreoElectronico, 
                Telefono = adoptador.Telefono 
            };
        }

        public async Task<AdoptadorSalida> CrearNuevoAdoptador(AppDbContext dbContext, AdoptadorIn adoptadorIn)
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

            return new AdoptadorSalida
            {
                CodigoAdoptador = adoptadorDb.CodigoAdoptador,
                Nombre = adoptadorDb.Nombre,
                Direccion = adoptadorDb.Direccion,
                Correo = adoptadorDb.CorreoElectronico,
                Telefono = adoptadorDb.Telefono
            };
        }
    }
}
