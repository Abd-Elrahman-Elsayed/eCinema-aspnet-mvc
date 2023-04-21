using eCinema.Data.Interfaces;
using eCinema.Models;
using Microsoft.EntityFrameworkCore;

namespace eCinema.Data.Services
{
    public class ActorDB : IEntity<Actor>
    {
        public readonly AppDbContext _context;
        public ActorDB(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Actor>> GetAllAsync()
        {
            return await _context.Actors.ToListAsync();
        }


        public async Task<Actor> AddAsync(Actor entity)
        {
            _context.Actors.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Actor> GetByIdAsync(int id)
        {
            return await _context.Actors.FirstOrDefaultAsync(a=>a.Id==id);
        }

		public async Task UpdateAsync(Actor entity)
		{
			var OldActor = await GetByIdAsync(entity.Id);
            OldActor.FullName = entity.FullName;
            OldActor.BirthDate = entity.BirthDate;
            OldActor.Bio = entity.Bio;
            OldActor.ImageUrl = entity.ImageUrl;
            OldActor.Country = entity.Country;
            await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			_context.Actors.Remove(await GetByIdAsync(id));
            await _context.SaveChangesAsync();
		}
	}
}
