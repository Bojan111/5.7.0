using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDBTest.Services
{
    public interface ICountryAppService : IApplicationService
    {
        CountryDto UpdateCountry(CountryDto input);

        CountryDto CreateCountry(CountryDto input);

        Task<GetAllCountries> GetAllCountries();


        void DeleteCountry(int countryId);
    }
}
