using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace AngularTest.Controllers
{
    public abstract class AngularTestControllerBase: AbpController
    {
        protected AngularTestControllerBase()
        {
            LocalizationSourceName = AngularTestConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
