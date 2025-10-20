using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Mvc;
using MovieRental.Movie;
using MovieRental.Rental;

namespace MovieRental.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class RentalController : ControllerBase
	{

		private readonly IRentalFeatures _features;

		public RentalController(IRentalFeatures features)
		{
			_features = features;
		}

		//A sync method is a method that runs synchronously, blocking the calling thread until it completes.
		//An async method is a method that runs asynchronously, allowing the calling thread to continue executing other code while waiting for the method to complete.
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] Rental.Rental rental)
		{
			try
			{
				var result = await _features.SaveAsync(rental);
				return Ok(result);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message + " " + e.StackTrace);
			}
		}

		[HttpGet("GetRentalByCustomerName")]
		public IActionResult GetRentalByCustomerName([FromQuery] string customerName)
		{
			try
			{
				var result = _features.GetRentalsByCustomerName(customerName);
				return Ok(result);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message + " " + e.StackTrace);
			}

		}
	}
}