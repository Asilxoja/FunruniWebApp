using FuniWebApp.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace FuniWebApp.Areas.Admin.ViewModels;

public class AddFuniViewModel 
{

    [Required, StringLength(100)]

    public string Title { get; set; } = string.Empty;

    [StringLength(200)]

    public string Description { get; set; } = string.Empty;

    [Required]
    public decimal Price { get; set; }

    [Required]
    public string PublishedYear { get; set; } = string.Empty;
    [Required]
    public string ExpirationDate { get; set; } = string.Empty;

    public IFormFile? FileName { get; set; }

    [Required]
    public int CategoryId { get; set; }

    public List<Category> Categories = new();

}
