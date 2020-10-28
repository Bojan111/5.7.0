using Abp.Application.Services;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDBTest.Entities;

namespace TestDBTest.Services
{
    public class CountryAppService : ApplicationService, ICountryAppService
    {
        private readonly IRepository<Entities.Countries> countryRepository;

        public CountryAppService(IRepository<TestDBTest.Entities.Countries> _countryRepository)
        {
            countryRepository = _countryRepository;
        }

        public async Task<GetAllCountries> GetAllCountries()
        {
            var country = await countryRepository.GetAllListAsync();

            return new GetAllCountries
            {
                Countries = country.MapTo<List<CountryDto>>()
                
            };
        }

        public CountryDto CreateCountry(CountryDto input)
        {
            var country = ObjectMapper.Map<TestDBTest.Entities.Countries>(input);
            var newId = countryRepository.InsertAndGetId(country);

            var createdCountry = countryRepository.Get(newId);
            var output = ObjectMapper.Map<CountryDto>(createdCountry);
            return output;
        }

        public CountryDto UpdateCountry(CountryDto input)
        {

            var country = ObjectMapper.Map<TestDBTest.Entities.Countries>(input);
            var coutryUpdated = countryRepository.Update(country);


            var output = ObjectMapper.Map<CountryDto>(coutryUpdated);

            return output;

        }


        public void DeleteCountry(int countryId)
        {
            countryRepository.Delete(countryId);
        }
    }
}
