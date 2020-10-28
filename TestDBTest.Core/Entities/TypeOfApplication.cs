using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDBTest.Entities
{
    public class TypeOfApplication : FullAuditedEntity
    {

        public int? NearMissId { get; set; }
        [ForeignKey("NearMissId")]
        public virtual NearMiss NearMiss { get; set; }
        [ForeignKey("MedicalErrorId")]
        public virtual MedicalError MedicalError { get; set; }
        public int? MedicalErrorId { get; set; }

        public long PersonId { get; set; }
        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }

        // Potpis
        public string FullName { get; set; }
        public DateTime DateTime { get; set; }

        public PlaceOfErrorDetection PlaceOfErrorDetection { get; set; }

        public PlaceOfErrorDetection PlaceOfCreationError { get; set; }
    }

    public enum PlaceOfErrorDetection
    {
        IntesiveCare,
        SemiIntesiveCare,
        DayHospital,
        OperacionRoom,
        PharmaceuticalDepartment,
        Other
    }


}
