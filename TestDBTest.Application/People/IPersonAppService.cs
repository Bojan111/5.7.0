using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDBTest.Entities;
using TestDBTest.People.Dtos;

namespace TestDBTest.People
{
    public interface IPersonAppService : IApplicationService
    {
        //GetAllPeopleOutput GetAll(GetPeopleInput input);

        PersonDto UpdatePerson(PersonDto input);

        PersonDto CreatePerson(PersonDto input);

        Task<GetAllPeopleOutput> GetAllPeople();
        void DeletePerson(int personId);

    }
}
