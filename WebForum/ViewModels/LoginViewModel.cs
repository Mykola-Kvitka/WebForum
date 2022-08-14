using System.ComponentModel.DataAnnotations;

namespace WebForum.PL.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Електронна пошта")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запам'ятати вхід?")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
