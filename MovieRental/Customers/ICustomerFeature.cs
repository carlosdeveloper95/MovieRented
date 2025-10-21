namespace MovieRental.Customers
{
	public interface ICustomerFeature
	{
		Customer Save(Customer customer);

		bool ValidateCustomer(int intCustomerId);

	}
}
