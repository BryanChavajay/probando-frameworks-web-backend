using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MinimalPetShelter.Modelos
{
    [Table("mascotas")]
    public class Mascota

    {
        [Column("codigomascota")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodigoMascota { get; set; }

        [Column("nombre")]
        [Required]
        [StringLength(128)]
        public string? Nombre { get; set; }

        [Column("fechanacimiento")]
        public DateOnly? FechaNacimiento { get; set; }

        [Column("codigotipomascota")]
        [ForeignKey("TipoMascota")]
        public int CodigoTipoMascota { get; set; }

        [Column("codigoraza")]
        [ForeignKey("Raza")]
        public int CodigoRaza { get; set; }

        [Column("fechaingreso")]
        [Required]
        public DateOnly? FechaIngreso { get; set; }

        [Column("observaciones")]
        [StringLength(256)]
        public string? Observaciones { get; set; }

        public virtual TipoMascota? TipoMascota { get; set; }

        public virtual Raza? Raza { get; set; }
    }
}
