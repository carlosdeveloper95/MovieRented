using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MovieRental.Customers;
using MovieRental.Data;
using MovieRental.Movie;
using MovieRental.PaymentProviders;

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

		public async Task<string> SaveAsync(Rental rental)
		{
			CustomerFeatures customer = new CustomerFeatures(_movieRentalDb);
			PaymentProvider payment = new PaymentProvider(_movieRentalDb);
			MovieFeatures movie = new MovieFeatures(_movieRentalDb);
			try
			{
				string strMessage = string.Empty;

				if (ValidateRental(rental.Id))
					throw new Exception($"The Rental {rental.Id} already exists.");

				if (!customer.ValidateCustomer(rental.CustomerId))
					throw new Exception(
						$"The customer {rental.CustomerId} doesn't exist. The Customer must be create in first.");

				if(!movie.ValidateMovie(rental.MovieId))
					throw new Exception(
						$"The movie {rental.MovieId} doesn't exist. The Movie must be create in first.");

				payment.ProcessaPagamento(rental.PaymentMethod, rental.Ammount, ref strMessage);
				
				_movieRentalDb.Rentals.Add(rental);
				_movieRentalDb.SaveChanges();

				strMessage += $"\nPayment Process confirmate!";
				return strMessage;
			}
			catch (Exception e)
			{
				throw e;
			}
			finally
			{
				customer = null;
				payment = null;
				movie = null;
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
		public bool ValidateRental(int intRentalId)
		{
			try
			{
				var rental = _movieRentalDb.Rentals.FirstOrDefault(r => r.Id == intRentalId);
				return (rental != null);
			}
			catch (Exception e)
			{
				throw e;
			}
		}

	}
}
