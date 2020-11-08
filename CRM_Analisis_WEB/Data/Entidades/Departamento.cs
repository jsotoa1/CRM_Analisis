using System.ComponentModel.DataAnnotations;

namespace CRM_Analisis_WEB.Data.Entidades
{
    public class Departamento
    {
        public int Id { get; set; }

        [MaxLength(60)]
        public string Nombre_Departamento { get; set; }

        [MaxLength(50)]
        public string Pais { get; set; }
    }
}
