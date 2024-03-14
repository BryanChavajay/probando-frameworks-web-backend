using System.ComponentModel.DataAnnotations;

namespace MinimalPetShelter.Datos
{
    public class RazaIn 
    {
        [Required]
        public string? Raza {  get; set; }
    }

    public class RazaSalida
    {
        public int CodigoRaza { get; set; }

        public string? Raza { get; set; }
    }
}
