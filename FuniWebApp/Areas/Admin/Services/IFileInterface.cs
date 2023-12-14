namespace FuniWebApp.Areas.Admin.Services;

public interface IFileInterface
{
    string Save(IFormFile file);
    void Delete(string fileName);
}
