using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM_Analisis_WEB.Data;
using CRM_Analisis_WEB.Data.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Analisis_WEB.Controllers
{

    public class MantRolFuncionalidadController : Controller
    {
        private readonly DataContext _dataContext;

        public MantRolFuncionalidadController(DataContext dataContext)
        {
            _dataContext = dataContext;
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
            catch(Exception e)
            {

            }
            return Json(valoresFuncionalidad, new Newtonsoft.Json.JsonSerializerSettings());
        }



        #endregion

        #region Rol

        #endregion

        #region Usuario

        #endregion

    }
}
