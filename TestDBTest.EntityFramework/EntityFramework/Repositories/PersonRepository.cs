using Abp.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDBTest.Entities;

namespace TestDBTest.EntityFramework.Repositories
{
    public class PersonRepository : TestDBTestRepositoryBase<Entities.Person, long>, IPeopleRepository
    {
        public PersonRepository(IDbContextProvider<TestDBTestDbContext> dbContextProvider)
           : base(dbContextProvider)
        {
        }

        public List<Person> GetAllWithPeople(int? assignedCountryId)
        {
            var query = GetAll();

            if (assignedCountryId.HasValue)
            {
                query = query.Where(r => r.AssignedCountryId == assignedCountryId.Value);
            }

            return query.Include(r => r.AssignedCountry).ToList();
        }
    }
}
