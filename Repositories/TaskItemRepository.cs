using Microsoft.EntityFrameworkCore;
using TaskPlannerApi.Data;
using TaskPlannerApi.Models;
using TaskPlannerApi.Repositories.Contracts;

namespace TaskPlannerApi.Repositories
{
    public class TaskItemRepository : IBaseRepository<TaskItem>
    {
        private readonly AppDbContext _context;

        public TaskItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskItem>> GetAll()
        {
            var taskItems = await this._context.TaskItems
               .Include(t => t.Category).ToListAsync();

            return taskItems;
        }

        public async Task<IEnumerable<TaskItem>> GetAllById(int id)
        {
            var taskItems = await this._context.TaskItems
               .Where(t => t.CategoryId == id).ToListAsync();

            return taskItems;
        }

        public async Task<TaskItem> Get(int id)
        {
            var taskItem = await _context.TaskItems
            .Include(t => t.Category)
            .SingleOrDefaultAsync(t => t.Id == id);
            return taskItem;
        }

        public async Task<TaskItem> Create(TaskItem taskItem)
        {
            _context.TaskItems.Add(taskItem);
            await _context.SaveChangesAsync();
            return taskItem;
        }

        public async Task<bool> Delete(int id)
        {
            var taskItem = await _context.TaskItems.FindAsync(id);

            if (taskItem == null)
            {
                return false;
            }

            _context.TaskItems.Remove(taskItem);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<TaskItem> Update(TaskItem taskItem)
        {
            _context.Entry(taskItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return taskItem;
        }
    }
}
