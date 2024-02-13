using CoreBusiness;

namespace WebApp.ViewModels
{
    public class AcadProgramViewModel
    {
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
        public AcadProgram AcadProgram { get; set; } = new AcadProgram();
    
    }
}
