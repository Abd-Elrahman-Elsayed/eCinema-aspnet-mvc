namespace eCinema.Data.Interfaces
{
    public interface IEntity<T>
    {
        public Task<List<T>> GetAllAsync();
        public Task<T> AddAsync(T entity);
        public Task<T> GetByIdAsync(int id);
        public Task UpdateAsync(T entity);
        public Task DeleteAsync(int id);
    }
}
