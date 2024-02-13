using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.interfaces;

namespace UseCases.AcadProgramsUseCases
{
	public class AddAcadProgramUseCase : IAddAcadProgramUseCase
	{
		private readonly IAcadProgramRepository acadProgramRepository;

		public AddAcadProgramUseCase(IAcadProgramRepository acadProgramRepository)
		{
			this.acadProgramRepository = acadProgramRepository;
		}

		public void Execute(AcadProgram acadProgramam)
		{
			acadProgramRepository.AddAcadProgram(acadProgramam);
		}
	}
}
