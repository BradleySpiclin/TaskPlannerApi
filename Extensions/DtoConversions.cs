using TaskPlannerApi.Dtos;
using TaskPlannerApi.Models;

namespace TaskPlannerApi.Extensions
{
    public static class DtoConversions
    {
        public static IEnumerable<TaskItemDTO> ConvertToDTO(this IEnumerable<TaskItem> taskItems)
        {
            return (from item in taskItems
                    select new TaskItemDTO
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Comments = item.Comments,
                        DueDate = item.DueDate,
                        IsComplete = item.IsComplete,
                        CategoryId = item.CategoryId,
                    }).ToList();
        }
        public static TaskItemDTO ConvertToDTO(this TaskItem taskItem)
        {
            return new TaskItemDTO
            {
                Id = taskItem.Id,
                Name = taskItem.Name,
                Comments = taskItem.Comments,
                DueDate = taskItem.DueDate,
                IsComplete = taskItem.IsComplete,
                CategoryId = taskItem.CategoryId,
            };
        }
        public static CategoryDTO ConvertToDTO(this Category taskItem)
        {
            return new CategoryDTO
            {
                Id = taskItem.Id,
                Name = taskItem.Name
            };
        }
        public static IEnumerable<CategoryDTO> ConvertToDTO(this IEnumerable<Category> categories)
        {
            return (from category in categories
                    select new CategoryDTO
                    {
                        Id = category.Id,
                        Name = category.Name,
                    }).ToList();
        }
    }
}
