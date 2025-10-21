using MovieRental.Data;
using MovieRental.Movie;
using MovieRental.PaymentMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfMovieRental
{
	/// <summary>
	/// Interaction logic for WpfPaymentMethod.xaml
	/// </summary>
	public partial class WpfPaymentMethod : Window
	{
		public WpfPaymentMethod()
		{
			InitializeComponent();
		}

		private async void BtnSave_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				using var context = new MovieRentalDbContext();
				var paymentMethod = new PaymentMethod
				{
					PaymentMethodName = txtPaymentMethodName.Text
				};

				PaymentMethodFeatures paymentMethodFeatures = new PaymentMethodFeatures(context);

				if (paymentMethodFeatures.ValidatePaymentByName(paymentMethod.PaymentMethodName))
					throw new Exception($"Payment method {paymentMethod.PaymentMethodName} already exists.");

				await context.PaymentMethod.AddAsync(paymentMethod);
				await context.SaveChangesAsync();

				lblStatus.Text = "🎉 Payment Method added successfully!";

				txtPaymentMethodName.Clear();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
	}
}
