using eCinema.Data.Interfaces;
using eCinema.Models;
using Microsoft.EntityFrameworkCore;

namespace eCinema.Data.Services
{
    public class ProducerDB : IEntity<Producer>
    {
        public readonly AppDbContext _context;
        public ProducerDB(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Producer>> GetAllAsync()
        {
            return await _context.Producers.ToListAsync();
        }

        public async Task<Producer> AddAsync(Producer entity)
        {
            _context.Producers.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Producer> GetByIdAsync(int id)
        {
            return await _context.Producers.FirstOrDefaultAsync(a => a.Id == id);
        }

		public async Task UpdateAsync(Producer entity)
		{
			var OldProducer = await GetByIdAsync(entity.Id);
			OldProducer.FullName = entity.FullName;
            OldProducer.Bio = entity.Bio;
            OldProducer.ImageUrl = entity.ImageUrl;
            await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			_context.Producers.Remove(await GetByIdAsync(id));
			await _context.SaveChangesAsync();
		}
	}
}
