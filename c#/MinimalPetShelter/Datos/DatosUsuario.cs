using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MinimalPetShelter.Datos
{
    public class UsuarioBase
    {
        [Required]
        [StringLength(50)]
        public string? PrimerNombre { get; set; }

        [StringLength(50)]
        public string? SegundoNombre { get; set; }

        [StringLength(50)]
        public string? OtrosNombres { get; set; }

        [Required]
        [StringLength(50)]
        public string? PrimerApellido { get; set; }

        [StringLength(50)]
        public string? SegundoApellido { get;set; }

        [Required]
        [StringLength(50)]
        public string? Usuario { get; set; }

        [Required]
        [StringLength(50)]
        public string? Correo { get; set; }
    }

    public class UsuarioIngreso : UsuarioBase
    {
        [Required]
        [StringLength(265)]
        public string? Contrasenia { get; set; }
    }

    public class UsuarioSalida : UsuarioBase 
    {
        public int CodigoUsuario { get; set; }

        // Ejemplos de datos adicionales para documentación
        public static List<UsuarioSalida> Examples => new()
        {
            new() {
                CodigoUsuario = 1,
                PrimerNombre = "Rick",
                SegundoNombre = "Doe",
                OtrosNombres = "Doe",
                PrimerApellido = "Smith",
                SegundoApellido = "Sanchez",
                Usuario = "rickdsmith",
                Correo = "rick@example.com"
            },
            new UsuarioSalida
            {
                CodigoUsuario = 2,
                PrimerNombre = "Rick",
                SegundoNombre = "",
                OtrosNombres = "",
                PrimerApellido = "Smith",
                SegundoApellido = "",
                Usuario = "rickdsmith",
                Correo = "rick@example.com"
            }
        };
    }

    public class UsuarioDB : UsuarioBase
    {
        public int CodigoUsuario { get; set;}

        [Required]
        [StringLength(256)]
        public string? Contrasenia { get; set;}
    }

    public class UsuarioLogin
    {
        [Required]
        public required string Username { get; set; }

        [Required]
        public required string Password { get; set; }
    }
}
