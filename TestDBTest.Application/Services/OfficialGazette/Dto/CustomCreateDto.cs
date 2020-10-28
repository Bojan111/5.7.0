using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDBTest.Entities;
using TestDBTest.Services.ManufacturerInfo.Dto;
using TestDBTest.Services.MedicalDeviceInfo.Dto;
using TestDBTest.Services.OfficialGazzet.Dto;
using TestDBTest.Services.UseOfMedicalDevices.Dto;

namespace TestDBTest.Services.OfficialGazette.Dto
{

    public class CustomCreateDto
    {
     
        public OfficialGazzeteDto OfficialGazzete { get; set; }
        public MedicalDeviceInfoDto MedicalDeviceInfo { get; set; }
        public ManufacturerInfoDto ManufacturerInfo { get; set; }
        public UseOfMedicalDevicesDto UseOfMedicalDevices { get; set; }
    }
}
