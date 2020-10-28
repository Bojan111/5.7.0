using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestDBTest.Entities;

namespace TestDBTest.Web.Models
{
    public class GazetteViewModel
    {
        //public IEnumerable<OfficialGazzeteDto> OfficialGazzetes { get; set; }

    
        public string ApplicationForUnwantedMedDevices { get; set; }
        public string DescribeYourAdverseReaction { get; set; }
        public OutComeOfAverseReaction OutComeOfAverseReaction { get; set; }

        public DateTime? ErrorDetectionDate { get; set; }
        public ConnectionBetweenAdverseReaction ConnectionBetweenAdverseReaction { get; set; }

        public virtual Person Person { get; set; }

        public virtual ICollection<ManufacturerInfo> ManufacturerInfos { get; set; }
        public virtual ICollection<MedicalDeviceInfo> MedicalDeviceInfo { get; set; }
        public virtual ICollection<UseOfMedicalDevices> UseOfMedicalDevices { get; set; }

    }
}