using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
	public class RecordTransactionUseCase : IRecordTransactionUseCase
	{
		private readonly ITransactionRepository transactionRepository;
		private readonly IAcadProgramRepository acadProgramRepository;

		public RecordTransactionUseCase(
			ITransactionRepository transactionRepository,
			IAcadProgramRepository acadProgramRepository)
		{
			this.transactionRepository = transactionRepository;
			this.acadProgramRepository = acadProgramRepository;
		}

		public void Execute(string cashierName, int programId, int qty)
		{
			var acadProgram = acadProgramRepository.GetAcadProgramById(programId);

			if (acadProgram != null)
				transactionRepository.Add(
					cashierName,
					programId,
					acadProgram.Name,
					acadProgram.Price.HasValue ? acadProgram.Price.Value : 0,
					acadProgram.Quantity.HasValue ? acadProgram.Quantity.Value : 0, qty);
		}
	}
}
