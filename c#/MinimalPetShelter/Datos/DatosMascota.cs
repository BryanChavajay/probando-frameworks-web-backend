using System.ComponentModel.DataAnnotations;

namespace MinimalPetShelter.Datos
{
    public class MascotaBase
    {
        public string? Nombre { get; set; }

        public DateOnly? FechaNacimiento { get; set; }

        public DateOnly? FechaIngreso { get; set; }

        public string? Observaciones { get; set; }
    }

    public class MascotaIn : MascotaBase 
    {
        [Required]
        public int CodigoTipoRaza { get; set; }

        [Required]
        public int CodigoRaza { get; set; }

    }

    public class MascotaSalida : MascotaBase
    {
        public int CodigoMascota { get; set; }

        public int CodigoTipoMascota { get; set; }

        public int CodigoRaza { get; set; }

        public static List<MascotaSalida> Examples => new()
        {
            new()
            {
                CodigoMascota = 1,
                Nombre = "Moca",
                FechaNacimiento = new DateOnly(2020, 12, 31),
                FechaIngreso = new DateOnly(2020, 12, 31),
                Observaciones = "Moca es adorable",
                CodigoRaza = 1,
                CodigoTipoMascota = 1
            },
            new()
            {
                CodigoMascota = 2,
                Nombre = "Late",
                FechaNacimiento = new DateOnly(2020, 12, 31),
                FechaIngreso = new DateOnly(2020, 12, 31),
                Observaciones = "Moca es adorable",
                CodigoRaza = 1,
                CodigoTipoMascota = 2
            }
        };
    }
}
