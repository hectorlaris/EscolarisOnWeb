using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.interfaces;

namespace UseCases.AcadProgramsUseCases
{
	public class EditAcadProgramUseCase : IEditAcadProgramUseCase
	{
		private readonly IAcadProgramRepository acadProgramRepository;

		public EditAcadProgramUseCase(IAcadProgramRepository acadProgramRepository)
		{
			this.acadProgramRepository = acadProgramRepository;
		}
		public void Execute(int programId, AcadProgram acadProgram)
		{
			acadProgramRepository.UpdateAcadProgram(programId, acadProgram);
		}

	}
}
