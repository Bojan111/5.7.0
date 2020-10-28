using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDBTest.Entities;
using TestDBTest.Services.ManufacturerInfo;
using TestDBTest.Services.MedicalDeviceInfo;
using TestDBTest.Services.OfficialGazette.Dto;
using TestDBTest.Services.OfficialGazzet.Dto;
using TestDBTest.Services.UseOfMedicalDevices;

namespace TestDBTest.Services.OfficialGazzet
{
    public class OfficialGazzeteAppService : AsyncCrudAppService<OfficialGazzete, OfficialGazzeteWithListsDto, int, PagedAndSortedResultRequestDto, OfficialGazzeteDto>, IOfficialGazzeteAppService
    {
        private readonly IRepository<Entities.ManufacturerInfo> _manufacturerInfo;
        private readonly IRepository<Entities.MedicalDeviceInfo> _medicalDeviceInfo;
        private readonly IRepository<Entities.UseOfMedicalDevices> _useOfMedicalDevices;

        private readonly IManufacturerInfoAppService manufacturerInfoAppService;
        private readonly IMedicalDeviceInfoAppService medicalDeviceInfoAppService;
        private readonly IUseOfMedicalDevicesAppService useOfMedicalDevicesAppService;

        public OfficialGazzeteAppService(IRepository<OfficialGazzete, int> repository,
            IRepository<Entities.ManufacturerInfo> manufacturerInfo,
            IRepository<Entities.MedicalDeviceInfo> medicalDeviceInfo,
            IRepository<Entities.UseOfMedicalDevices> useOfMedicalDevices,
            IManufacturerInfoAppService manufacturerInfoAppService,
            IUseOfMedicalDevicesAppService useOfMedicalDevicesAppService,
            IMedicalDeviceInfoAppService medicalDeviceInfoAppService
            ) : base(repository)
        {
            _manufacturerInfo = manufacturerInfo;
            _medicalDeviceInfo = medicalDeviceInfo;
            _useOfMedicalDevices = useOfMedicalDevices;
            this.manufacturerInfoAppService = manufacturerInfoAppService;
            this.useOfMedicalDevicesAppService = useOfMedicalDevicesAppService;
            this.medicalDeviceInfoAppService = medicalDeviceInfoAppService;
        }



        public async Task<CustomCreateDto> CustomUpdateAsync(CustomCreateDto input)
        {

            CustomCreateDto output = new CustomCreateDto();

            var OfficialGazzete = await UpdateAsync(input.OfficialGazzete);
            output.OfficialGazzete = OfficialGazzete;

            output.ManufacturerInfo = await manufacturerInfoAppService.UpdateAsync(input.ManufacturerInfo);


            output.MedicalDeviceInfo = await medicalDeviceInfoAppService.UpdateAsync(input.MedicalDeviceInfo);


            output.UseOfMedicalDevices = await useOfMedicalDevicesAppService.UpdateAsync(input.UseOfMedicalDevices);


            return output;
          
        }



        public async Task<CustomCreateDto> CustomCreateAsync(CustomCreateDto input)
        {

            CustomCreateDto output = new CustomCreateDto();

            var OfficialGazzete = await base.CreateAsync(input.OfficialGazzete);

            output.OfficialGazzete = OfficialGazzete;

            input.ManufacturerInfo.OfficialGazzeteId = output.OfficialGazzete.Id;
            var a = await manufacturerInfoAppService.CreateAsync(input.ManufacturerInfo);

            input.MedicalDeviceInfo.OfficialGazzeteId = output.OfficialGazzete.Id;
            var b = await medicalDeviceInfoAppService.CreateAsync(input.MedicalDeviceInfo);

            input.UseOfMedicalDevices.OfficialGazzeteId = output.OfficialGazzete.Id;
            var c = await useOfMedicalDevicesAppService.CreateAsync(input.UseOfMedicalDevices);


            output.MedicalDeviceInfo = b;
            output.UseOfMedicalDevices = c;
            output.ManufacturerInfo = a;


            return output;
        }

      

      
    }
}
