using Abp.Application.Services;
using AngularTest.MultiTenancy.Dto;

namespace AngularTest.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

