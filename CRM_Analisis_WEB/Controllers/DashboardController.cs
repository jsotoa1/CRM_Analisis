using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Analisis_WEB.Controllers
{
    
    public class DashboardController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }
    }
}
