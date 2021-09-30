using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoGraduacion_WEB.Data.Entidades
{
    public class Direccion_Entrega
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Dirección { get; set; }

        public Municipio Municipio_Entrega { get; set; }

        public string Comentario_Direccion_Entrega { get; set; }


    }
}
