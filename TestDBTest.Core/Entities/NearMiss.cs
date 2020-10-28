using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDBTest.Entities
{
    public class NearMiss : FullAuditedEntity
    {
        public string Description { get; set; }

        public string NameAndForm { get; set; }
        public double Strength { get; set; }
        public string PathOfAdministration { get; set; }
        public string Indication { get; set; }

        public Personnel Personnel { get; set; }

        public PartOfError PartOfError { get; set; }


        public string CorrectiveMeasureTaken { get; set; }
    }

    public enum Personnel
    {
        Doctor,
        Pharmacist,
        Nurse,
        Other
    }

    public enum PartOfError
    {
        ReassignedTherapy,
        AssignedTherapy,
        PreparingTherapy,
        AdministrationApplication,
        Other
    }
}
