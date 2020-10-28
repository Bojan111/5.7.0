using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDBTest.People.Dtos
{
    public class CreatePersonInput
    {
        public int? AssignedCountryId { get; set; }
        public string Name { get; set; }
    
        public string Country { get; set; }


        public string City { get; set; }

        public override string ToString()
        {
            return string.Format("[CreatePersonInput > AssignedCountryId = {0}, Name = {1}, Country = {2}, City = {3}]", AssignedCountryId, Name, Country, City);
        }
    }
}
