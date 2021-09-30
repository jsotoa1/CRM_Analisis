using System.ComponentModel.DataAnnotations;

namespace ProyectoGraduacion_WEB.Data.Entidades
{
    public class Municipio
    {
        public int Id { get; set; }

        [MaxLength(60)]
        public string Nombre_Municipio { get; set; }

        public Departamento Departamento_Municipio { get; set; }
    }
}
