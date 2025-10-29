using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Application.DTOs;
using Tasks.Domain.Entities;

namespace Tasks.Application.Interfaces.Services
{
    public interface ITaskItemsService
    {
        Task<IEnumerable<TaskItem>> GetAllAsync();
        Task<TaskItem?> GetByIdAsync(Guid id);
        Task<TaskItem> CreateAsync(CreateTaskItemDTO item);
        Task<TaskItem> UpdateAsync(TaskItem item);
        Task<bool> DeleteAsync(Guid id);
    }
}
