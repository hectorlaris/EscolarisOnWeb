using System.ComponentModel.DataAnnotations;
using CoreBusiness;
using UseCases.interfaces;

namespace WebApp.ViewModels.Validations
{
    public class EnrollmentViewModel_EnsureProperQuantity : ValidationAttribute
    {
        //"protected override" se usa para indicar que se está anulando un miembro heredado y que solo las clases derivadas pueden acceder a él
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var enrollmentViewModel = validationContext.ObjectInstance as EnrollmentViewModel;

            if (enrollmentViewModel != null)
            {
                if (enrollmentViewModel.QuantityToEnroll <= 0)
                {
                    return new ValidationResult("The quota to enroll has to be greater than zero.");
                }
                else
                {
                    var getAcadProgramByIdUseCase = validationContext.GetService(typeof(IViewSelectedAcadProgramUseCase)) as IViewSelectedAcadProgramUseCase;

                    if (getAcadProgramByIdUseCase != null)
                    {
						var programa = getAcadProgramByIdUseCase.Execute(enrollmentViewModel.SelectedAcadProgramId);
						
                        if (programa != null)
						{
							if (programa.Quantity < enrollmentViewModel.QuantityToEnroll)
								return new ValidationResult($"{programa.Name} only has {programa.Quantity} left. It is not enough.");
						}

					}
                    else
                    {
                        return new ValidationResult("The selected Academic program doesn't exist.");
                    }                                    
                }
            }

            return ValidationResult.Success;
        }
    }
}
