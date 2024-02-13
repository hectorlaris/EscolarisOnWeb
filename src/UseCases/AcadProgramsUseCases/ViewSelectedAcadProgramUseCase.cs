using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.interfaces;

namespace UseCases.AcadProgramsUseCases
{
    public class ViewSelectedAcadProgramUseCase : IViewSelectedAcadProgramUseCase
	{

		private readonly IAcadProgramRepository acadProgramRepository;

		public ViewSelectedAcadProgramUseCase(IAcadProgramRepository acadProgramRepository)
		{
			this.acadProgramRepository = acadProgramRepository;
		}

		public AcadProgram? Execute(int programId)
		{
			return acadProgramRepository.GetAcadProgramById(programId);
		}
	}
}
