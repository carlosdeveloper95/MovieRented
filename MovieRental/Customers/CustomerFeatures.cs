using MovieRental.Data;

namespace MovieRental.Customers
{
	public class CustomerFeatures: ICustomerFeature
	{
		private readonly MovieRentalDbContext _movieRentalDb;
		public CustomerFeatures(MovieRentalDbContext movieRentalDb)
		{
			try
			{
				_movieRentalDb = movieRentalDb;
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		/// <summary>
		/// Method to save a customer in the database
		/// </summary>
		/// <param name="customer">Object of customer</param>
		/// <returns>Object of customer saved</returns>
		public Customer Save(Customer customer)
		{
			try
			{
				_movieRentalDb.Customer.Add(customer);
				_movieRentalDb.SaveChanges();
				return customer;
			}
			catch (Exception e)
			{
				throw e;
			}
		}
	}
}
