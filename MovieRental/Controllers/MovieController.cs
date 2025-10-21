using Microsoft.AspNetCore.Mvc;
using MovieRental.Movie;

namespace MovieRental.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {

        private readonly IMovieFeatures _features;

        public MovieController(IMovieFeatures features)
        {
	        _features = features;
        }

        [HttpGet] 
        public IActionResult GetAllMovies()
        {
	        try
			{
				return Ok(_features.GetAll());
			}
	        catch (Exception e)
	        {
		        return BadRequest(e.Message + " " + e.StackTrace);
			}
        }

        [HttpPost]
        public IActionResult Post([FromBody] Movie.Movie movie)
        {
	        try
	        {
		        return Ok(_features.Save(movie));
			}
	        catch (Exception e)
	        {

				return BadRequest(e.Message + " " + e.StackTrace);
			}
        }
    }
}
