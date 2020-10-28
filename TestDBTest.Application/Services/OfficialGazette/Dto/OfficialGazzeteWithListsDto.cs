using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TestDBTest.Entities;
using TestDBTest.Services.ManufacturerInfo.Dto;
using TestDBTest.Services.MedicalDeviceInfo.Dto;
using TestDBTest.Services.UseOfMedicalDevices.Dto;

namespace TestDBTest.Services.OfficialGazzet.Dto
{
    [AutoMap(typeof(OfficialGazzete))]
    public class OfficialGazzeteWithListsDto: OfficialGazzeteDto
    {
        public ICollection<OfficialGazzeteDto> Gazzetes { get; set; } 

        public List<ManufacturerInfoDto> ManufacturerInfos { get; set; }
        public List<MedicalDeviceInfoDto> MedicalDeviceInfo { get; set; }
        public List<UseOfMedicalDevicesDto> UseOfMedicalDevices { get; set; }

        public ManufacturerInfoDto ManufacturerInfosSingle => ManufacturerInfos?.FirstOrDefault();
        public MedicalDeviceInfoDto MedicalDeviceInfoSingle => MedicalDeviceInfo?.FirstOrDefault();
        public UseOfMedicalDevicesDto UseOfMedicalDevicesSingle => UseOfMedicalDevices?.FirstOrDefault();



    }
}
