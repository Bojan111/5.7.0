using System.Threading.Tasks;
using Abp.Application.Services;
using TestDBTest.Sessions.Dto;

namespace TestDBTest.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
