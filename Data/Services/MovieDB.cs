using eCinema.Data.Interfaces;
using eCinema.Models;
using Microsoft.EntityFrameworkCore;

namespace eCinema.Data.Services
{
    public class MovieDB : IEntity<Movie>
    {
        public readonly AppDbContext _context;
        public MovieDB(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Movie>> GetAllAsync()
        {
            return await _context.Movies.Include(m => m.Cinema).ToListAsync();
        }

        public async Task<Movie> AddAsync(Movie entity)
        {
            _context.Movies.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            return await _context.Movies.FirstOrDefaultAsync(a => a.Id == id);
        }

		public async Task UpdateAsync(Movie entity)
		{
			var OldMovie = await GetByIdAsync(entity.Id);
            OldMovie.StartDate = entity.StartDate;
            OldMovie.EndtDate = entity.EndtDate;
            OldMovie.MovieCategory = entity.MovieCategory;
            OldMovie.Price = entity.Price;
            OldMovie.Name = entity.Name;
            OldMovie.Description = entity.Description;
            OldMovie.ImageUrl = entity.ImageUrl;
            await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			_context.Movies.Remove(await GetByIdAsync(id));
			await _context.SaveChangesAsync();
		}
	}
}
