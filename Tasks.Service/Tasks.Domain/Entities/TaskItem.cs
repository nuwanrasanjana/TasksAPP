using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Domain.Entities
{
    public class TaskItem : BaseEntity
    {
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}
