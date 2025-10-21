namespace MovieRental.Rental;

public interface IRentalFeatures
{
	Rental Save(Rental rental);

	Task<string> SaveAsync(Rental rental);
	IEnumerable<Rental> GetRentalsByCustomerName(string customerName);
}