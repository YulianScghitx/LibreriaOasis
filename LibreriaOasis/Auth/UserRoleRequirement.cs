using Microsoft.AspNetCore.Authorization;

namespace LibreriaOasis.Auth
{
    public class UserRoleRequirement : IAuthorizationRequirement
    {
        public UserRoleRequirement(int role) => Role = role;
        public int Role { get; set; }

    }
}
