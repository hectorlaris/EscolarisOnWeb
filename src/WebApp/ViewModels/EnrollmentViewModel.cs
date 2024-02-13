using System.ComponentModel.DataAnnotations;
using CoreBusiness;
using WebApp.ViewModels.Validations;


namespace WebApp.ViewModels
{
    public class EnrollmentViewModel
    {
        public int SelectedCategoryId { get; set; }
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();

        public int SelectedAcadProgramId { get; set; }

        [Display(Name = "Quantity")]
        [Range(1, int.MaxValue)]
        [EnrollmentViewModel_EnsureProperQuantity]
        public int QuantityToEnroll { get; set; }
    }
}
