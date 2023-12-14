using FuniWebApp.Data.Models;

namespace FuniWebApp.Areas.Admin.Data.Interfaces;

public interface IFuniInterface
{
    Task<List<Funi>> GetAllAsync();
    Task<Funi> GetByIdAsync(int id);
    Task<Funi> GetByIdWithCategoryAsync(int id);

	Task AddAsync(Funi funi);
    Task UpdateAsync(Funi funi);
    Task DeleteAsync(int id);
    Task<List<Funi>> GetNew3Funis();
}
