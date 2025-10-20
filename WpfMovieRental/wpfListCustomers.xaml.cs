using Microsoft.EntityFrameworkCore;
using MovieRental.Customers;
using MovieRental.Data;
using MovieRental.Movie;
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
	/// Interaction logic for wpfListCustomers.xaml
	/// </summary>
	public partial class wpfListCustomers : Window
	{
		public wpfListCustomers()
		{
			try
			{
				InitializeComponent();
				LoadCustomerAsync();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private async void BtnReload_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				LoadCustomerAsync();

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}


		private async void LoadCustomerAsync()
		{
			try
			{
				using var context = new MovieRentalDbContext();
				List<Customer> customers = await context.Customer.OrderBy(c => c.Name).ToListAsync();
				dgCustomer.ItemsSource = customers;

			}
			catch (Exception e)
			{
				throw e;
			}
		}
	}
}
