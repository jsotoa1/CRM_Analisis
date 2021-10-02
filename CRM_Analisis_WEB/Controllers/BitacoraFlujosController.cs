using Microsoft.AspNetCore.Mvc;
using ProyectoGraduacion_WEB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoGraduacion_WEB.Controllers
{
    public class BitacoraFlujosController : Controller
    {
        private readonly DataContext _dataContext;

        public BitacoraFlujosController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IActionResult BitacoraFlujos()
        {
            return View();
        }

    }
}
