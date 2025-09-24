using ITI_System.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ITI_System.ViewModels
{
    public class RegisterUser
    {
        [Key]
        public int Id { get; set; }
        [Remote(action: "IsUserNameAvailable", controller: "Account")]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string PassWord { get; set; }
      
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("PassWord", ErrorMessage = "Password and Confirmation Password must match.")]
        public string ConfirmPassWord { get; set; }
        public string Address { get; set; }
    }
}
