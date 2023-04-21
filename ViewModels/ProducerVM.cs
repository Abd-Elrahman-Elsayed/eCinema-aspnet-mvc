using eCinema.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace eCinema.ViewModels
{
	public class ProducerVM
	{
		public Producer Producer { get; set; }

		[ValidateNever]
		public IFormFile File { get; set; }
	}
}
