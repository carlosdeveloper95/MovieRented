using MovieRental.Data;

namespace MovieRental.PaymentProviders
{
	public class PaymentProvider
	{
		private readonly MovieRentalDbContext _movieRentalDb;

		public PaymentProvider(MovieRentalDbContext movieRentalDb)
		{
			_movieRentalDb = movieRentalDb;
		}

		public void ProcessaPagamento(string strPaymentMethod, decimal amount, ref string strMessage)
		{
			// Check if the payment method exists in the database
			//Not Case Sensitive
			var paymentMethod = _movieRentalDb.PaymentMethod
				.FirstOrDefault(pm => pm.PaymentMethodName.ToUpper() == strPaymentMethod.ToUpper());

			if (paymentMethod == null)
			{
				throw new Exception("Payment method not found.");
			}

			// Simulate payment processing
			strMessage = $"Processing payment of {amount} using {strPaymentMethod}.";
			// Return true to indicate that the payment was processed successfully
		}
	}
}
