using CoreBusiness;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.interfaces
{
	public interface IEditAcadProgramUseCase
	{
		void Execute(int pprogramId, AcadProgram acadProgram);
	}
}
