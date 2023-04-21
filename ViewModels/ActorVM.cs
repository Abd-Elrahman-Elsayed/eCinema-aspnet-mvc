using eCinema.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace eCinema.ViewModels
{
	public class ActorVM
	{
		public Actor Actor { get; set; }

		[ValidateNever]
		public IFormFile File { get; set; }
	}
}
