using Microsoft.AspNetCore.Mvc.Rendering;
using MVCTask2.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCTask2.ViewModels
{
    public class UserVM
    {
        [Required(ErrorMessage = "*")]
        [MinLength(3,ErrorMessage ="Name must be at least 3 characters")]
        [MaxLength(30, ErrorMessage = "Name musn't be more than 30 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "*")]
        [Range(18,60, ErrorMessage = "Age must be between 18 and 60")]
        public int Age { get; set; }

        [Required(ErrorMessage = "*")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage ="*")]
        [RegularExpression("^(?=.*[A-Za-z])(?=.*[0-9])[A-Za-z0-9]{8,}$", ErrorMessage = "Password must be Minimum eight characters, at least one letter and one number")]
        public string Password { get; set; }

        [Required(ErrorMessage = "*")]
        [Compare("Password", ErrorMessage ="Confirm Password must match Password")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

    }
}
