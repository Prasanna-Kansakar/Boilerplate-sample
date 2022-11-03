using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AngularTest.EntityFrameworkCore;
using AngularTest.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace AngularTest.Web.Tests
{
    [DependsOn(
        typeof(AngularTestWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class AngularTestWebTestModule : AbpModule
    {
        public AngularTestWebTestModule(AngularTestEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AngularTestWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(AngularTestWebMvcModule).Assembly);
        }
    }
}