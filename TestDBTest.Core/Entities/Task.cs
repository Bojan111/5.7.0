﻿using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDBTest.Entities
{
    public class Task : Entity<long>
    {
        public long? AssignedPersonId { get; set; }
        [ForeignKey("AssignedPersonId")]
        public virtual Person AssignedPerson { get; set; }
        public string Description { get; set; }

        public DateTime CreationTime { get; set; }

        public TaskState State { get; set; }

        public Task()
        {
            CreationTime = DateTime.Now;
            State = TaskState.Active;
        }
    }

    public enum TaskState : byte
    {
        Active = 1,
        Completed = 2
    }
}
