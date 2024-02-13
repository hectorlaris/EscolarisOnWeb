using Microsoft.AspNetCore.Mvc;
using CoreBusiness;
using WebApp.ViewModels;
using UseCases;
using UseCases.interfaces;
using UseCases.CategoriesUseCases;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Controllers
{
    [Authorize(Policy = "Secretary")]
    public class AcadProgramsController : Controller
    {
        private readonly IAddAcadProgramUseCase addAcadProgramsUseCase;
		private readonly IEditAcadProgramUseCase editAcadProgramUse;
		private readonly IDeleteAcadProgramUseCase deleteAcadProgramUseCase;
		private readonly IViewSelectedAcadProgramUseCase viewSelectedAcadProgramUseCase;
		private readonly IViewAcadProgramsUseCase viewAcadProgramsUseCase;
		private readonly IViewCategoriesUseCase viewCategoriesUseCase;

		//private readonly IViewAcadProgramInCategoryUseCase viewAcadProgramInCategoryUseCase;

		public AcadProgramsController(
			IAddAcadProgramUseCase addAcadProgramsUseCase,
			IEditAcadProgramUseCase editAcadProgramUse,
			IDeleteAcadProgramUseCase deleteAcadProgramUseCase,
			IViewSelectedAcadProgramUseCase viewSelectedAcadProgramUseCase,
			IViewAcadProgramsUseCase viewAcadProgramsUseCase,
			IViewCategoriesUseCase viewCategoriesUseCase)

            //IViewAcadProgramInCategoryUseCase viewAcadProgramInCategoryUseCase)

        {
			this.addAcadProgramsUseCase = addAcadProgramsUseCase;
			this.editAcadProgramUse = editAcadProgramUse;
			this.deleteAcadProgramUseCase = deleteAcadProgramUseCase;
			this.viewSelectedAcadProgramUseCase = viewSelectedAcadProgramUseCase;
			this.viewAcadProgramsUseCase = viewAcadProgramsUseCase;
			this.viewCategoriesUseCase = viewCategoriesUseCase;
			//this.viewAcadProgramInCategoryUseCase = viewAcadProgramInCategoryUseCase;
		}

		public IActionResult Index()
		{
			var acadprograms = viewAcadProgramsUseCase.Execute(loadCategory: true);
			return View(acadprograms);
		}

		// método para Add AcadPrograms
		public IActionResult Add()
		{
			// nuevo argumento para el PartialView: _AcadProgram.csthml
			ViewBag.Action = "add";

			var acadProgramViewModel = new AcadProgramViewModel
			{
				Categories = viewCategoriesUseCase.Execute()
			};

			return View(acadProgramViewModel);
		}

		[HttpPost]
		public IActionResult Add(AcadProgramViewModel acadProgramViewModel)
		{
			if (ModelState.IsValid)
			{
				addAcadProgramsUseCase.Execute(acadProgramViewModel.AcadProgram);
				return RedirectToAction(nameof(Index));
			}

			// nuevo argumento para el PartialView: _AcadProgram.csthml
			ViewBag.Action = "add";

			//poblar las categorias en el dropdown
			acadProgramViewModel.Categories = viewCategoriesUseCase.Execute();
			return View(acadProgramViewModel);
		}

		public IActionResult Edit(int id)
		{

			// nuevo argumento para el PartialView: _AcadProgram.csthml
			ViewBag.Action = "edit";

			// se trabaja con AcadprogramViewModel
			var acadProgramViewModel = new AcadProgramViewModel
			{
				AcadProgram = viewSelectedAcadProgramUseCase.Execute(id)?? new AcadProgram(),
				Categories = viewCategoriesUseCase.Execute()
			};
			return View(acadProgramViewModel);
		}

		// edit action method http version usando AcadProgramViewModel
		[HttpPost]
		public IActionResult Edit(AcadProgramViewModel acadProgramViewModel)
		{
			if (ModelState.IsValid)
			{
				editAcadProgramUse.Execute(acadProgramViewModel.AcadProgram.ProgramId,acadProgramViewModel.AcadProgram);
				return RedirectToAction(nameof(Index));
			}

			// nuevo argumento para el PartialView: _AcadProgram.csthml
			ViewBag.Action = "edit";

			//re-poblar las categorias en el dropdown
			acadProgramViewModel.Categories = viewCategoriesUseCase.Execute();
			return View(acadProgramViewModel);
		}

		public IActionResult Delete(int id)
		{
			deleteAcadProgramUseCase.Execute(id);
			return RedirectToAction(nameof(Index));
		}

		////Lista partial, programas asociados a una categoria
		//public IActionResult AcadProgramsByCategoryPartial(int categoryId)
		//{
		//	var acadprograms = viewAcadProgramInCategoryUseCase.Execute(categoryId);

		//	// return con la partial View _AcadPrograms difrente de _AcadProgram q ya existe
		//	return PartialView("_AcadPrograms", acadprograms);
		//}
	}
}
