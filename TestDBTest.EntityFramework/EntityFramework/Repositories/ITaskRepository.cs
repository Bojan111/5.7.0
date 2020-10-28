using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDBTest.Entities;

namespace TestDBTest
{
    public interface ITaskRepository : IRepository<Entities.Task, long>
    {
     
        List<Entities.Task> GetAllWithPeople(int? assignedPersonId, TaskState? state);
    }
}
