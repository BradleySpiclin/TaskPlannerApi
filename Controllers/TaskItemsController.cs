using Microsoft.AspNetCore.Mvc;
using TaskPlannerApi.Dtos;
using TaskPlannerApi.Extensions;
using TaskPlannerApi.Models;
using TaskPlannerApi.Repositories;

namespace TaskPlannerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemsController : ControllerBase
    {
        private readonly TaskItemRepository _taskItemRepository;

        public TaskItemsController(TaskItemRepository taskItemRepository)
        {
            _taskItemRepository = taskItemRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItemDTO>>> GetAllTasks()
        {
            var taskItems = await _taskItemRepository.GetAll();

            if (taskItems == null || !taskItems.Any())
            {
                return NotFound();
            }

            var taskItemDtos = taskItems.ConvertToDTO();

            return Ok(taskItemDtos);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<TaskItemDTO>>> GetTaskById(int id)
        {
            var taskItem = await this._taskItemRepository.Get(id);

            if (taskItem == null)
            {
                return NotFound();
            }
            var taskItemDTO = taskItem.ConvertToDTO();

            return Ok(taskItemDTO);
        }
        
        [HttpGet("GetTasksByCategoryId")]
        public async Task<ActionResult<IEnumerable<TaskItemDTO>>> GetTasksByCategoryId(int id)
        {
            try
            {
                var taskItems = await _taskItemRepository.GetAllById(id);

                if (taskItems == null || !taskItems.Any())
                {
                    return NoContent();
                }

                var taskItemDTOs = taskItems.ConvertToDTO();

                return Ok(taskItemDTOs);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred");
            }
        }

        [HttpPost]
        public async Task<ActionResult<TaskItemDTO>> CreateTask(int categoryID, TaskItemDTO taskItemDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid task item data");
            }

            var taskItem = new TaskItem
            {
                Id = taskItemDto.Id,
                Name = taskItemDto.Name,
                Comments = taskItemDto.Comments,
                DueDate = taskItemDto.DueDate,
                IsComplete = taskItemDto.IsComplete,
                CategoryId = categoryID
            };

            var createdTaskItem = await _taskItemRepository.Create(taskItem);
            var createdTaskItemDto = createdTaskItem.ConvertToDTO();
            return CreatedAtAction(nameof(GetTaskById), new { categoryId = taskItemDto.CategoryId, id = createdTaskItemDto.Id }, createdTaskItemDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteTaskItem(int id)
        {
            var deleted = await _taskItemRepository.Delete(id);

            if (deleted)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpPut]
        public async Task<ActionResult<TaskItemDTO>> UpdateTaskItem(TaskItemDTO taskItemDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid task item data");
            }

            var existingTaskItem = await _taskItemRepository.Get(taskItemDto.Id);

            if (existingTaskItem == null)
            {
                return NotFound();
            }

            existingTaskItem.Name = taskItemDto.Name;
            existingTaskItem.Comments = taskItemDto.Comments;
            existingTaskItem.DueDate = taskItemDto.DueDate;
            existingTaskItem.IsComplete = taskItemDto.IsComplete;

            var updatedTaskItem = await _taskItemRepository.Update(existingTaskItem);
            return Ok(updatedTaskItem.ConvertToDTO());
        }     
    }
}
