using MovieRental.Data;
using MovieRental.Movie;

namespace MovieRental.PaymentMethod
{
	public class PaymentMethodFeatures: IPaymentMethodFeatures
	{
		private readonly MovieRentalDbContext _movieRentalDb;

		public PaymentMethodFeatures(MovieRentalDbContext movieRentalDb)
		{
			_movieRentalDb= movieRentalDb;
		}
		public void SavePayment(PaymentMethod paymentMethod)
		{
			try
			{
				if(ValidatePayment(paymentMethod.Id))
					throw new Exception($"Payment method {paymentMethod.Id} already exists.");

				_movieRentalDb.PaymentMethod.Add(paymentMethod);
				_movieRentalDb.SaveChanges();
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		public bool ValidatePayment(int intPaymentMethodId)
		{
			try
			{
				var paymentMethod = _movieRentalDb.PaymentMethod.FirstOrDefault(p => p.Id == intPaymentMethodId);
				return paymentMethod != null;
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		public bool ValidatePaymentByName(string strName)
		{
			try
			{
				//Case insensitive validation
				var paymentMethod = _movieRentalDb.PaymentMethod.FirstOrDefault(p => p.PaymentMethodName.ToUpper() == strName.ToUpper());
				return paymentMethod != null;
			}
			catch (Exception e)
			{
				throw e;
			}
		}
	}
}
