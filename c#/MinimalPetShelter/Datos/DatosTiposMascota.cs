using System.ComponentModel.DataAnnotations;

namespace MinimalPetShelter.Datos
{
    public class TipoMascotaIn
    {
        [Required]
        public string? Tipo {  get; set; }
    }

    public class TipoMascotaSalida
    {
        public int CodigoTipoMascota { get; set; }

        public string? Tipo { get; set; }
    }
}
