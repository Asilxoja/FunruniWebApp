using FuniWebApp.Data.Models;

namespace FuniWebApp.Data.Interfaces;

public interface ICategoryInterface
{
    Task<List<Category>> GetAllAsync();

    Task<Category> GetByIdWithBookAsync(int id);

    Task<Category> GetByIdAsync(int id);

    Task AddAsync(Category category);

    Task UpdateAsync(Category category);

    Task DeleteAsync(int id);
    Task<List<Category>> GetTop3CategoriesAsync();
}