using System.ComponentModel.DataAnnotations;

namespace iLend.ViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "ID/Passport Number")]
        public string IdNumber { get; set; }
    }
}