using System.ComponentModel.DataAnnotations;

namespace CRM_Analisis_WEB.Data.Entidades
{
    public class Municipio
    {
        public int Id { get; set; }

        [MaxLength(60)]
        public string Nombre_Municipio { get; set; }

        public Departamento Departamento_Municipio { get; set; }
    }
}
