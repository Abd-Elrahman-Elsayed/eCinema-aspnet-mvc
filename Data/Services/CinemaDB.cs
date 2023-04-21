using eCinema.Data.Interfaces;
using eCinema.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace eCinema.Data.Services
{
    public class CinemaDB : IEntity<Cinema>
    {
        public readonly AppDbContext _context;
        public CinemaDB(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cinema>> GetAllAsync()
        {
            return await _context.Cinemas.ToListAsync();
        }

        public async Task<Cinema> AddAsync(Cinema entity)
        {
            _context.Cinemas.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Cinema> GetByIdAsync(int id)
        {
            return await _context.Cinemas.FirstOrDefaultAsync(a => a.Id == id);
        }

		public async Task UpdateAsync(Cinema entity)
		{
			var OldCinema = await GetByIdAsync(entity.Id);
            OldCinema.Name = entity.Name;
            OldCinema.Description = entity.Description;
            OldCinema.Logo = entity.Logo;
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			_context.Cinemas.Remove(await GetByIdAsync(id));
			await _context.SaveChangesAsync();
		}
	}
}
