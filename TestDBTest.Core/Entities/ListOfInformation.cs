using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDBTest.Entities
{
    public class ListOfInformation : FullAuditedEntity
    {
        public long? PersonId { get; set; }
        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }

        public int? AssignedCountryId { get; set; }
        [ForeignKey("AssignedCountryId")]
        public virtual Countries AssignedCountry { get; set; }
    }
}
