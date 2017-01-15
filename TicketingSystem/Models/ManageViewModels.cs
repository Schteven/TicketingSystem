using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace TicketingSystem.Models
{
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }
    }

    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }

    public class FactorViewModel
    {
        public string Purpose { get; set; }
    }

    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessageResourceName = "StringMinimumLength", ErrorMessageResourceType = typeof(App_GlobalResources.globalUI), MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "NewPassword", ResourceType = typeof(App_GlobalResources.globalUI))]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmNewPassword", ResourceType = typeof(App_GlobalResources.globalUI))]
        [Compare("NewPassword", ErrorMessageResourceName = "NewPasswordAndConfirmationPasswordDoNotMatch", ErrorMessageResourceType = typeof(App_GlobalResources.globalUI))]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "CurrentPassword", ResourceType = typeof(App_GlobalResources.globalUI))]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessageResourceName = "StringMinimumLength", ErrorMessageResourceType = typeof(App_GlobalResources.globalUI), MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "NewPassword", ResourceType = typeof(App_GlobalResources.globalUI))]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password", ResourceType = typeof(App_GlobalResources.globalUI))]
        [Compare("NewPassword", ErrorMessageResourceName = "NewPasswordAndConfirmationPasswordDoNotMatch", ErrorMessageResourceType = typeof(App_GlobalResources.globalUI))]
        public string ConfirmPassword { get; set; }
    }

    public class EditProfileViewModel
    {
        [Display(Name = "Firstname", ResourceType = typeof(App_GlobalResources.globalUI))]
        public string Firstname { get; set; }

        [Display(Name = "Lastname", ResourceType = typeof(App_GlobalResources.globalUI))]
        public string Lastname { get; set; }

        [Phone]
        [Display(Name = "PhoneNumber", ResourceType = typeof(App_GlobalResources.globalUI))]
        public string PhoneNumber { get; set; }

        [Phone]
        [Display(Name = "CellNumber", ResourceType = typeof(App_GlobalResources.globalUI))]
        public string CellNumber { get; set; }
    }

    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "PhoneNumber", ResourceType = typeof(App_GlobalResources.globalUI))]
        public string Number { get; set; }
    }

    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "Code", ResourceType = typeof(App_GlobalResources.globalUI))]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "PhoneNumber", ResourceType = typeof(App_GlobalResources.globalUI))]
        public string PhoneNumber { get; set; }
    }

    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }
}