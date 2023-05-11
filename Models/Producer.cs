using eCinema.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eCinema.Models
{
    public class Producer : IEntityBase
    {
        [Key]
        public int Id { get; set; }

		[Display(Name = "Full Name")]
		public string FullName { get; set; }

		[Display(Name = "Profile Image")]
		public string ImageUrl { get; set; }

		[Display(Name = "Biography")]
		public string Bio { get; set; }

		[Display(Name = "Birth Date")]
		[Required(ErrorMessage = "Actor Birth-Date is required!")]
		public DateTime BirthDate { get; set; }

		[Display(Name = "Address")]
		[Required(ErrorMessage = "Actor Address is required!")]
		public string Country { get; set; }

		//Relations
		public virtual ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();
    }
}
