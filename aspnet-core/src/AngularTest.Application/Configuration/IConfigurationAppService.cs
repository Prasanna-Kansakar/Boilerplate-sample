using System.Threading.Tasks;
using AngularTest.Configuration.Dto;

namespace AngularTest.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
