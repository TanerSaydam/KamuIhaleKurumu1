using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KIKWebApi.Authorization;

public sealed class RoleAttribute : Attribute, IAuthorizationFilter
{
    private readonly string _role;

    public RoleAttribute(string role)
    {
        _role = role;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var userIdClaim = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim == null)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        string userId = Convert.ToInt64(userIdClaim.Value).ToString();

        var userHasRole =
            Constants.UserRoles
            .Where(p => p.UserId == userId)
            .Any(p => p.RoleName == _role);

        if (!userHasRole)
        {
            context.Result = new UnauthorizedResult();
            return;
        }
    }
}