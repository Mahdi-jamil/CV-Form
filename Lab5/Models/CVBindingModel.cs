
using System.ComponentModel.DataAnnotations;

namespace Lab5.Models
{
	public class CVBindingModel 
    {
    
        [Required]
        [Display(Name = "FName: ")]
        [StringLength(20, ErrorMessage = "Max Length for name is {1}")]
        public string FName { get; set; }

        [Required]
        [Display(Name = "LName: ")]
        [StringLength(20, ErrorMessage = "Max Length for name is {1}")]
        public string LName { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Please enter a valid date.")]
        [Display(Name = "BDay: ")]
        public DateTime BDay { get; set; }


        [Required(ErrorMessage = "Nationality is required.")]
        [Display(Name = "Nationality: ")]
        public string Nationality { get; set; }

        [Required(ErrorMessage = "Sex is required.")]
        [Display(Name = "Sex: ")]
        public string Sex { get; set; }

        [Display(Name = "Skills: ")]
        public List<string> Skills { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [Display(Name = "Email: ")]
        public string Email { get; set; }

        [Compare("Email", ErrorMessage = "The email and confirmation email do not match.")]
        [Display(Name = "Confirm Email: ")]
        public string EmailConfirm { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password: ")]
        public string Password { get; set; }
        [Required]
        public int num1 { get; set; }
        [Required]
        public int num2 { get; set; }
        [Required]
        public int sum { get; set; }

        [Display(Name = "Photo: ")]
        [Required(ErrorMessage = "upload Photo from server")]
        public IFormFile Photo { get; set; }
    }
}
