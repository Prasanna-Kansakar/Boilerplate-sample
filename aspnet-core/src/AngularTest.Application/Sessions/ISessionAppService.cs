using System.Threading.Tasks;
using Abp.Application.Services;
using AngularTest.Sessions.Dto;

namespace AngularTest.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
