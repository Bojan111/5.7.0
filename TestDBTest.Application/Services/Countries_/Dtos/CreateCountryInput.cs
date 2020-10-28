using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDBTest.Services
{
    public class CreateCountryInput
    {
        public string Country { get; set; }

        public string City { get; set; }

        public override string ToString()
        {
            return string.Format("[CreateCountryInput >  Country = {0}, City = {1}]", Country, City);
        }
    }
}
