using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoGraduacion_WEB.Data;
using ProyectoGraduacion_WEB.Data.Entidades;
using ProyectoGraduacion_WEB.Helpers;
using ProyectoGraduacion_WEB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ProyectoGraduacion_WEB.Controllers
{
    public class AccountController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IUserHelper _userHelper;
        private readonly UserManager<User> _userManager;

        public AccountController(DataContext dataContext, 
            IUserHelper userHelper,
            UserManager<User> userManager)
        {
            _dataContext = dataContext;
            _userManager = userManager;
            _userHelper = userHelper;
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Home", "Dashboard");
            }

            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await _userHelper.LoginAsync(model);
                if (result.Succeeded)
                {
                    List<RolFuncionalidad> Rolfuncionalidades = new List<RolFuncionalidad>();
                    List<FuncionalidadViewModel> listfuncionalidad = new List<FuncionalidadViewModel>();

                    var user = _userManager.Users
                               .Include(r => r.rol)
                               .FirstOrDefault(m => m.UserName == model.Username);

                    Rolfuncionalidades = _dataContext.RolFuncionalidades
                                      .Include(f => f.funcionalidad)
                                      .Where(r => r.rol.Id == user.rol.Id).ToList();

                    foreach(var funcionalidad in Rolfuncionalidades)
                    {
                        listfuncionalidad.Add(new FuncionalidadViewModel
                        {
                             Id = funcionalidad.funcionalidad.Id,
                             Descripcion = funcionalidad.funcionalidad.Descripcion,
                             IdFuncionalidad = funcionalidad.funcionalidad.IdFuncionalidad == null? 0 :funcionalidad.funcionalidad.IdFuncionalidad.Id,
                             Estado = funcionalidad.funcionalidad.Estado,
                             FuncionalidadHijo = funcionalidad.funcionalidad.FuncionalidadHijo,
                             Imagen = funcionalidad.funcionalidad.Imagen,
                             NombreMenu = funcionalidad.funcionalidad.NombreMenu,
                             Observaciones = funcionalidad.funcionalidad.Observaciones,
                             Url = funcionalidad.funcionalidad.Url,
                             Orden = funcionalidad.funcionalidad.Orden

                        });
                    }

                    TempData["ListaFunc"] = JsonConvert.SerializeObject(listfuncionalidad);

                    if (Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return Redirect(Request.Query["ReturnUrl"].First());
                    }

                    return RedirectToAction("Home", "Dashboard");
                }

                ModelState.AddModelError(string.Empty, "Email or password incorrect.");
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _userHelper.LogoutAsync();
            return RedirectToAction("Login", "Account");
        }
    }

}
