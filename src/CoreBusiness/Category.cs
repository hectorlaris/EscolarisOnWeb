using System.ComponentModel.DataAnnotations;

namespace CoreBusiness
{
	public class Category
	{
		public int CategoryId { get; set; }

		[Required]
		public string Name { get; set; } = string.Empty;
		
		// para especificar q description es optional se agrega: ?
		public string? Description { get; set; } = string.Empty;

        // navigation property for ef core
        public List<AcadProgram>? AcadPrograms { get; set; }

    }
}
