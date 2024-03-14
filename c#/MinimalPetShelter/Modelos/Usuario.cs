using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MinimalPetShelter.Modelos
{
    [Table("usuarios")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("codigousuario")]
        public int CodigoUsuario { get; set; }

        [Required]
        [StringLength(50)]
        [Column("primernombre")]
        public string? PrimerNombre { get; set; }

        [StringLength(50)]
        [Column("segundonombre")]
        public string? SegundoNombre { get; set; }

        [StringLength(50)]
        [Column("otrosnombres")]
        public string? OtrosNombres { get; set; }

        [Required]
        [StringLength(50)]
        [Column("primerapellido")]
        public string? PrimerApellido { get; set; }

        [StringLength(50)]
        [Column("segundoapellido")]
        public string? SegundoApellido { get; set; }

        [Column("usuario")]
        [Required]
        [StringLength(50)]
        public string? NombreUsuario { get; set; }

        [Column("correoelectronico")]
        [Required]
        [StringLength(128)]
        public string? CorreoElectronico { get; set; }

        [Required]
        [StringLength(256)]
        [Column("contrasenia")]
        public string? Contrasenia { get; set; }
    }
}
