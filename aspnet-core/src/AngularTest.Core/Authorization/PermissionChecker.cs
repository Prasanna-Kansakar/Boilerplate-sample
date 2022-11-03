using Abp.Authorization;
using AngularTest.Authorization.Roles;
using AngularTest.Authorization.Users;

namespace AngularTest.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
