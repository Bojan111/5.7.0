using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TestDBTest.Entities;
using TestDBTest.Services.ManufacturerInfo.Dto;
using TestDBTest.Services.MedicalDeviceInfo.Dto;
using TestDBTest.Services.UseOfMedicalDevices.Dto;

namespace TestDBTest.Services.OfficialGazzet.Dto
{
    [AutoMap(typeof(OfficialGazzete))]
    public class OfficialGazzeteDto : FullAuditedEntityDto
    {
        public string ApplicationForUnwantedMedDevices { get; set; }
        public string DescribeYourAdverseReaction { get; set; }
        public OutComeOfAverseReaction OutComeOfAverseReaction { get; set; }

        public DateTime? ErrorDetectionDate { get; set; }
        public ConnectionBetweenAdverseReaction ConnectionBetweenAdverseReaction { get; set; }

        public long? PersonId { get; set; }
        public string PersonName { get; set; }

        public string PersonLastName { get; set; }
        public string PersonFullName
        {

            get
            {
                Regex initials = new Regex(@"(\b[a-zA-Z])[a-zA-Z]* ?");
                return initials.Replace(PersonName + ' ' + PersonLastName, "$1");
            }
        }


        public int PersonAge { get; set; }
        public Gender PersonGender { get; set; }
        public DateTime PersonDateOfBirth { get; set; }

        public string DateOfBirthFormatted => PersonDateOfBirth.ToShortDateString();
    }
}
