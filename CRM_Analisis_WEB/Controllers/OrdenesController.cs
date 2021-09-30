using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoGraduacion_WEB.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoGraduacion_WEB.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class OrdenesController : Controller
    {
        private readonly DataContext _dataContext;
        public OrdenesController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult GestionOrdenes()
        {
            return View();
        }
    }
}
