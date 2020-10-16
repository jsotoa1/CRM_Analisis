using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Analisis_WEB.Controllers
{
    public class CategoryProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
