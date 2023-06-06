using Microsoft.EntityFrameworkCore;

namespace TaskPlannerApi.Models
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
        }

        public DbSet<TaskItemDTO> TaskItems { get; set; } = null!;
    }
}
