using FuniWebApp.Data.Interfaces;
using FuniWebApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FuniWebApp.Data.Services;

public class CategoryServices : ICategoryInterface
{
    private readonly FuniWebDbContext _dbContext;

    public CategoryServices(FuniWebDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task AddAsync(Category category)
    {
        await _dbContext.Categories.AddAsync(category);
        await _dbContext.SaveChangesAsync();
    }


    public async Task DeleteAsync(int id)
    {
        var category = await GetByIdAsync(id);
        _dbContext.Categories.Remove(category);
        await _dbContext.SaveChangesAsync();
    }


    public async Task<List<Category>> GetAllAsync()
        => await _dbContext.Categories.ToListAsync();



    public async Task<Category> GetByIdAsync(int id)
        => await _dbContext.Categories
            .FirstOrDefaultAsync(c => c.Id == id) ?? new Category();

    public async Task<Category> GetByIdWithBookAsync(int id)
            => await _dbContext.Categories
                        .Include(c => c.Funis)
                        .FirstOrDefaultAsync(c => c.Id == id)
                        ?? new Category() { Name = "Empty category" };

    public async Task<List<Category>> GetTop3CategoriesAsync()
    {
        var list = await GetAllAsync();
        return list.OrderByDescending(c => c.Name).Take(3)
                                    .ToList();
    }

    public async Task UpdateAsync(Category category)
    {
        _dbContext.Update(category);
        await _dbContext.SaveChangesAsync();
    }
}
