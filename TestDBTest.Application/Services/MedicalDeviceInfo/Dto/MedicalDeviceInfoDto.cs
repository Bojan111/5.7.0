using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDBTest.Entities;

namespace TestDBTest.Services.MedicalDeviceInfo.Dto
{
    [AutoMap(typeof(Entities.MedicalDeviceInfo))]
    public class MedicalDeviceInfoDto : FullAuditedEntityDto
    {
        [DisableValidation]
        public string SuspectedMedicalDevice { get; set; }
        public string MethodOfApplication { get; set; }
        public int OfficialGazzeteId { get; set; }
        public string IndicationOfUse { get; set; }
        public DateTime? StartDateFillForm { get; set; }
        public DateTime? EndDateFillForm { get; set; }

        public DidReactionGoneAfterUseMedicalDevice DidReactionGoneAfterUseMedicalDevice { get; set; }

        public DoesTheReactionOccurAgain DoesTheReactionOccurAgain { get; set; }
    }
}
