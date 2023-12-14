using FuniWebApp.Data.Models;

namespace FuniWebApp.Areas.Admin.ViewModels;
public class CartFuniViewModel : AddFuniViewModel
{
	public int Id { get; set; }
	public string ImageUrl { get; set; } = string.Empty;
	public string ProductName { get; set; } = string.Empty;
}
