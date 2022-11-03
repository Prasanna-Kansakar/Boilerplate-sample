using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using AngularTest.Configuration.Dto;

namespace AngularTest.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : AngularTestAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
