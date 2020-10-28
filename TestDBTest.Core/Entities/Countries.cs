using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDBTest.Entities
{
    public class Countries : Entity
    {
        public string Country { get; set; }
        public string City { get; set; }
    }
}
