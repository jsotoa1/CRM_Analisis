using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ProyectoGraduacion_WEB.Controllers
{
    //[Authorize(Roles = "Administrador")]
    public class DashboardController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }
    }
}
