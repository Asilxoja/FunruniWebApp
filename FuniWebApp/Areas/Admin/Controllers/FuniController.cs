using FuniWebApp.Areas.Admin.Data.Interfaces;
using FuniWebApp.Areas.Admin.Services;
using FuniWebApp.Areas.Admin.ViewModels;
using FuniWebApp.Data.Interfaces;
using FuniWebApp.Data.Models;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace FuniWebApp.Areas.Admin.Controllers;

[Area("admin")]
public class FuniController : Controller
{
	private readonly IFuniInterface _funi;
	private readonly ICategoryInterface _categories;

	private readonly IFileInterface _fileInterface;
	private readonly IToastNotification _toastNotification;

	public FuniController(IFuniInterface books,
						  ICategoryInterface categories,
						  IFileInterface fileInterface,
						  IToastNotification toastNotification)
	{
		_funi = books;
		_categories = categories;
		_fileInterface = fileInterface;
		_toastNotification = toastNotification;
	}


	public async Task<IActionResult> Index()
	{
		var list = await _funi.GetAllAsync();
		return View(list);
	}
	public async Task<IActionResult> View(int id)
	{
		var book = await _funi.GetByIdWithCategoryAsync(id);
		return View(book);
	}

	[HttpGet]
	public async Task<IActionResult> Add()
	{
		var list = await _categories.GetAllAsync();
		AddFuniViewModel viewModel = new()
		{
			Categories = list,
		};
		return View(viewModel);
	}

	[HttpPost]
	public async Task<IActionResult> Add(AddFuniViewModel viewModel)
	{
		if (ModelState.IsValid)
		{
			string imageURL = _fileInterface.Save(viewModel.FileName);
			Funi newFuni = new()
			{
				Title = viewModel.Title,
				Price = viewModel.Price,
				Description = viewModel.Description,
				ExpirationDate = viewModel.ExpirationDate,
				PublishedYear = viewModel.PublishedYear,
				CategoryId = viewModel.CategoryId,
				ImageUrl = imageURL,
				Category = null
			};
			await _funi.AddAsync(newFuni);

			return RedirectToAction("Index");
		}
		var list = await _categories.GetAllAsync();
		viewModel.Categories = list;
		return View(viewModel);
	}
	public async Task<IActionResult> Delete(int id)
	{
		var book = await _funi.GetByIdAsync(id);
		if (book.Id == 0)
		{
			_toastNotification.AddErrorToastMessage("Book not found");
			return RedirectToAction("Index");
		}
		string img = book.ImageUrl;
		await _funi.DeleteAsync(id);
		_fileInterface.Delete(img);
		_toastNotification.AddSuccessToastMessage("Seccesfully deleted ");
		return RedirectToAction("Index");
	}
	[HttpGet]
	public async Task<IActionResult> Edit(int id)
	{
		var book = await _funi.GetByIdAsync(id);
		if (book.Id == 0)
		{
			_toastNotification.AddErrorToastMessage("Book not found");
			return RedirectToAction("Index");
		}
		var categories = await _categories.GetAllAsync();
		EditFuniViewModel viewModel = new()
		{
			Id = book.Id,
			Categories = categories,
			Title = book.Title,
			Price = book.Price,
			Description = book.Description,
			ExpirationDate = book.ExtrationDate,
			CategoryId = book.CategoryId,
			ImageUrl = book.ImageUrl,
			PublishedYear = book.PublishedYear,
		};
		return View(viewModel);
	}

	[HttpPost]
	public async Task<IActionResult> Edit(EditFuniViewModel viewModel)
	{
		if (ModelState.IsValid)
		{
			string image = viewModel.ImageUrl;
			if (viewModel.FileName != null)
			{
				_fileInterface.Delete(image);
				image = _fileInterface.Save(viewModel.FileName);
				Funi book = new()
				{
					Id = viewModel.Id,
					Title = viewModel.Title,
					Price = viewModel.Price,
					Description = viewModel.Description,
					ExpirationDate = viewModel.ExpirationDate,
					PublishedYear = viewModel.PublishedYear,
					CategoryId = viewModel.CategoryId,
					ImageUrl = image,
					Category = null
				};
				await _funi.UpdateAsync(book);
				_toastNotification.AddSuccessToastMessage("Seccessfully update");
				return RedirectToAction("index");
			}
		}
		viewModel.Categories = await _categories.GetAllAsync();
		_toastNotification.AddErrorToastMessage("Fill out all required fields!");
		return View(viewModel);
	}

    public IActionResult LoginAuth()
    {
        return View();
    }
}