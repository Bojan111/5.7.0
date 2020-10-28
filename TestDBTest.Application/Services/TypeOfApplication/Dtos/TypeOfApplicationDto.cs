using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDBTest.Entities;

namespace TestDBTest.Services
{
    [AutoMap(typeof(Entities.TypeOfApplication))]
    public class TypeOfApplicationDto : FullAuditedEntityDto
    {
        // Person
        public long? PersonId { get; set; }
        public string PersonName { get; set; }
        public string PersonLastName { get; set; }
        public Gender PersonGender { get; set; }

        public string PersonGenderFormatted => PersonGender.ToString();
        public string PersonDateOfBirth { get; set; }
        public string PersonErrorDetectionDate { get; set; }

        // Obrazec stuff
        public PlaceOfErrorDetection PlaceOfErrorDetection { get; set; }
        public string PlaceOfErrorDetectionFormatted => PlaceOfErrorDetection.ToString();
        public PlaceOfErrorDetection PlaceOfCreationError { get; set; }

        public string PlaceOfCreationErrorFormatted => PlaceOfCreationError.ToString();
        public string FullName { get; set; }
        public DateTime DateTime { get; set; }

        // Near Miss
        public int? NearMissId { get; set; }
        public string NearMissDescription { get; set; }

        public string NearMissNameAndForm { get; set; }
        public double NearMissStrength { get; set; }
        public string NearMissPathOfAdministration { get; set; }
        public string NearMissIndication { get; set; }

        public Personnel? NearMissPersonnel { get; set; }
        public PartOfError? NearMissPartOfError { get; set; }
        public string NearMissCorrectiveMeasureTaken { get; set; }



        public int? MedicalErrorId { get; set; }
        public string MedicalErrorDescription { get; set; }

        public string MedicalErrorNameAndForm { get; set; }
        public double MedicalErrorStrength { get; set; }
        public string MedicalErrorPathOfAdministration { get; set; }
        public string MedicalErrorIndication { get; set; }

        public Personnel? MedicalErrorPersonnel { get; set; }


        public MedicalPartOfError? MedicalErrorPartOfError { get; set; }
        public TypeOfError? MedicalErrorTypeOfError { get; set; }
        public string MedicalErrorTakeAnAction { get; set; }

    }
}
