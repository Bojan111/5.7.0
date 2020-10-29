using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDBTest.Services.ListOfInformation.Dto;

namespace TestDBTest.Services.ListOfInformation
{
    public interface IListOfInformationAppService : IAsyncCrudAppService<ListOfInformationDto>
    {
    }
}
