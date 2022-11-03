using System.Threading.Tasks;
using Abp.Application.Services;
using AngularTest.Authorization.Accounts.Dto;

namespace AngularTest.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
