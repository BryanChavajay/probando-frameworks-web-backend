using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MinimalPetShelter.Modelos
{
    [Table("tiposMascotas")]
    public class TipoMascota
    {
        [Column("codigotipomascota")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodigoTipoMascota { get; set; }

        [Column("tipo")]
        [Required]
        [StringLength(128)]
        public string? Tipo { get; set; }
    }
}
