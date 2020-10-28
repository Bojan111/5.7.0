using Abp.Authorization;
using TestDBTest.Authorization.Roles;
using TestDBTest.Authorization.Users;

namespace TestDBTest.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
