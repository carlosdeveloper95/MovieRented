using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MovieRental.Data;

namespace MovieRental.Rental
{
	public class RentalFeatures : IRentalFeatures
	{
		private readonly MovieRentalDbContext _movieRentalDb;
		public RentalFeatures(MovieRentalDbContext movieRentalDb)
		{
			_movieRentalDb = movieRentalDb;
		}

		//TODO: make me async :(
		public Rental Save(Rental rental)
		{
			try
			{
				_movieRentalDb.Rentals.Add(rental);
				_movieRentalDb.SaveChanges();
				return rental;
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		public async Task<Rental> SaveAsync(Rental rental)
		{
			try
			{
				_movieRentalDb.Rentals.Add(rental);
				_movieRentalDb.SaveChanges();
				return rental;
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		//TODO: finish this method and create an endpoint for it
		public IEnumerable<Rental> GetRentalsByCustomerName(string customerName)
		{
			try
			{
				IEnumerable<Rental> rental = _movieRentalDb.Rentals.Where(r => r.CustomerName == customerName);
				return rental;
			}
			catch (Exception e)
			{
				throw e;
			}
		}

	}
}
