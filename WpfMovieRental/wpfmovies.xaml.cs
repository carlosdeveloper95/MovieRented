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
	/// Interaction logic for wpfmovies.xaml
	/// </summary>
	public partial class wpfmovies : Window
	{
		public wpfmovies()
		{
			InitializeComponent();
		}

		private async void BtnSave_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				using var context = new MovieRentalDbContext();

				var movie = new Movie
				{
					Title = txtTitle.Text,
					Producer = txtProducer.Text
				};

				await context.Movies.AddAsync(movie);
				await context.SaveChangesAsync();

				lblStatus.Text = "🎉 movie add with success!";
				txtTitle.Clear();
				txtProducer.Clear();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
	}
}
