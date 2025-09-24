using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ITI_System.ViewModels
{
    public class loginUserViewModel
    {
        [Required(ErrorMessage = "*")]
        [Key]
        public string Name { get; set; }
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
