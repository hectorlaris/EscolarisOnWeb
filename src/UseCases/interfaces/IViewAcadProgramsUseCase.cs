using CoreBusiness;
using System.Collections.Generic;

namespace UseCases.interfaces
{
	public interface IViewAcadProgramsUseCase
	{
		IEnumerable<AcadProgram> Execute(bool loadCategory = false);
	}
}
