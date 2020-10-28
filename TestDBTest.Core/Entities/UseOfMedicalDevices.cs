using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDBTest.Entities
{
    public class UseOfMedicalDevices : FullAuditedEntity
    {
        public string ConcomitantUseOfOtherMedicalDevices { get; set; }
        public string OtherRelevantInformation { get; set; }

        public int OfficialGazzeteId { get; set; }
        [ForeignKey("OfficialGazzeteId")]
        public virtual OfficialGazzete OfficialGazzete { get; set; }
    }
}
