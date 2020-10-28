using Abp.Runtime.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDBTest.Services
{
    public class UpdateCountryInput 
    {
        [Range(1, long.MaxValue)]
        public long CountryId { get; set; }

        public override string ToString()
        {
            return string.Format("[UpdateCountryInput > CountryId = {0}]", CountryId);
        }
    }
}
