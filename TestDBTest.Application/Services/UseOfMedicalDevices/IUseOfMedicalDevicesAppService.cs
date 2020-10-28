using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDBTest.Services.UseOfMedicalDevices.Dto;

namespace TestDBTest.Services.UseOfMedicalDevices
{
    public interface IUseOfMedicalDevicesAppService : IAsyncCrudAppService<UseOfMedicalDevicesDto>
    {
    }
}
