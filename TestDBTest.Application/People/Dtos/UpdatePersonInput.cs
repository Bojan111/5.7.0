using Abp.Runtime.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDBTest.People.Dtos
{
    public class UpdatePersonInput : ICustomValidate
    {
        [Range(1, long.MaxValue)] 
        public long PersonId { get; set; }

        public int? AssignedCountryId { get; set; }

       
        public void AddValidationErrors(CustomValidationContext context)
        {
            if (AssignedCountryId == null)
            {
                context.Results.Add(new ValidationResult("AssignedPersonId can not be null in order to update a Person!", new[] { "AssignedCountryId" }));
            }
        }

        public override string ToString()
        {
            return string.Format("[UpdatePersonInput > PersonId = {0}, AssignedCountryId = {1}]", PersonId, AssignedCountryId);
        }
    }
}
