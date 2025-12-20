using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Receipt.API.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class AuthorizeAttributes : Attribute, IAuthorizationFilter
    {
        private int user { get; set; }
        private string userRole { get; set; }
        // This method is called by the framework to check if the user is authorized
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //int retInt = 0;
            
            //// Check if the user is logged in by looking for a user ID in the context items
            //if (context.HttpContext.User.Claims?.Where(x=> x.Type.ToUpper()=="UID" ||
            //            x.Type.ToUpper()== "ROLE").Count()<1)
            //{
            //    // not logged in
            //    context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            //    return;
            //}

            //retInt = 0;
            //int.TryParse(Convert.ToString(context.HttpContext.User.Claims?.
            //        Where(x => x.Type.ToUpper() == "UID").FirstOrDefault().Value),out retInt);
            //if (retInt == null || retInt==0)
            //{
            //    // not logged in
            //    context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            //}
            //user= retInt;
            //string _userRoles = string.Empty;
            //_userRoles = Convert.ToString(context.HttpContext.User.Claims?.
            //        Where(x => x.Type.ToUpper() == "ROLE").FirstOrDefault().Value);
            //userRole = _userRoles;
        }
    }
}
