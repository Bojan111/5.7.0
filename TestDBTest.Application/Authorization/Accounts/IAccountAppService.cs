using System.Threading.Tasks;
using Abp.Application.Services;
using TestDBTest.Authorization.Accounts.Dto;

namespace TestDBTest.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
