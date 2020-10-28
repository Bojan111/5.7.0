using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDBTest.Services.UseOfMedicalDevices.Dto
{
    [AutoMap(typeof(Entities.UseOfMedicalDevices))]
    public class UseOfMedicalDevicesDto : FullAuditedEntityDto
    {
        [DisableValidation]
        public string ConcomitantUseOfOtherMedicalDevices { get; set; }
        public string OtherRelevantInformation { get; set; }

        public int OfficialGazzeteId { get; set; }
    }
}
