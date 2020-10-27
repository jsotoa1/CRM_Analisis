using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Analisis_WEB.Data.Entidades
{
    public class Tipo_Promocion_Anuncios
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "El campo {0} no debe ser mayor a {1} caracteres.")]
        [Required]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }
    }
}
