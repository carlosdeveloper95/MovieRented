namespace MovieRental.Movie;

public interface IMovieFeatures
{
	Movie Save(Movie movie);
	List<Movie> GetAll();

	bool ValidateMovie(int intMovieId);
}