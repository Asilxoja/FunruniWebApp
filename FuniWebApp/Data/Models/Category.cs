using System.ComponentModel.DataAnnotations;

namespace FuniWebApp.Data.Models;

public class Category : BaseModel
{
    [Required, StringLength(100)]
    public string Name { get; set; } = string.Empty;

    public List<Funi> Funis = new();
}
