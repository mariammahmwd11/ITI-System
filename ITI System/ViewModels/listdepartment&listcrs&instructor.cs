using ITI_System.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ITI_System.ViewModels
{
    public class listdepartment_listcrs_instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal salary { get; set; }
        public string imageUrl { get; set; }

        public string address { get; set; }

        [Display(Name = "Department")]
        public int deptId { get; set; }

        [Display(Name = "Course")]
        public int crsId { get; set; }
        public List<SelectListItem> deptoptions { get; set; }
        public List<SelectListItem> crsoptions { get; set; }
    }
}



