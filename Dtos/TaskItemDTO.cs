using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TaskPlannerApi.Dtos
{
    public class TaskItemDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Task name is required.")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        public string Name { get; set; }
        [StringLength(100, ErrorMessage = "Comments cannot exceed 100 characters.")]
        public string? Comments { get; set; }
        [Required(ErrorMessage = "Due date is required.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true, NullDisplayText = "")]
        public DateTime DueDate { get; set; }
        public bool IsComplete { get; set; }
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
    }
}
