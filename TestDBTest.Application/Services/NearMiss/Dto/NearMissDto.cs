using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDBTest.Entities;

namespace TestDBTest.Services.NearMiss.Dto
{
    [AutoMap(typeof(Entities.NearMiss))]
    public class NearMissDto : FullAuditedEntityDto
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
}
