using System.ComponentModel.DataAnnotations;

namespace CoreBusiness
{
	public class AcadProgram
	{
        [Key]
        public int ProgramId { get; set; }

		[Required]
		[Display(Name = "Category")]
		public int? CategoryId { get; set; }

		[Required]
		public string Name { get; set; } = string.Empty;

		[Required]
		public int? Quantity { get; set; }

		[Required]
		[Range(0, int.MaxValue)]
		public double? Price { get; set; }

		// ? puede ser null, no deberia, por ahora
		public Category? Category { get; set; }

	}
}
