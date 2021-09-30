using Microsoft.AspNetCore.Mvc;
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
            return View();
        }
    }
}
