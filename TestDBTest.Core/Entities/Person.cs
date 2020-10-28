using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDBTest.Entities
{
    public class Person : FullAuditedEntity<long>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        
        public int Age { get; set; }

        public Gender Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }


 

        public int? AssignedCountryId { get; set; }
        [ForeignKey("AssignedCountryId")]
        public virtual Countries AssignedCountry { get; set; }



       
    }

    public enum Gender
    {
        Male,
        Female
    }

    
}
