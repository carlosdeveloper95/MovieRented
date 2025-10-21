using Microsoft.EntityFrameworkCore;
using MovieRental.Customers;
using MovieRental.Data;
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
	/// Interaction logic for wplListRental.xaml
	/// </summary>
	public partial class wplListRental : Window
	{
		public wplListRental()
		{
			try
			{
				InitializeComponent();
				LoadRentalAsync();
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private async void BtnReload_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				LoadRentalAsync();

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}


		private async void LoadRentalAsync()
		{
			try
			{
				using var context = new MovieRentalDbContext();
				List<Rental> rentals= await context.Rentals.OrderBy(r=> r.CustomerName).ToListAsync();
				dgRentals.ItemsSource = rentals;

			}
			catch (Exception e)
			{
				throw e;
			}
		}
	}
}
