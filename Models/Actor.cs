using eCinema.Data.Base;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace eCinema.Models
{
    public class Actor:IEntityBase
    {
        [Key]
        public int Id { get; set; }

		[Display(Name = "Full Name")]
        [Required(ErrorMessage ="Actor FullName is required!")]
		public string FullName { get; set; }

        [Display(Name = "Profile Image")]
        [ValidateNever]
        public string ImageUrl { get; set; }

		[Display(Name = "Biography")]
		[Required(ErrorMessage = "Actor Biography is required!")]
		public string Bio { get; set; }

		[Display(Name = "Birth Date")]
		[Required(ErrorMessage = "Actor Birth-Date is required!")]
		public DateTime BirthDate { get; set; }

		[Display(Name = "Address")]
		[Required(ErrorMessage = "Actor Address is required!")]
		public string Country { get; set; }

		//Relations
		public virtual ICollection<Actor_Movie> Actor_Movies { get; set; } = new HashSet<Actor_Movie>();
    }
}
