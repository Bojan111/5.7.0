using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDBTest.Entities;
using TestDBTest.Services.OfficialGazette.Dto;
using TestDBTest.Services.OfficialGazzet.Dto;

namespace TestDBTest.Services.OfficialGazzet
{
    public interface IOfficialGazzeteAppService : IAsyncCrudAppService<OfficialGazzeteWithListsDto, int, PagedAndSortedResultRequestDto, OfficialGazzeteDto>
    {
        Task<CustomCreateDto> CustomCreateAsync(CustomCreateDto input);

        Task<CustomCreateDto> CustomUpdateAsync(CustomCreateDto input);

        //Task<OfficialGazzeteDto> CustomUpdateAsync(OfficialGazzeteDto input);
    }
}
