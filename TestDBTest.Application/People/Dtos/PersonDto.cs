using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TestDBTest.Entities;

namespace TestDBTest.People.Dtos
{
    [AutoMap(typeof(Person))]
    public class PersonDto : FullAuditedEntityDto<long>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        
        public string FullName 
        { 
            
            get{
                Regex initials = new Regex(@"(\b[a-zA-Z])[a-zA-Z]* ?");
                return initials.Replace(Name + " " + LastName, "$1");
            } }
      
        public Gender Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int? Age
        {
            get
            {
                return DateTime.Now.Year - DateOfBirth.Year;
            }
        }


        public string DateOfBirthFormatted => DateOfBirth.ToShortDateString();

        public string GenderFormatted => Gender.ToString();

        public int? AssignedCountryId { get; set; }

        public string AssignedCountryCountry { get; set; }
        public string AssignedCountryCity { get; set; }

    }
}
