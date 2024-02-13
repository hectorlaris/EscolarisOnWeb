using Microsoft.AspNetCore.Mvc;
using CoreBusiness;
using WebApp.ViewModels;
using UseCases;
using UseCases.CategoriesUseCases;
using UseCases.interfaces;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Controllers
{
    [Authorize(Policy = "Register")]
    public class EnrollmentController : Controller
    {
        private readonly IViewCategoriesUseCase viewCategoriesUseCase;
        private readonly IViewSelectedAcadProgramUseCase viewSelectedAcadProgramUseCase;
        private readonly IEnrollProgramUseCase enrollProgramUseCase;
        private readonly IViewAcadProgramInCategoryUseCase viewAcadProgramInCategoryUseCase;
        
        public EnrollmentController(
            IViewCategoriesUseCase viewCategoriesUseCase,
            IViewSelectedAcadProgramUseCase viewSelectedAcadProgramUseCase,
            IEnrollProgramUseCase enrollProgramUseCase,
            IViewAcadProgramInCategoryUseCase viewAcadProgramInCategoryUseCase)
        {
            this.viewCategoriesUseCase = viewCategoriesUseCase;
            this.viewSelectedAcadProgramUseCase = viewSelectedAcadProgramUseCase;
            this.enrollProgramUseCase = enrollProgramUseCase;
            this.viewAcadProgramInCategoryUseCase = viewAcadProgramInCategoryUseCase;
        }

        public IActionResult Index()
        {
            //inicialice category list
            var enrollmentViewModel = new EnrollmentViewModel
            {
                Categories = viewCategoriesUseCase.Execute()
            };

            return View(enrollmentViewModel);
        }

        // Lista de AcadProgram by ID
        public IActionResult EnrollAcadProgramPartial(int acadprogramId)
        {
            var acadprogram = viewSelectedAcadProgramUseCase.Execute(acadprogramId);
            return PartialView("_EnrollAcadProgram", acadprogram);
        }

        public IActionResult Enroll(EnrollmentViewModel enrollmentViewModel)
        {
            if (ModelState.IsValid)
            {
                // enrool into product
                enrollProgramUseCase.Execute(
                    "hectorsl",
                    enrollmentViewModel.SelectedAcadProgramId,
                    enrollmentViewModel.QuantityToEnroll);
            }

            var programa = viewSelectedAcadProgramUseCase.Execute(enrollmentViewModel.SelectedAcadProgramId);

            enrollmentViewModel.SelectedCategoryId = (programa?.CategoryId == null) ? 0 : programa.CategoryId.Value;
            enrollmentViewModel.Categories = viewCategoriesUseCase.Execute();

            return View("Index", enrollmentViewModel);
        }

        // es llamado por una funcion typescript desde el Index Enrollment
        public IActionResult AcadProgramsByCategoryPartial(int categoryId)
        {
            var programas = viewAcadProgramInCategoryUseCase.Execute(categoryId);

            return PartialView("_AcadPrograms", programas);
        }


    }
}
