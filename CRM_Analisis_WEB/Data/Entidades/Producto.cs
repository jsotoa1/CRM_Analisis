using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Analisis_WEB.Data.Entidades
{
    public class Producto
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "El campo {0} no debe ser mayor a {1} caracteres.")]
        [Required]
        public string Nombre { get; set; }
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Required]
        public decimal Precio { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public bool Estado { get; set; }
        public Categoria_Producto Categoria { get; set; }

       
    }
}
