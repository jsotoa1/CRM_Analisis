using Microsoft.AspNetCore.Mvc;
using ProyectoGraduacion_WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoGraduacion_WEB.Controllers
{
    public class InventarioRepuestoController : Controller
    {
        public IActionResult InventarioRepuesto()
        {
            List<Tipo> listTipo = new List<Tipo>()
            {
                new Tipo() { Id = 1, Nombre = "PNC" },
                new Tipo() { Id = 1, Nombre = "RO" },
            };

            ViewBag.tipo = listTipo;
            return View();
        }
    }
}
