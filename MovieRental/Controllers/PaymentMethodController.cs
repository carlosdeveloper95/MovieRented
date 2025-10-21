using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieRental.Movie;
using MovieRental.PaymentMethod;

namespace MovieRental.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PaymentMethodController : ControllerBase
	{
		private readonly IPaymentMethodFeatures _features;

		public PaymentMethodController(IPaymentMethodFeatures features)
		{
			_features = features;
		}

		[HttpPost("SavePaymentMethod")]
		public IActionResult SavePaymentMethod([FromQuery] PaymentMethod.PaymentMethod payment)
		{
			try
			{
				_features.SavePayment(payment);
				return Ok($"Payment method '{payment.PaymentMethodName}' saved successfully.");
			}
			catch (Exception e)
			{
				return BadRequest(e.Message + " " + e.StackTrace);
			}
		}
	}
}
