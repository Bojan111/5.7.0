using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDBTest.Entities;

namespace TestDBTest.Services.ManufacturerInfo.Dto
{
    [AutoMap(typeof(Entities.ManufacturerInfo))]
    public class ManufacturerInfoDto : FullAuditedEntityDto
    {
        public int OfficialGazzeteId { get; set; }
        public string ManufacturName { get; set; }

        public string ManufaturAddress { get; set; }

        public int NumberOfMedicalDevice { get; set; }

        public DateTime? DateOfUseMedicalDevice { get; set; }

        public string ApplicantHealthInstitution { get; set; }
        public string ApplicantFullNameHealthWorker { get; set; }

        public string ApplicantAddress { get; set; }

        public int ApplicantPhone { get; set; }

        public string ApplicantEmail { get; set; }

        public string Signature { get; set; }

        public SourceOfApplication SourceOfApplication { get; set; }

        public TypeOfApp TypeOfApp { get; set; }

    }
}
