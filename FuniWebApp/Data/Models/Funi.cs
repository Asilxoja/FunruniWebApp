using System.ComponentModel.DataAnnotations;

namespace FuniWebApp.Data.Models;

public class Funi : BaseModel
{
    [Required, StringLength(100)]

    public string Title { get; set; } = string.Empty;

    [StringLength(200)]

    public string Description { get; set; } = string.Empty;

    [Required]
    public decimal Price { get; set; }
    [Required]
    public string ExpirationDate { get; set; } = string.Empty;
    [Required]
    public string PublishedYear { get; set; } = string.Empty;

    public string ImageUrl { get; set; } = string.Empty;
    [Required]
    public int CategoryId { get; set; }
    public string ExtrationDate { get; set; } = string.Empty;

	public Category Category = new Category();
}
