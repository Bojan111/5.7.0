using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace TestDBTest.Entities
{
    public class ManufacturerInfo : FullAuditedEntity
    {
        public string ManufacturName { get; set; }
  
        public string ManufaturAddress { get; set; }

        public int NumberOfMedicalDevice { get; set; }

        public string ApplicantHealthInstitution { get; set; }
        public string ApplicantFullNameHealthWorker { get; set; }
        public DateTime? DateOfUseMedicalDevice { get; set; }

        public string ApplicantAddress { get; set; }

        public int ApplicantPhone { get; set; }
       
        public string ApplicantEmail { get; set; }

        public string Signature { get; set; }

        public SourceOfApplication SourceOfApplication { get; set; }

        public TypeOfApp TypeOfApp { get; set; }

        public int OfficialGazzeteId { get; set; }
        [ForeignKey("OfficialGazzeteId")]
        public virtual OfficialGazzete OfficialGazzete { get; set; }

    }
    public enum SourceOfApplication
    {
       Болница,
       ОпштДоктор,
       ДокторСпецијалист,
       Друго
    }

    public enum TypeOfApp
    {
        Спонтана,
        ОдКлиничкаСтудија,
        ЦелноМониторирањеНаПодносливостаНаМедициснкоПомагало
    }
}
