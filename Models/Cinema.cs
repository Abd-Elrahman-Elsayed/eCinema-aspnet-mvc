using eCinema.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eCinema.Models
{
    public class Cinema:IEntityBase
    {
        [Key]
        public int Id { get; set; }

		[Display(Name = "Full Name")]
		public string Name { get; set; }

		[Display(Name = "Logo")]
		public string Logo { get; set; }

		[Display(Name = "Discription")]
		public string Description { get; set; }

        //Relations
        public virtual ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();

    }
}
