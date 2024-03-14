using System.ComponentModel.DataAnnotations;

namespace MinimalPetShelter.Datos
{
    public class AdopcionBase
    {
        [Required]
        public DateOnly FechaAdopcion {  get; set; }

        public string? observaciones { get; set; }
    }

    public class AdopcionIn : AdopcionBase 
    {
        [Required]
        public int CodigoMascota { get; set; }

        [Required]
        public int CodigoAdoptador { get; set; }

        [Required]
        public int CodigoUsuario { get; set; }
    }

    public class AdopcionSalida : AdopcionBase
    {
        public int CodigoAdopcion { get; set; }

        public int CodigoMascota { get; set; }

        public int CodigoAdoptador { get; set; }

        public int CodigoUsuario { get; set; }
    }
}
