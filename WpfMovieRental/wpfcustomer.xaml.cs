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
	/// Interaction logic for wpfcustomer.xaml
	/// </summary>
	public partial class wpfcustomer : Window
	{
		public wpfcustomer()
		{
			InitializeComponent();
		}

		private async void BtnSave_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				using var context = new MovieRentalDbContext();

				var customer = new Customer()
				{
					Name = txtNome.Text,
					TaxNumber = txtTaxNumber.Text,
					CellNumber= txtCellPhone.Text
				};

				await context.Customer.AddAsync(customer);
				await context.SaveChangesAsync();

				lblStatus.Text = "🎉 Customer add with success!";
				txtNome.Clear();
				txtTaxNumber.Clear();
				txtCellPhone.Clear();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
	}
}
