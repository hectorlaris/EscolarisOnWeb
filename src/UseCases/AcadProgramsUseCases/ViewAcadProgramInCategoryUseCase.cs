using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.interfaces;

namespace UseCases.AcadProgramsUseCases
{

	public class ViewAcadProgramInCategoryUseCase : IViewAcadProgramInCategoryUseCase
	{   		
		private readonly IAcadProgramRepository acadProgramRepository;

		public ViewAcadProgramInCategoryUseCase(IAcadProgramRepository acadProgramRepository)
		{
			this.acadProgramRepository = acadProgramRepository;
		}

		public IEnumerable<AcadProgram> Execute(int categoryId)
		{
			return acadProgramRepository.GetAcadProgramByCategoryId(categoryId);
		}


	}
}
