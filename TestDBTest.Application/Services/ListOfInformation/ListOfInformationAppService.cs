using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDBTest.Services.ListOfInformation.Dto;

namespace TestDBTest.Services.ListOfInformation
{
    public class ListOfInformationAppService : AsyncCrudAppService<Entities.ListOfInformation, ListOfInformationDto>, IListOfInformationAppService
    {
        public ListOfInformationAppService(IRepository<Entities.ListOfInformation, int> repository) : base(repository)
        {
        }

      
    }
}
