using Microsoft.AspNetCore.Mvc;
using CoreBusiness;
using UseCases.CategoriesUseCases;
using UseCases.interfaces;
using Microsoft.AspNetCore.Authorization;


namespace WebApp.Controllers
{
    [Authorize(Policy = "Secretary")]
    public class CategoriesController : Controller
	{
		private readonly IViewCategoriesUseCase viewCategoriesUseCase;
		private readonly IEditCategoryUseCase editCategoryUseCase;
		private readonly IDeleteCategoryUseCase deleteCategoryUseCase;
		private readonly IAddCategoryUseCase addCategoryUseCase;
		private readonly IViewSelectedCategoryUseCase viewSelectedCategoryUseCase;

		//// constructors
		//// registers of the use cases
		public CategoriesController(

			IViewCategoriesUseCase viewCategoriesUseCase,
			IEditCategoryUseCase editCategoryUseCase,
			IAddCategoryUseCase addCategoryUseCase,
			IDeleteCategoryUseCase deleteCategoryUseCase,
			IViewSelectedCategoryUseCase viewSelectedCategoryUseCase)

		{
			this.viewCategoriesUseCase = viewCategoriesUseCase;
			this.editCategoryUseCase = editCategoryUseCase;
			this.addCategoryUseCase = addCategoryUseCase;
			this.deleteCategoryUseCase = deleteCategoryUseCase;
			this.viewSelectedCategoryUseCase = viewSelectedCategoryUseCase;
		}

		public IActionResult Index()
		{
			var categories = viewCategoriesUseCase.Execute();
			return View(categories);
		}

		public IActionResult Edit(int? id)
		{
			ViewBag.Action = "edit";

			var category = viewSelectedCategoryUseCase.Execute(id.HasValue ? id.Value : 0);

			return View(category);
		}

		[HttpPost]
		public IActionResult Edit(Category category)
		{
			if (ModelState.IsValid)
			{
				editCategoryUseCase.Execute(category.CategoryId, category);
				return RedirectToAction(nameof(Index));
			}

			ViewBag.Action = "edit";
			return View(category);
		}

		public IActionResult Add()
		{
			ViewBag.Action = "add";

			return View();
		}

		[HttpPost]
		public IActionResult Add(Category category)
		{
			if (ModelState.IsValid)
			{
				addCategoryUseCase.Execute(category);
				return RedirectToAction(nameof(Index));
			}

			ViewBag.Action = "add";
			return View(category);
		}

		public IActionResult Delete(int categoryId)
		{
			deleteCategoryUseCase.Execute(categoryId);
			return RedirectToAction(nameof(Index));
		}

	}

}

