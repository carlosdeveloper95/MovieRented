using Microsoft.EntityFrameworkCore;
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
	/// Interaction logic for wpfListMovies.xaml
	/// </summary>
	public partial class wpfListMovies : Window
	{
		public wpfListMovies()
		{
			try
			{
				InitializeComponent();
				LoadMoviesAsync();
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
				LoadMoviesAsync();

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private async void LoadMoviesAsync()
		{
			try
			{
				using var context = new MovieRentalDbContext();
				List<Movie> movies = await context.Movies.OrderBy(m => m.Title).ToListAsync();
				dgMovies.ItemsSource = movies;

			}
			catch (Exception e)
			{
				throw e;
			}
		}

	}
}
