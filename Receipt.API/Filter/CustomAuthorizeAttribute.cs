using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace Receipt.API.Filter
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public async Task OnAuthorization(AuthorizationFilterContext context)
        {
            var tokenString = context.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if (string.IsNullOrEmpty(tokenString))
            {
                context.Result = new UnauthorizedResult();
                return;
            }
            var IsLogout = true ;
            if (!IsLogout)
            {
                context.Result = new UnauthorizedResult();
                return;
            }
        }
    }
}
