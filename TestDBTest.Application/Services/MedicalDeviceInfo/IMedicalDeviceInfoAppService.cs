using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDBTest.Services.MedicalDeviceInfo.Dto;

namespace TestDBTest.Services.MedicalDeviceInfo
{
    public interface IMedicalDeviceInfoAppService : IAsyncCrudAppService<MedicalDeviceInfoDto>
    {
    }
}
