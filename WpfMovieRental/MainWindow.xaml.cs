
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfMovieRental
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private async void btnMovie_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				wpfmovies form = new wpfmovies();
				form.ShowDialog();
				form = null;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private async void btnCustomer_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				wpfcustomer form = new wpfcustomer();
				form.ShowDialog();
				form = null;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private async void btnRental_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				wpfrental form = new wpfrental();
				form.ShowDialog();
				form = null;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private async void btnListMovies_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				wpfListMovies form = new wpfListMovies();
				form.ShowDialog();
				form = null;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private async void btnListCustomers_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				wpfListCustomers form = new wpfListCustomers();
				form.ShowDialog();
				form = null;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private async void btnListRentals_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				wplListRental form = new wplListRental();
				form.ShowDialog();
				form = null;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
	}
}