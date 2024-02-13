using CoreBusiness;


namespace UseCases.DataStorePluginInterfaces
{
    public interface IAcadProgramRepository
    {
        void AddAcadProgram(AcadProgram acadprogram);
        void UpdateAcadProgram(int programId, AcadProgram acadProgram);
        void DeleteAcadProgram(int programId);
        AcadProgram? GetAcadProgramById(int programId, bool loadCategory = false);
        IEnumerable<AcadProgram> GetAcadPrograms(bool loadCategory = false);
        IEnumerable<AcadProgram> GetAcadProgramByCategoryId(int categoryId);
    }
}
