using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoGraduacion_WEB.Models
{
    public class UserViewModel
    {
        [Required]
        public string Usuario { get; set; }

        [Required]
        public string Contrasenia { get; set; }

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
        [Required]
        public string Idrol { get; set; }
        [Required]
        public bool estado { get; set; }
    }
}
