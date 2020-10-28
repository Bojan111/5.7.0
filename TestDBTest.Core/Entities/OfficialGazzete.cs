using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDBTest.Entities
{
    public class OfficialGazzete : FullAuditedEntity
    {
        public string ApplicationForUnwantedMedDevices { get; set; }
        public string DescribeYourAdverseReaction { get; set; }
        public OutComeOfAverseReaction OutComeOfAverseReaction { get; set; }

        public DateTime? ErrorDetectionDate { get; set; }
        public ConnectionBetweenAdverseReaction ConnectionBetweenAdverseReaction { get; set; }

        public long? PersonId { get; set; }
        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }

        public virtual ICollection<ManufacturerInfo> ManufacturerInfos { get; set; }
        public virtual ICollection<MedicalDeviceInfo> MedicalDeviceInfo { get; set; }
        public virtual ICollection<UseOfMedicalDevices> UseOfMedicalDevices { get; set; }
        

    }
}
