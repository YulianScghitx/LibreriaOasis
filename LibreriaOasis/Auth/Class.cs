using LibreriaOasis.Auth;
using LibreriaOasis.DTOs;
using LibreriaOasis.Repositorios.Interfaces;
using Microsoft.AspNetCore.Authorization;

//public class UserRoleRequirementHandler : AuthorizationHandler<UserRoleRequirement>
//{
//    public AdminRoleRequirementHandler(IHttpContextAccessor httpContextAccessor)
//    {
//        _httpContextAccessor = httpContextAccessor;
//    }
//    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, LoginDTO usr)
//    {
//        if (context.User.HasClaim(c => c.Value == usr.tipo_usuario.ToString()))
//        {
//            context.Succeed(usr);
//        }
//        else
//        {

//            _httpContextAccessor.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
//            _httpContextAccessor.HttpContext.Response.ContentType = "application/json";
//            await _httpContextAccessor.HttpContext.Response.WriteAsJsonAsync(new { StatusCode = StatusCodes.Status401Unauthorized, Message = "Unauthorized." });
//            await _httpContextAccessor.HttpContext.Response.CompleteAsync();

//            context.Fail();

//        }

//    }
//    private readonly IHttpContextAccessor _httpContextAccessor;
//}