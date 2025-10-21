using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieRental.Customers;
using MovieRental.Movie;

namespace MovieRental.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomerController : ControllerBase
	{
		ICustomerFeature _features;

		public CustomerController(ICustomerFeature features)
		{
			_features = features;
		}

		[HttpPost("SaveCustomer")]
		public IActionResult SaveCustomer([FromBody] Customer customer)
		{
			try
			{
				return Ok(_features.Save(customer));
			}
			catch (Exception e)
			{
				return BadRequest(e.Message + " " + e.StackTrace);
			}
		}
	}
}
