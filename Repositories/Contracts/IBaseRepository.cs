
namespace TaskPlannerApi.Repositories.Contracts
{
    public interface IBaseRepository<TEntity>
    {
        // Read methods
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Get(int id);

        // Insert method
        Task<TEntity> Create(TEntity entity);

        // Delete method
        Task<bool> Delete(int id);

        // Update method
        Task<TEntity> Update(TEntity entity);
    }
}
