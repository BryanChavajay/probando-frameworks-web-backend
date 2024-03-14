using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MinimalPetShelter.Modelos
{
    [Table("razas")]
    public class Raza
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodigoRaza { get; set; }

        [Column("raza")]
        [Required]
        [StringLength(128)]
        public string? NombreRaza { get; set; }
    }
}
