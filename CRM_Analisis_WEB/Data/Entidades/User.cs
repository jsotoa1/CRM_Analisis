using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoGraduacion_WEB.Data.Entidades
{
    public class User : IdentityUser
    {
        [MaxLength(20)]
        [Required]
        public string Documento { get; set; }

        [MaxLength(50)]
        [Required]
        public string PrimerNombre { get; set; }

        [MaxLength(50)]
        public string SegundoNombre { get; set; }

        [MaxLength(50)]
        [Required]
        public string PrimerApellido { get; set; }

        [MaxLength(50)]
        public string SegundoApellido { get; set; }

        [MaxLength(250)]
        [Required]
        public string Direccion { get; set; }

        [Display(Name = "Imagen")]
        public Guid ImageId { get; set; }

        //TODO: Pending to put the correct paths
        [Display(Name = "Imagen")]
        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://localhost:44390/images/noimage.png"
            : $"https://onsale.blob.core.windows.net/users/{ImageId}";

        public Rol rol { get; set; }
        public bool estado { get; set; }

        public string FullName => $"{PrimerNombre} {SegundoNombre} {PrimerApellido} {SegundoApellido}";

    }

}
