using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TicketingSystem.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email", ResourceType = typeof(App_GlobalResources.globalUI))]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code", ResourceType = typeof(App_GlobalResources.globalUI))]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "RememberThisBrowser", ResourceType = typeof(App_GlobalResources.globalUI))]
        public bool RememberBrowser { get; set; }

        [Display(Name = "RememberMe", ResourceType = typeof(App_GlobalResources.globalUI))]
        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email", ResourceType = typeof(App_GlobalResources.globalUI))]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email", ResourceType = typeof(App_GlobalResources.globalUI))]
        //[EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(App_GlobalResources.globalUI))]
        public string Password { get; set; }

        [Display(Name = "RememberMe", ResourceType = typeof(App_GlobalResources.globalUI))]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email", ResourceType = typeof(App_GlobalResources.globalUI))]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(App_GlobalResources.globalUI))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(App_GlobalResources.globalUI))]
        [Compare("Password", ErrorMessageResourceName = "PasswordAndConfirmationPasswordDoNotMatch", ErrorMessageResourceType = typeof(App_GlobalResources.globalUI))]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email", ResourceType = typeof(App_GlobalResources.globalUI))]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessageResourceName = "StringMinimumLength", ErrorMessageResourceType = typeof(App_GlobalResources.globalUI), MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(App_GlobalResources.globalUI))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(App_GlobalResources.globalUI))]
        [Compare("Password", ErrorMessageResourceName = "PasswordAndConfirmationPasswordDoNotMatch", ErrorMessageResourceType = typeof(App_GlobalResources.globalUI))]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Code", ResourceType = typeof(App_GlobalResources.globalUI))]
        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email", ResourceType = typeof(App_GlobalResources.globalUI))]
        public string Email { get; set; }
    }
}
