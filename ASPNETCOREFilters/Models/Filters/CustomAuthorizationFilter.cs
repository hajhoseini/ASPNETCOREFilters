using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ASPNETCOREFilters.Models.Filters
{
    public class CustomAuthorizationFilter : Attribute, IAuthorizationFilter
    {
        private readonly string _role;

        public CustomAuthorizationFilter(string role)
        {
            _role = role;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var isAuthorized = CheckPermission(context.HttpContext.User, _role);
            if (!isAuthorized)
                context.Result = new UnauthorizedResult();
        }

        private bool CheckPermission(ClaimsPrincipal principal, string role)
        {
            //check conditions ...

            if (role == "admin")
                return true;

            return false;
        }
    }
}
