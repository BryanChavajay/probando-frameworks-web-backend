using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MinimalPetShelter.Modelos
{
    [Table("adopciones")]
    public class Adopcion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("codigoadopcion")]
        public int CodigoAdopcion { get; set; }

        [ForeignKey("Mascota")]
        [Column("codigomascota")]
        public int CodigoMascota { get; set; }

        [ForeignKey("Adoptador")]
        [Column("codigoadoptador")]
        public int CodigoAdoptador { get; set; }

        [Column("fechaadopcion")]
        public DateOnly FechaAdopcion { get; set; }

        [ForeignKey("Usuario")]
        [Column("codigousuario")]
        public int CodigoUsuario { get; set; }

        [StringLength(256)]
        [Column("observaciones")]
        public string? Observaciones { get; set; }

        public virtual Mascota? Mascota { get; set; }

        public virtual Adoptador? Adoptador { get; set; }

        public virtual Usuario? Usuario { get; set; }
    }
}
