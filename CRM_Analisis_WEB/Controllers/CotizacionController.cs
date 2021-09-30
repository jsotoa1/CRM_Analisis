using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoGraduacion_WEB.Controllers
{
    public class CotizacionController : Controller
    {
        public ActionResult Cotizacion()
        {
            return View();
        }

       
    }
}
