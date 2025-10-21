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
	/// Interaction logic for wpflistpayment.xaml
	/// </summary>
	public partial class wpflistpayment : Window
	{
		public wpflistpayment()
		{
			try
			{
				InitializeComponent();
				LoadItems();
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public async void BtnReload_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				LoadItems();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public void LoadItems()
		{
			var context = new MovieRental.Data.MovieRentalDbContext();

			var paymentMethods = context.PaymentMethod.ToList();

			dgPaymentMethods.ItemsSource = paymentMethods;
		}
	}
}
