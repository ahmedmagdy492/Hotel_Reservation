using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Hotels_Resrevation.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
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
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources.Login.Login), ErrorMessageResourceName = "Required")]
        [EmailAddress(ErrorMessageResourceType = typeof(Hotels_Resrevation.Resources.Login.Login), ErrorMessageResourceName = "EmailAddress")]
        [Display(ResourceType = typeof(Hotels_Resrevation.Resources.Login.Login), Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Login.Login), ErrorMessageResourceName = "Required")]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Resources.Login.Login), Name = "Password")]
        public string Password { get; set; }

        [Display(ResourceType = typeof(Resources.Login.Login) ,Name = "Remember_Me")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources.Login.Login), ErrorMessageResourceName = "Required")]
        [EmailAddress(ErrorMessageResourceType = typeof(Hotels_Resrevation.Resources.Login.Login), ErrorMessageResourceName = "EmailAddress")]
        [Display(ResourceType = typeof(Hotels_Resrevation.Resources.Login.Login), Name = "Email")]
        public string Email { get; set; }

        [StringLength(100, MinimumLength = 6, ErrorMessageResourceType = typeof(Resources.Login.Login), ErrorMessageResourceName = "stringlen")]
        [Required(ErrorMessageResourceType = typeof(Resources.Login.Login), ErrorMessageResourceName = "Required")]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Resources.Login.Login), Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]        
        [Display(ResourceType = typeof(Resources.Login.Login), Name = "Confirm_password")]
        [Compare("Password", ErrorMessageResourceName = "matchPass", ErrorMessageResourceType = typeof(Resources.Login.Login))]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Login.Login), ErrorMessageResourceName = "Required")]
        [Display(ResourceType = typeof(Resources.Login.Login), Name = "TypeOfUser")]
        public string TypeOfUser { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Login.Login), ErrorMessageResourceName = "Required")]
        [Display(ResourceType = typeof(Resources.Login.Login), Name = "Location")]
        public string Location { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
