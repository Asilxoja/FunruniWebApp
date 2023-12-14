using FuniWebApp.Areas.Admin.Data.Interfaces;
using FuniWebApp.Data.Interfaces;
using FuniWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using FuniWebApp.Areas.Admin.Services;
using FuniWebApp.Areas.Admin.ViewModels;

namespace FuniWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFuniInterface _funiInterface;
		private readonly IFileInterface _fileInterface;
		private readonly ICategoryInterface _categoryInterface;
        public HomeController(ICategoryInterface categoryInterface,
							IFuniInterface funiInterface,
							IFileInterface fileInterface)
        {
            _categoryInterface = categoryInterface;
			_funiInterface = funiInterface;
			_fileInterface = fileInterface;
		}

        public async Task<IActionResult> Index()
        {
			FuniViewModel viewModel = new FuniViewModel()
			{
				TrendingFuni = await _funiInterface.GetNew3Funis(),	
			};
            return View(viewModel);
        }

        public IActionResult Shop()
        {

            return View();
        }

		[HttpGet]
        public async Task<IActionResult> Cart(int id)
        {
			var model = await _funiInterface.GetByIdAsync(id);
			CartFuniViewModel viewModel = new()
			{
				Id = model.Id,
				ImageUrl = model.ImageUrl,
				ProductName = model.Title,
				Price = model.Price,
				CategoryId = model.CategoryId
			};	
			return View(viewModel);
        }
		public IActionResult About()
		{
			return View();
		}
		public IActionResult Blog()
		{
			return View();
		}

		public IActionResult ChekOut()
		{
			return View();
		}
		public IActionResult Contact()
		{
			return View();
		}
		public IActionResult Services()
		{
			return View();
		}
		public IActionResult ThankYou()
		{
			return View();
		}
		public IActionResult LoginPage()
		{
			return View();
		}
        public IActionResult Register()
        {
            return View();
        }
		public IActionResult forgotPassword()
		{
			return View();
		}
    }
}