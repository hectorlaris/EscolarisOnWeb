using CoreBusiness;

namespace UseCases.interfaces
{
    public interface IViewSelectedAcadProgramUseCase
    {
        AcadProgram? Execute(int programId);
    }
}