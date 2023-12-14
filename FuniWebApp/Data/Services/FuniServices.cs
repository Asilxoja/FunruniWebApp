using FuniWebApp.Areas.Admin.Data.Interfaces;
using FuniWebApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FuniWebApp.Data.Services
{
    public class FuniServices : IFuniInterface
    {
        private readonly FuniWebDbContext _dbContext;

        public FuniServices(FuniWebDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(Funi funi)
        {
            await _dbContext.Funis.AddAsync(funi);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var funi = await GetByIdAsync(id);
            _dbContext.Funis.Remove(funi);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Funi>> GetAllAsync()
            => await _dbContext.Funis.ToListAsync();

        public async Task<Funi> GetByIdAsync(int id)
        => await _dbContext.Funis
            .FirstOrDefaultAsync(c => c.Id == id) ?? new Funi { };

        public async Task<Funi> GetByIdWithCategoryAsync(int id)
         => await _dbContext.Funis
            .Include(b => b.Category)
            .FirstOrDefaultAsync(c => c.Id == id) ?? new Funi{Title = "Empitiy"};

        public async Task<List<Funi>> GetNew3Funis()
                    => await _dbContext.Funis
			                            .Include(b => b.Category)
										.OrderByDescending(c => c.Id) 
                                        .Take(3).ToListAsync();



		public async Task UpdateAsync(Funi funi)
        {
            _dbContext.Update(funi);
            await _dbContext.SaveChangesAsync();
        }
    }
}
