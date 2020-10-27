using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Analisis_WEB.Helpers
{
    public class RoleRequirement : IAuthorizationRequirement
    {
        public RoleRequirement(string role)
        {
            this.Role = role;
        }

        public string Role { get; private set; }
    }

    public class CustomRoleRequirementHandler : AuthorizationHandler<RoleRequirement>
    {
        // Usa IoC (inyección de dependencias) para incluir
        // los servicios que necesitas para validar el rol.
        public CustomRoleRequirementHandler()
        {
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleRequirement requirement)
        {
            // añade tu lógica aquí, puede ser obtener los roles y usuarios (JOIN) con EF.
            //  o validarlos contra un servicio
            if (requirement.Role == "jj")
            {
                context.Succeed(requirement);
            }
        
      
        }
    }
}
