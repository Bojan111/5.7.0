using Abp.Application.Services;
using Abp.Application.Services.Dto;
using TestDBTest.MultiTenancy.Dto;

namespace TestDBTest.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
