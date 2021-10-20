using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Services.Interfaces;
using KSRepositories.DbModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace API.Access
{
    public class RoleFilter : Attribute, IAsyncAuthorizationFilter
    {
        private readonly Role[] roles;

        public RoleFilter(params Role[] roles)
        {
            this.roles = roles;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            if (roles.Length == 0)
                return;
            switch (await Authorize(context))
            {
                case AuthorizationResult.Access:
                    break;
                case AuthorizationResult.Forbidden:
                    context.Result = new ForbidResult();
                    break;
                case AuthorizationResult.Unauthorized:
                    context.Result = new UnauthorizedResult();
                    break;
                default:
                    context.Result = new UnauthorizedResult();
                    break;
            }
        }

        private async Task<AuthorizationResult> Authorize(ActionContext context)
        {
            var userService = context.HttpContext.RequestServices.GetService<IUserService>();
            var userId = context.HttpContext.User.FindFirst("sub")?.Value;
            if (userId is null)
                return AuthorizationResult.Unauthorized;

            var user = await userService.GetUserByIdAsync(userId);
            if (user is null)
                return AuthorizationResult.Unauthorized;

            context.HttpContext.User.AddIdentity(new ClaimsIdentity(new[]
                {new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())}));
            return roles.Contains(user.Role)
                ? AuthorizationResult.Access
                : AuthorizationResult.Forbidden;
        }

        private enum AuthorizationResult
        {
            Unauthorized = 0,
            Access = 1,
            Forbidden = 2
        }
    }
}