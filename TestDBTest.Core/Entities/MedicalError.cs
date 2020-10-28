using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDBTest.Entities
{
    public class MedicalError : FullAuditedEntity
    {
        public string Description { get; set; }

        public string NameAndForm { get; set; }
        public double Strength { get; set; }
        public string PathOfAdministration { get; set; }
        public string Indication { get; set; }

        public Personnel Personnel { get; set; }

        public MedicalPartOfError PartOfError { get; set; }

        public TypeOfError TypeOfError { get; set; }
        public string TakeAnAction { get; set; }
    }

    public enum MedicalPartOfError
    {
        ReassignedTherapy,
        AssignedTherapy,
        PreparingTherapy,
        Administration,
        Monitoring,
        Other
    }
    public enum TypeOfError
    {
        WrongPatient,
        WrongDoseStrenght,
        WrongPahtOfAdministration,
        WrongDoseForm,
        WrongTime,
        WrongAmount,
        Other
    }
}

