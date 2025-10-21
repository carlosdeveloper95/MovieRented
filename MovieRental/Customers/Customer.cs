
using System.ComponentModel.DataAnnotations;

namespace MovieRental.Customers
{
	public class Customer
	{
		[Key]
		public int Id { get; set; }

		public string Name { get; set; }

		public string TaxNumber { get; set; }

		public string CellNumber { get; set; }
	}
}
