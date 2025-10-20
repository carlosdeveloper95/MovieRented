namespace MovieRental.Rental;

public interface IRentalFeatures
{
	Rental Save(Rental rental);

	Task<Rental> SaveAsync(Rental rental);
	IEnumerable<Rental> GetRentalsByCustomerName(string customerName);
}