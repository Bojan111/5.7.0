using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDBTest.Services.ManufacturerInfo.Dto;

namespace TestDBTest.Services.ManufacturerInfo
{
    public interface IManufacturerInfoAppService : IAsyncCrudAppService<ManufacturerInfoDto>
    {
    }
}
