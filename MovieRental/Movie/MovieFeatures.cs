using MovieRental.Data;

namespace MovieRental.Movie
{
	public class MovieFeatures : IMovieFeatures
	{
		private readonly MovieRentalDbContext _movieRentalDb;
		public MovieFeatures(MovieRentalDbContext movieRentalDb)
		{
			try
			{
				_movieRentalDb = movieRentalDb;
			}
			catch (Exception e)
			{
				throw e;
			}
		}
		
		public Movie Save(Movie movie)
		{
			try
			{
				//Id Validation case the movie is being created with a specific Id
				if (ValidateMovie(movie.Id) && movie.Id > 0)
					throw new Exception($"The Movie {movie.Id} already exists.");

				_movieRentalDb.Movies.Add(movie);
				_movieRentalDb.SaveChanges();
				return movie;
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		// TODO: tell us what is wrong in this method? Forget about the async, what other concerns do you have?
		// Anwer: The table can be milions of rows what the inflence the performance of Method and of program, also don't have try catch that difficult the error handling; the name of method is ambigous, the name of method should be claire
		public List<Movie> GetAll()
		{
			return _movieRentalDb.Movies.ToList();
		}

		public bool ValidateMovie(int intMovieId)
		{
			try
			{
				var movie = _movieRentalDb.Movies.FirstOrDefault(m => m.Id == intMovieId);
				return movie != null;
			}
			catch (Exception e)
			{
				throw e;
			}
		}


	}
}
