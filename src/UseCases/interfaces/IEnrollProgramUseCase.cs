using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.interfaces
{
	public interface IEnrollProgramUseCase
	{
		void Execute(string cashierName, int programId, int qtyToSell);
	}
}
