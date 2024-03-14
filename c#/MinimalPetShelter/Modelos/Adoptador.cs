using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MinimalPetShelter.Modelos
{
    [Table("adoptadores")]
    public class Adoptador
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("codigoadoptador")]
        public int CodigoAdoptador { get; set; }

        [Required]
        [StringLength(128)]
        [Column("nombre")]
        public string? Nombre { get; set; }

        [Required]
        [StringLength(256)]
        [Column("direccion")]
        public string? Direccion { get; set; }

        [Required]
        [StringLength(8)]
        [Column("telefono")]
        public string? Telefono { get; set; }

        [StringLength(128)]
        [Column("correoelectronico")]
        public string? CorreoElectronico { get; set; }
    }
}
