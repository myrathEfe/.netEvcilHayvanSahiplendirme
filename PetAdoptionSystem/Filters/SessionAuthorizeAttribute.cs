using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PetAdoptionSystem.Helpers;

namespace PetAdoptionSystem.Filters;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class SessionAuthorizeAttribute : Attribute, IAuthorizationFilter
{
    private readonly string[] _allowedRoles;

    public SessionAuthorizeAttribute(params string[] allowedRoles)
    {
        _allowedRoles = allowedRoles;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var userId = context.HttpContext.Session.GetInt32(SessionKeys.UserId);
        if (!userId.HasValue)
        {
            var returnUrl = $"{context.HttpContext.Request.Path}{context.HttpContext.Request.QueryString}";
            context.Result = new RedirectToActionResult("Login", "Account", new { returnUrl });
            return;
        }

        if (_allowedRoles.Length == 0)
        {
            return;
        }

        var role = context.HttpContext.Session.GetString(SessionKeys.UserRole);
        if (string.IsNullOrWhiteSpace(role) || !_allowedRoles.Contains(role))
        {
            context.Result = new RedirectToActionResult("AccessDenied", "Account", null);
        }
    }
}
