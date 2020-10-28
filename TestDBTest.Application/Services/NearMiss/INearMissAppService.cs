using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDBTest.Services.NearMiss.Dto;

namespace TestDBTest.Services.NearMiss
{
    public interface INearMissAppService : IAsyncCrudAppService<NearMissDto>
    {
    }
}
