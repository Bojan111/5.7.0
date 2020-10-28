using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDBTest.Entities;

namespace TestDBTest.Services
{

    //public class MdlMicrobiologyMasterAppService : 
    //AsyncCrudAppService<MdlMicrobiologyMaster, MdlMicrobiologyMasterDto, long, 
    //PagedResultRequestDto, MdlMicrobiologyMasterDto, MdlMicrobiologyMasterDto>, 
    //IMdlMicrobiologyMasterAppService, ISearchAppService<MdlMicrobiologyMasterDto, MdlMicrobiologyMasterInput>
    public class FormAppService : AsyncCrudAppService<TypeOfApplication, TypeOfApplicationDto>, IFormAppService
    {
        private readonly IRepository<MedicalError> _medicalErrorRepository;
        private readonly IRepository<Entities.NearMiss> _nearMissRepository;
        public FormAppService(IRepository<TypeOfApplication, int> repository, IRepository<MedicalError> medicalErrorRepository, IRepository<Entities.NearMiss> nearMissRepository) : base(repository)
        {
            _medicalErrorRepository = medicalErrorRepository;
            _nearMissRepository = nearMissRepository;
        }

        public override async Task<PagedResultDto<TypeOfApplicationDto>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
            var result = await Repository
                  .GetAllIncluding(r => r.Person, z => z.NearMiss, r => r.MedicalError)                 
                 .ToListAsync();

            var output = new PagedResultDto<TypeOfApplicationDto>()
            {
                TotalCount = result.Count,
                Items = ObjectMapper.Map<List<TypeOfApplicationDto>>(result)
            };

            return output;
        }

        public override async Task<TypeOfApplicationDto> CreateAsync(TypeOfApplicationDto input)
        {
            if (input.MedicalErrorDescription != null)
            {
                var medicalErr = new MedicalError()
                {
                    Description = input.MedicalErrorDescription,
                    NameAndForm = input.MedicalErrorNameAndForm,
                    Strength = input.MedicalErrorStrength,
                    PathOfAdministration = input.MedicalErrorPathOfAdministration,
                    Indication = input.MedicalErrorIndication,
                    Personnel = input.MedicalErrorPersonnel.Value,
                    PartOfError = input.MedicalErrorPartOfError.Value,
                    TypeOfError = input.MedicalErrorTypeOfError.Value,
                    TakeAnAction = input.MedicalErrorTakeAnAction
                };

              
                input.MedicalErrorId = await _medicalErrorRepository.InsertAndGetIdAsync(medicalErr);

            }
            else
            {
                var nearMiss = new Entities.NearMiss()
                {
                    Description = input.NearMissDescription,
                    NameAndForm = input.NearMissNameAndForm,
                    Strength = input.NearMissStrength,
                    PathOfAdministration = input.NearMissPathOfAdministration,
                    Indication = input.NearMissIndication,
                    Personnel = input.NearMissPersonnel.Value,
                    PartOfError = input.NearMissPartOfError.Value,
                    CorrectiveMeasureTaken = input.NearMissCorrectiveMeasureTaken
                };

                input.NearMissId = await _nearMissRepository.InsertAndGetIdAsync(nearMiss);
               
            }
            input.DateTime = DateTime.Now;
            return await base.CreateAsync(input);
        }

        public override System.Threading.Tasks.Task DeleteAsync(EntityDto<int> input)
        {
            return base.DeleteAsync(input);
        }
    }
}
