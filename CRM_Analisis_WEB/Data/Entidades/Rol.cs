using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Analisis_WEB.Data.Entidades
{
    public class Rol : IdentityRole
    {
        [MaxLength(150)]
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
    }
}
