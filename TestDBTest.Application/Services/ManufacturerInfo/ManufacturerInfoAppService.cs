using Abp.Application.Services;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDBTest.Entities;
using TestDBTest.Services.ManufacturerInfo.Dto;

namespace TestDBTest.Services.ManufacturerInfo
{
    public class ManufacturerInfoAppService : AsyncCrudAppService<Entities.ManufacturerInfo, ManufacturerInfoDto>, IManufacturerInfoAppService
    {
        public ManufacturerInfoAppService(IRepository<Entities.ManufacturerInfo, int> repository) : base(repository)
        {
        }


       
    }
}
