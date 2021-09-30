using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoGraduacion_WEB.Data.Entidades
{
    public class Anuncio
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "El campo {0} no debe ser mayor a {1} caracteres.")]
        [Required]
        public string Encabezado { get; set; }

        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }

        [MaxLength(50, ErrorMessage = "El campo {0} no debe ser mayor a {1} caracteres.")]
        public string Punto_venta { get; set; }

        [MaxLength(50, ErrorMessage = "El campo {0} no debe ser mayor a {1} caracteres.")]
        public string Categoria { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Precio { get; set; }
        public Producto producto { get; set; }
        public Tipo_Edad_Anuncios tipo_Edad { get; set; }
        public Tipo_Promocion_Anuncios tipo_Promocion { get; set; }
        public Tipo_Categoria_Anuncios tipo_Categoria { get; set; }

    }
}
