using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Extensions;
using AutoMapper;
using Castle.DynamicProxy.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDBTest.Entities;
using TestDBTest.EntityFramework;
using TestDBTest.EntityFramework.Repositories;
using TestDBTest.People.Dtos;

namespace TestDBTest.People
{
    public class PersonAppService : ApplicationService, IPersonAppService
    {
        private readonly IRepository<Person, long> _personRepository;
        private readonly IRepository<Countries> _countriesRepository;

        //ABP provides that we can directly inject IRepository<Person> (without creating any repository class)
        public PersonAppService(IRepository<Person, long> personRepository, IRepository<Countries> countriesRepository)
        {
            _countriesRepository = countriesRepository;
            _personRepository = personRepository;
        }

        public async Task<GetAllPeopleOutput> GetAllPeople()
        {
            //var people = await _personRepository.GetAllListAsync();
            var people = await _personRepository
                .GetAllIncluding(z => z.AssignedCountry)
                .ToListAsync();

            return new GetAllPeopleOutput
            {
                People = people.MapTo<List<PersonDto>>()
            };
        }
        public PersonDto UpdatePerson(PersonDto input)
        {
            Logger.Info("Updating a person for input: " + input);

            var person = ObjectMapper.Map<Person>(input);
            var personUpdated = _personRepository.Update(person);


            if (input.AssignedCountryId.HasValue)
            {
                person.AssignedCountry = _countriesRepository.Load(input.AssignedCountryId.Value);


            }

            var output = ObjectMapper.Map<PersonDto>(personUpdated);

            return output;
        }


        public PersonDto CreatePerson(PersonDto input)
        {
            Logger.Info("Creating a person for input" + input);

            var person = ObjectMapper.Map<Person>(input);
            var newId = _personRepository.InsertAndGetId(person);

            var createdPerson = _personRepository.Get(newId);
            var output = ObjectMapper.Map<PersonDto>(createdPerson);

            if (input.AssignedCountryId.HasValue)
            {
                person.AssignedCountryId = input.AssignedCountryId.Value;
            }

            return output;
        }


        public void DeletePerson(int personId)
        {
            //var person = _personRepository.Get(input.Id);

            _personRepository.Delete(personId);
        }

        //public GetAllPeopleOutput GetAll(GetPeopleInput input)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
