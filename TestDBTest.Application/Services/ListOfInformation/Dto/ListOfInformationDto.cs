using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDBTest.Entities;

namespace TestDBTest.Services.ListOfInformation.Dto
{
    [AutoMap(typeof(Entities.ListOfInformation))]
    public class ListOfInformationDto : FullAuditedEntityDto
    {
        public long? PersonId { get; set; }
        public string PersonName { get; set; }
        public string PersonLastName { get; set; }
        public int PersonAge { get; set; }
        public Gender PersonGender { get; set; }
        public DateTime? PersonDateOfBirth { get; set; }



        public int? AssignedCountryId { get; set; }
        public string AssignedCountryCountry { get; set; }
        public string AssignedCountryCity { get; set; }
    }
}
