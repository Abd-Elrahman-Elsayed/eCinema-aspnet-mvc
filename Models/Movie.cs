using eCinema.Data.Base;
using eCinema.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCinema.Models
{
    public class Movie : IEntityBase
    {
        [Key]
        public int Id { get; set; }

		[Display(Name = "Name")]
		public string Name { get; set; }

		[Display(Name = "Description")]
		public string Description { get; set; }

		[Display(Name = "Price")]
		public double Price { get; set; }

		[Display(Name = "Cover")]
		public string ImageUrl { get; set; }

		[Display(Name = "Start Date")]
		public DateTime StartDate { get; set; }

		[Display(Name = "End Date")]
		public DateTime EndtDate { get; set; }

		[Display(Name = "Category")]
		public MovieCategory MovieCategory { get; set; }

        //Relations
        public virtual ICollection<Actor_Movie> Actor_Movies { get; set; } = new HashSet<Actor_Movie>();

        [ForeignKey("Cinema")]
        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; }

        [ForeignKey("Producer")]
        public int ProducerId { get; set; }
        public Producer Producer { get; set; }
    }
}
