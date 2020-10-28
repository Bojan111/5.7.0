using Abp.Application.Services;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDBTest.Services.MedicalDeviceInfo.Dto;

namespace TestDBTest.Services.MedicalDeviceInfo
{
    public class MedicalDeviceInfoAppService : AsyncCrudAppService<Entities.MedicalDeviceInfo, MedicalDeviceInfoDto>, IMedicalDeviceInfoAppService
    {
        public MedicalDeviceInfoAppService(IRepository<Entities.MedicalDeviceInfo, int> repository) : base(repository)
        {
        }
    }
}
