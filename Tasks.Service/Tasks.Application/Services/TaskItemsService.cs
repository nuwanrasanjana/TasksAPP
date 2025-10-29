using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Application.DTOs;
using Tasks.Application.Interfaces.Services;
using Tasks.Domain.Entities;
using Tasks.Domain.Interfaces.Repositories;
using Tasks.Infrastructure.Context;

namespace Tasks.Application.Services
{
    public class TaskItemsService : ITaskItemsService
    {
        private readonly ITaskItemsRepository _taskItemsService;
        public TaskItemsService(ITaskItemsRepository taskItemsService)
        {
            _taskItemsService = taskItemsService;
        }

        public async Task<TaskItem> CreateAsync(CreateTaskItemDTO item)
        {
            TaskItem taskItem = new TaskItem
            {
                Id = new Guid(),
                Description = item.Description,
                IsCompleted = item.IsCompleted
            };
            await _taskItemsService.CreateAsync(taskItem);
            return taskItem;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existingItem = await GetByIdAsync(id);
            if (existingItem == null)
                return false;
            await _taskItemsService.DeleteAsync(existingItem);
            return true;
        }

        public async Task<IEnumerable<TaskItem>> GetAllAsync()
        {
            return await _taskItemsService.GetAllAsync();
        }

        public async Task<TaskItem?> GetByIdAsync(Guid id)
        {
            return await _taskItemsService.GetByIdAsync(id);
        }

        public async Task<TaskItem> UpdateAsync(TaskItem item)
        {
            var existingItem = await GetByIdAsync(item.Id);
            if (existingItem == null)
                return null;
            existingItem.Id = item.Id;
            existingItem.Description = item.Description;
            existingItem.IsCompleted = item.IsCompleted;

            await _taskItemsService.UpdateAsync(existingItem);
            return item;
        }
    }
}
