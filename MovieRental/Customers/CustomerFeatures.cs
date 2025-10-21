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
				//Id Validation case the customer is being created with a specific Id
				if (ValidateCustomer(customer.Id) && customer.Id>0)
					throw new Exception($"The Customer {customer.Id} already exists.");

				_movieRentalDb.Customer.Add(customer);
				_movieRentalDb.SaveChanges();
				return customer;
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		public bool ValidateCustomer(int intCustomerId)
		{
			try
			{
				var customer = _movieRentalDb.Customer.FirstOrDefault(c => c.Id == intCustomerId);
				return customer != null;
			}
			catch (Exception e)
			{
				throw e;
			}
		}
	}
}
