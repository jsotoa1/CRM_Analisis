using CRM_Analisis_WEB.Data;
using CRM_Analisis_WEB.Data.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Analisis_WEB.Helpers
{
    public class AuthorizeUser : AuthorizeAttribute, IAsyncAuthorizationFilter
    {
        private readonly string role;

        public AuthorizeUser(string role)
        {
            this.role = role;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
           
            var service = (IAuthorizationService)context.HttpContext.RequestServices.GetService(typeof(IAuthorizationService));
            //var controller = context.RouteData.Values.Values.ToList();
            //var controller1 = controller[0];

            var roleRequirement = new RoleRequirement(this.role);
            var result = await service.AuthorizeAsync(context.HttpContext.User, null, roleRequirement);


            if (!result.Succeeded)
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
