using eCinema.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace eCinema.ViewModels
{
	public class CinemaVM
	{
		public Cinema Cinema { get; set; }

		[ValidateNever]
		public IFormFile File { get; set; }
	}
}
