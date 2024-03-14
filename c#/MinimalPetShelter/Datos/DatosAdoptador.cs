using System.ComponentModel.DataAnnotations;

namespace MinimalPetShelter.Datos
{
    public class AdoptadorBase
    {
        [Required]
        public string? Nombre { get; set; }

        [Required]
        public string? Direccion { get; set; }

        [StringLength(8)]
        public string? Telefono { get; set; }

        public string? Correo { get; set; }

    }

    public class AdoptadorIn : AdoptadorBase { }

    public class AdoptadorSalida : AdoptadorBase
    {
        public int CodigoAdoptador { get; set; }

        public static List<AdoptadorSalida> Examples => new()
        {
            new()
            {
                CodigoAdoptador = 1,
                Nombre = "John Doe",
                Direccion = "Ciudad de Guatemala",
                Telefono = "55555555",
                Correo = "johndoe@example.com"
            },
            new()
            {
                CodigoAdoptador = 2,
                Nombre = "Rick",
                Direccion = "Earth C137",
                Telefono = "55555555",
                Correo = "rickprime@example.com"
            }
        };
    }

}
