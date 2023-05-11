using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace eCinema.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext context;

        public EntityBaseRepository(AppDbContext _context)
        {
            context = _context;
        }

        public async Task<T> AddAsync(T entity)
        {
            context.Set<T>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            T entity = await context.Set<T>().FirstOrDefaultAsync(a => a.Id == id);
            EntityEntry entityEntry = context.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;
            await context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync() => await context.Set<T>().ToListAsync();
        

        public async Task<T> GetByIdAsync(int id) =>  await context.Set<T>().FirstOrDefaultAsync(a => a.Id == id);
        

        public async Task UpdateAsync(T entity)
        {
            EntityEntry entityEntry = context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
