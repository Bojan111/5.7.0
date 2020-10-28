using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDBTest.Entities;
using TestDBTest.Services.NearMiss.Dto;

namespace TestDBTest.Services.NearMiss
{
    public class NearMissAppService : AsyncCrudAppService<Entities.NearMiss, NearMissDto>, INearMissAppService
    {

        public NearMissAppService(IRepository<Entities.NearMiss> repository) : base(repository)
        {
    
        }

        public override async Task<PagedResultDto<NearMissDto>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
            var result = await Repository.GetAllListAsync();

            var output = new PagedResultDto<NearMissDto>()
            {
                TotalCount = result.Count,
                Items = ObjectMapper.Map<List<NearMissDto>>(result)
            };

            return output;
       
        }
        public override Task<NearMissDto> CreateAsync(NearMissDto input)
        {
            return base.CreateAsync(input);
        }


        //public override async Task<NearMissDto> CreateAsync(NearMissDto input)
        //{
        //    var nearMiss_ = ObjectMapper.Map<Entities.NearMiss>(input);          
        //    var newId = await Repository.InsertAndGetIdAsync(nearMiss_);
        //    var createdNearMiss = await Repository.GetAsync(newId);
        //    var output = ObjectMapper.Map<NearMissDto>(createdNearMiss);
        //    return output;
        //}
    }
}
