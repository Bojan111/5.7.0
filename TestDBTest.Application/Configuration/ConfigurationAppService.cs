using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using TestDBTest.Configuration.Dto;

namespace TestDBTest.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : TestDBTestAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
