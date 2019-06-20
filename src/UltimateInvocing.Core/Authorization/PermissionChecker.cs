using Abp.Authorization;
using UltimateInvocing.Authorization.Roles;
using UltimateInvocing.Authorization.Users;

namespace UltimateInvocing.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
