using Abp.Application.Services;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDBTest.Services.UseOfMedicalDevices.Dto;

namespace TestDBTest.Services.UseOfMedicalDevices
{
    public class UseOfMedicalDevicesAppService : AsyncCrudAppService<Entities.UseOfMedicalDevices, UseOfMedicalDevicesDto>, IUseOfMedicalDevicesAppService
    {
        public UseOfMedicalDevicesAppService(IRepository<Entities.UseOfMedicalDevices, int> repository) : base(repository)
        {
        }
    }
}
