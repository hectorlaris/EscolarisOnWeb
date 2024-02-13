using CoreBusiness;

namespace UseCases.interfaces
{
	public interface IViewAcadProgramInCategoryUseCase
	{
		IEnumerable<AcadProgram> Execute(int categoryId);
	}
}
