using MovieRental.Data;
using MovieRental.Movie;
using MovieRental.Rental;
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
	/// Interaction logic for wpfrental.xaml
	/// </summary>
	public partial class wpfrental : Window
	{
		public wpfrental()
		{
			InitializeComponent();
		}

		private async void BtnSave_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				using var context = new MovieRentalDbContext();

				var rental = new Rental()
				{
					DaysRented = ~int.Parse(txtDaysRentle.Text),
					CustomerId= int.Parse(txtCustomerId.Text),
					MovieId= int.Parse(txtMovieId.Text),
					CustomerName = txtCustomerName.Text
				};

				await context.Rentals.AddAsync(rental);
				await context.SaveChangesAsync();

				lblStatus.Text = "🎉 Rental add with success!";
				txtDaysRentle.Clear();
				txtCustomerId.Clear();
				txtMovieId.Clear();
				txtCustomerName.Clear();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
	}
}
