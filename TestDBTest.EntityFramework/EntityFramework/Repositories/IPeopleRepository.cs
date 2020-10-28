using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDBTest.EntityFramework.Repositories
{
    public interface IPeopleRepository : IRepository<Entities.Person, long>
    {
        List<Entities.Person> GetAllWithPeople(int? assignedCountryId);
    }
}
