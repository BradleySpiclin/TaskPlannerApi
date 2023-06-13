
namespace TaskPlannerApi.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Comments { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsComplete { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
