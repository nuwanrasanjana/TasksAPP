using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tasks.Application.DTOs;
using Tasks.Application.Interfaces.Services;
using Tasks.Application.Services;
using Tasks.Domain.Entities;

namespace Tasks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemsController : ControllerBase
    {
        private readonly ITaskItemsService _taskItemsService;
        private readonly IValidator<CreateTaskItemDTO> _createTaskItemDTOvalidate;
        private readonly IValidator<TaskItem> _updateTaskItemDTOvalidate;
        public TaskItemsController(ITaskItemsService taskItemsService, 
            IValidator<CreateTaskItemDTO> createTaskItemDtoValidator,
            IValidator<TaskItem> updateTaskItemDTOvalidate)
        {
            _taskItemsService = taskItemsService;
            _createTaskItemDTOvalidate = createTaskItemDtoValidator;
            _updateTaskItemDTOvalidate = updateTaskItemDTOvalidate;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _taskItemsService.GetAllAsync();
            return Ok(items);
        }
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var item = await _taskItemsService.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTaskItemDTO item)
        {
            var result = await _createTaskItemDTOvalidate.ValidateAsync(item);
            if (!result.IsValid)
                return BadRequest(result.Errors);
            if (item == null) return BadRequest("TaskItem cannot be null.");
            var created = await _taskItemsService.CreateAsync(item);
            return Ok(created);
        }
        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] TaskItem item)
        {
            var result = _updateTaskItemDTOvalidate.Validate(item);
            if(!result.IsValid)
                return BadRequest(result.Errors);

            var updated = await _taskItemsService.UpdateAsync(item);
            if (updated == null)
                return NotFound();
            return Ok(updated);

        }
        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _taskItemsService.DeleteAsync(id);
            if (deleted == false)
                return NotFound();
            return NoContent();
        }
    }
}
