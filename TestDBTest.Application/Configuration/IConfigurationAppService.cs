using System.Threading.Tasks;
using Abp.Application.Services;
using TestDBTest.Configuration.Dto;

namespace TestDBTest.Configuration
{
    public interface IConfigurationAppService: IApplicationService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}