using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDBTest.Entities
{
    public class MedicalDeviceInfo : FullAuditedEntity
    {
        public string SuspectedMedicalDevice { get; set; }
        public string MethodOfApplication { get; set; }

        public string IndicationOfUse { get; set; }
        public DateTime? StartDateFillForm { get; set; }
        public DateTime? EndDateFillForm { get; set; }
        public DidReactionGoneAfterUseMedicalDevice DidReactionGoneAfterUseMedicalDevice { get; set; }

        public DoesTheReactionOccurAgain DoesTheReactionOccurAgain { get; set; }

        public int OfficialGazzeteId { get; set; }
        [ForeignKey("OfficialGazzeteId")]
        public virtual OfficialGazzete OfficialGazzete { get; set; }
    }

    public enum DidReactionGoneAfterUseMedicalDevice
    {
        Да,
        Не,
        Непознато
    }
    public enum DoesTheReactionOccurAgain
    {
        Да,
        Не,
        Непознато
    }
}
