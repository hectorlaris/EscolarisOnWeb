using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.interfaces;

namespace UseCases.AcadProgramsUseCases
{
	public class DeleteAcadProgramUseCase : IDeleteAcadProgramUseCase
	{
		private readonly IAcadProgramRepository acadProgramRepository;

		public DeleteAcadProgramUseCase(IAcadProgramRepository acadProgramRepository)
		{
			this.acadProgramRepository = acadProgramRepository;
		}

		public void Execute(int programId)
		{
			acadProgramRepository.DeleteAcadProgram(programId);
		}
	}
}
