using System.ComponentModel.DataAnnotations;

namespace ITI_System.ViewModels
{
    public class RoleViewModel
    {
        public int id { get; set; }

        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
    }
}
