﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM_Analisis_WEB.Data;
using CRM_Analisis_WEB.Data.Entidades;
using CRM_Analisis_WEB.Helpers;
using CRM_Analisis_WEB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRM_Analisis_WEB.Controllers
{

    public class MantRolFuncionalidadController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserHelper _userHelper;

        public MantRolFuncionalidadController(DataContext dataContext, 
            RoleManager<IdentityRole> roleManager,
            IUserHelper userHelper)
        {
            _dataContext = dataContext;
            _roleManager = roleManager;
            _userHelper = userHelper;
        }
        public ActionResult mantRolUsuarioFunc()
        {

            return View();
        }


            #region Funcionalidad

       [HttpPost]
        public JsonResult ObtenerFuncionalidades()
        {
            var valoresFuncionalidad = new List<Funcionalidad>();

            try
            {
                valoresFuncionalidad = _dataContext.Funcionalidades.ToList();
            }
            catch(Exception)
            {

            }
            return Json(valoresFuncionalidad, new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpPost]
        public JsonResult recuperarFuncionalidad()
        {
            var valoresFuncionalidad = new List<Funcionalidad>();

            try
            {
                valoresFuncionalidad = _dataContext.Funcionalidades
                                       .Where(f => f.IdFuncionalidad == null)
                                       .Where(f => f.Estado == true)
                                       .ToList();
            }
            catch (Exception )
            {

            }
            return Json(valoresFuncionalidad, new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpPost]
        public JsonResult guardarFuncionalidad(FuncionalidadViewModel varFuncionalidad)
        {

            if ((varFuncionalidad != null
               && (varFuncionalidad.Descripcion != null && !string.IsNullOrEmpty(varFuncionalidad.Descripcion) && varFuncionalidad.Descripcion.Length <= 100)
               && (varFuncionalidad.NombreMenu != null && !string.IsNullOrEmpty(varFuncionalidad.NombreMenu) && varFuncionalidad.NombreMenu.Length <= 100)
               && (varFuncionalidad.Url != null && !string.IsNullOrEmpty(varFuncionalidad.Url) && varFuncionalidad.Url.Length <= 250) || varFuncionalidad.Url == null
               && (varFuncionalidad.Imagen != null && !string.IsNullOrEmpty(varFuncionalidad.Imagen) && varFuncionalidad.Imagen.Length <= 100) || varFuncionalidad.Imagen == null
               || varFuncionalidad != null))
            {
                RespuestaViewModel guardarCambiosRespuesta = new RespuestaViewModel();

                Funcionalidad UltimaFuncionalidad = _dataContext.Funcionalidades
                                                    .OrderByDescending(f => f.Orden)
                                                    .First();
                try
                {
                    Funcionalidad funcionalidad = new Funcionalidad
                    {
                        Descripcion = varFuncionalidad.Descripcion,
                        NombreMenu = varFuncionalidad.NombreMenu,
                        Url = varFuncionalidad.Url,
                        Imagen = varFuncionalidad.Imagen,
                        Observaciones = varFuncionalidad.Observaciones,
                        Estado = true,
                        Orden = UltimaFuncionalidad.Orden + 1,
                        IdFuncionalidad = _dataContext.Funcionalidades.Find(varFuncionalidad.IdFuncionalidad)
                    };

                    _dataContext.Add(funcionalidad);
                    _dataContext.SaveChanges();
                    guardarCambiosRespuesta.Response = true;
                }
                catch (Exception )
                {
                    guardarCambiosRespuesta.Response = false;
                }
                return Json(guardarCambiosRespuesta, new Newtonsoft.Json.JsonSerializerSettings());
            }
            else
                return Json(new { Response = false, Message = "los datos ingresados son incorrectos o inválidos, por favor intente mas tarde." }, new Newtonsoft.Json.JsonSerializerSettings());
        }



        #endregion

        #region Rol
        [HttpPost]
        public JsonResult ObtenerRol()
        {
            var valoresRol = new List<IdentityRole>();

            try
            {
                valoresRol = _roleManager.Roles.ToList();
            }
            catch (Exception)
            {

            }
            return Json(valoresRol, new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpPost]
        public async Task<JsonResult> guardarRol(Rol varRol)
        {
            RespuestaViewModel guardarCambiosRespuesta = new RespuestaViewModel();
            if ((varRol != null) && (!string.IsNullOrEmpty(varRol.Descripcion) && varRol.Descripcion.Length <= 100))
            {
                try
                {
                    await _userHelper.AddRoleAsync(varRol);
                    guardarCambiosRespuesta.Response = true;
                }
                catch (Exception )
                {
                    guardarCambiosRespuesta.Response = false;
                }

                return Json(guardarCambiosRespuesta, new Newtonsoft.Json.JsonSerializerSettings());
            }
            else
            {
                return Json(new { Response = false, Message = "los datos ingresados son incorrectos o inválidos, por favor intente mas tarde." }, new Newtonsoft.Json.JsonSerializerSettings());
            }
        }

        public JsonResult obtenerFunct(string Id)
        {
            
            List<treeView> result = new List<treeView>();

            try
            {
                result = ObtenerNodosFuncRol(Id);
            }
            catch (Exception)
            {

            }
            
            return Json(result, new Newtonsoft.Json.JsonSerializerSettings());
        }

        public List<treeView> ObtenerNodosFuncRol(string id)
        {
            List<Funcionalidad> ValoresFuncionalidad = new List<Funcionalidad>();
            List<permisosFuncionalidad> permisosFuncionalidades = new List<permisosFuncionalidad>();
            List<RolFuncionalidad> rolFuncionalidades = new List<RolFuncionalidad>();

            List<treeView> resultChildren = new List<treeView>();
            List<treeView> resultChildren2 = new List<treeView>();
            List<treeView> result = new List<treeView>();

            try
            {
                rolFuncionalidades = _dataContext.RolFuncionalidades
                                    .Include(f => f.funcionalidad)
                                    .Include(r=> r.rol)
                                    .ToList();



                ValoresFuncionalidad = _dataContext.Funcionalidades.ToList();


                foreach (var itemfuncionalidades in ValoresFuncionalidad)
                {
                    permisosFuncionalidades.Add(new permisosFuncionalidad
                    {
                        Id = itemfuncionalidades.Id,
                        Descripcion = itemfuncionalidades.Descripcion,
                        IdFuncionalidad = itemfuncionalidades.IdFuncionalidad == null ? 0 : itemfuncionalidades.IdFuncionalidad.Id,
                        Permiso = 0,
                        Hijos = _dataContext.Funcionalidades.Where(f => f.IdFuncionalidad.Id == itemfuncionalidades.Id).Count(),
                        NomreMenu = itemfuncionalidades.NombreMenu
                    });
                }

                foreach (var item in permisosFuncionalidades)
                {
                    resultChildren = new List<treeView>();
                    resultChildren2 = new List<treeView>();
                    if (item.Hijos > 0)
                    {
                        foreach (var itemHijos in permisosFuncionalidades)
                        {
                            if (item.Id == itemHijos.IdFuncionalidad)
                            {
                                if (itemHijos.Hijos > 0)
                                {
                                    foreach (var itemHijos2 in permisosFuncionalidades)
                                    {
                                        if (itemHijos.Id == itemHijos2.IdFuncionalidad)
                                        {
                                            resultChildren2.Add(new treeView()
                                            {
                                                id = itemHijos2.Id,
                                                population = 1,
                                                text = itemHijos2.Descripcion,
                                                flagUrl = itemHijos2.Descripcion,
                                                @checked = itemHijos2.Permiso != 0 ? true : false,
                                                hasChildren = false
                                            });
                                        }
                                    }
                                }

                                resultChildren.Add(new treeView()
                                {
                                    id = itemHijos.Id,
                                    population = 1,
                                    text = itemHijos.Descripcion,
                                    flagUrl = itemHijos.Descripcion,
                                    @checked = itemHijos.Permiso != 0 ? true : false,
                                    hasChildren = false,
                                    children = resultChildren2
                                });

                            }
                        }
                    }
                    if (item.IdFuncionalidad == 0)
                    {
                        result.Add(new treeView()
                        {
                            id = item.Id,
                            population = 1,
                            text = item.Descripcion,
                            flagUrl = item.Descripcion,
                            @checked = item.Permiso != 0 && item.Hijos == 0 ? true : false,
                            hasChildren = resultChildren.Count() != 0 ? true : false,
                            children = resultChildren
                        });
                    }
                }

            }
            catch (Exception)
            {

            }

            return result;

        }

        [HttpPost]
        public  async Task<JsonResult> SaveCheckedNodes(List<int> checkedIds, string idRol)
        {
            RespuestaViewModel resp = new RespuestaViewModel();

            if (checkedIds == null)
            {
                checkedIds = new List<int>();
            }

            if (checkedIds != null && idRol != null)
            {
                valoresRolFuncionalidad varRolFunc = new valoresRolFuncionalidad();
                try
                {
                    List<treeView> result = new List<treeView>();


                    result = ObtenerNodosFuncRol(idRol);
  
                    List<int> checkedIdsTemp = new List<int>();

                    checkedIdsTemp.AddRange(checkedIds);

                    foreach (var padre in result.ToList())
                    {
                        foreach (var hijo in padre.children)
                        {
                            foreach (var ids in checkedIdsTemp)
                            {
                                if (hijo.id == ids)
                                {
                                    checkedIds.Insert(0, padre.id);
                                    break;
                                }
                            }
                        }
                    }
                    checkedIdsTemp.Clear();
                    checkedIdsTemp.AddRange(checkedIds.Distinct());

                    varRolFunc = new valoresRolFuncionalidad
                    {

                        ids = checkedIdsTemp,
                        idRol = idRol
                    };
                }
                catch (Exception)
                {
                    return Json(new { Response = false, Message = "los datos ingresados son incorrectos o inválidos, por favor intente mas tarde." }, new Newtonsoft.Json.JsonSerializerSettings());
                }
                try
                {
                    List<int> idsTabla = new List<int>();


                    foreach (var item in varRolFunc.ids)
                    {
                        if (!idsTabla.Contains(item))
                        {
                            

                            var rolFuncionalidad = new RolFuncionalidad
                            {
                                 funcionalidad = _dataContext.Funcionalidades.Find(item),
                                 rol = await _roleManager.FindByIdAsync(varRolFunc.idRol.ToString())
                            };

                            _dataContext.RolFuncionalidades.Add(rolFuncionalidad);
                            _dataContext.SaveChanges();
                        }
                    }

                    resp.Response = true;

                }
                catch (Exception )
                {
                    resp.Response = false;
                }
                return this.Json(resp.Response);
            }
            else
            {
                return Json(new { Response = false, Message = "los datos ingresados son incorrectos o inválidos, por favor intente mas tarde." }, new Newtonsoft.Json.JsonSerializerSettings());
            }
        }

        #endregion

        #region Usuario

        #endregion

    }
}
