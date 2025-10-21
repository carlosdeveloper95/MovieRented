namespace MovieRental.PaymentMethod
{
	public interface IPaymentMethodFeatures
	{
		public void SavePayment(PaymentMethod paymentMethod);

		bool ValidatePayment(int intPaymentMethodId);
	}
}
