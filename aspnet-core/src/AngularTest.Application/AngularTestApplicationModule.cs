using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AngularTest.Authorization;
using AngularTest.Students;

namespace AngularTest
{
    [DependsOn(
        typeof(AngularTestCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class AngularTestApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<AngularTestAuthorizationProvider>();
//          Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder.For<IStudentService>("Student").Build();

/*            Configuration.Modules.AbpAspNetCore().CreateControllersForAppServices(typeof(AngularTestApplicationModule).Assembly, moduleName: 'app', useConventionalHttpVerbs: true);
*/        }

        public override void Initialize()
        {
            var thisAssembly = typeof(AngularTestApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
