namespace MovieRental.PaymentProviders
{
	public interface IPaymentProvider
	{
		public void ProcessPayment(decimal ammount);
	}
}