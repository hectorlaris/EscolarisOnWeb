using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.interfaces;

namespace UseCases.AcadProgramsUseCases
{
	public class ViewAcadProgramsUseCase : IViewAcadProgramsUseCase
	{
		private readonly IAcadProgramRepository acadProgramRepository;

		public ViewAcadProgramsUseCase(IAcadProgramRepository acadProgramRepository)
		{
			this.acadProgramRepository = acadProgramRepository;
		}

		public IEnumerable<AcadProgram> Execute(bool loadCategory = false)
		{
			return acadProgramRepository.GetAcadPrograms(loadCategory);
		}
	}
}
