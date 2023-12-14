namespace FuniWebApp.Areas.Admin.ViewModels;

public class EditFuniViewModel : AddFuniViewModel
{
    public int Id { get; set; }

    public string ImageUrl { get; set; } = string.Empty;
}