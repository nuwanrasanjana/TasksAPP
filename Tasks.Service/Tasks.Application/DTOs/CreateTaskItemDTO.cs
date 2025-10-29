using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Application.DTOs
{
    public class CreateTaskItemDTO
    {
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}
