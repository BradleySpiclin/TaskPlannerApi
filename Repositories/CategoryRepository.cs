using Microsoft.EntityFrameworkCore;
using TaskPlannerApi.Data;
using TaskPlannerApi.Models;
using TaskPlannerApi.Repositories.Contracts;

namespace TaskPlannerApi.Repositories
{
    public class CategoryRepository : IBaseRepository<Category>
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Category> Create(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<bool> Delete(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return false;
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Category> Get(int id)
        {
            var category = await this._context.Categories.SingleOrDefaultAsync(c => c.Id == id);
            return category;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            var categories = await this._context.Categories.ToListAsync();
            return categories;
        }

        public async Task<Category> Update(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return category;
        }
    }
}
