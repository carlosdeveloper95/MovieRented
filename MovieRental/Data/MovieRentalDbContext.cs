using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;
using MovieRental.Customers;

namespace MovieRental.Data
{
	public class MovieRentalDbContext : DbContext
	{
		public DbSet<Movie.Movie> Movies { get; set; }
		public DbSet<Rental.Rental> Rentals { get; set; }

		public DbSet<Customers.Customer> Customer { get; set; }

		public DbSet<PaymentMethod.PaymentMethod> PaymentMethod { get; set; }

		private string DbPath { get; }

		/// <summary>
		/// Method to setup the database context
		/// </summary>
		public MovieRentalDbContext()
		{
			try
			{
				var folder = Environment.SpecialFolder.LocalApplicationData;
				var path = Environment.GetFolderPath(folder);
				DbPath = System.IO.Path.Join(path, "movierental.db");
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		/// <summary>
		/// Every time the context is created this method is called to configure the database (and other options)
		/// </summary>
		/// <param name="options">Options of Database on configuration</param>
		protected override void OnConfiguring(DbContextOptionsBuilder options)
			=> options.UseSqlite($"Data Source={DbPath}");
	}
}
