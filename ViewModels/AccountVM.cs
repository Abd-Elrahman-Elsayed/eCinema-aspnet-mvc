using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace eCinema.ViewModels
{
    public class AccountVM
    {
        [Required]
        [StringLength(20, MinimumLength = 5)]
        [Remote("CheckExistItem", "Account", ErrorMessage = "Already exists!")]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Remote("CheckExistItem", "Account",ErrorMessage ="Already exists!")]
        public string Email { get; set; }
        [Required]
        [StringLength(20,MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string Cpassword { get; set; }
    }
}
