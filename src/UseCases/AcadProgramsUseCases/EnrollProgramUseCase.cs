using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.interfaces;

namespace UseCases.AcadProgramsUseCases
{
	public class EnrollProgramUseCase : IEnrollProgramUseCase
	{
		private readonly IAcadProgramRepository acadProgramRepository;
		private readonly IRecordTransactionUseCase recordTransactionUseCase;

		public EnrollProgramUseCase(
			 IAcadProgramRepository acadProgramRepository,
			 IRecordTransactionUseCase recordTransactionUseCase)
		{
			this.acadProgramRepository = acadProgramRepository;
			this.recordTransactionUseCase = recordTransactionUseCase;
		}

		public void Execute(string cashierName, int programId, int qtyToSell)
		{
			var acadProgram = acadProgramRepository.GetAcadProgramById(programId);

			if (acadProgram == null) return;

			recordTransactionUseCase.Execute(cashierName, programId, qtyToSell);
			acadProgram.Quantity -= qtyToSell;
			acadProgramRepository.UpdateAcadProgram(programId, acadProgram);
		}

	}
}
