using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_System.Models
{
    public class Course
    {

        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(3, ErrorMessage = "The name must not be less than 3 chars ")]
        //[Remote("checkname", "Course",ErrorMessage ="name must contain ITI ",AdditionalFields = "hours")]
        [uniqueName_validator]
        public string Name { get; set; }
        [Required]
        [Range(1,200)]
        [Remote("checkdegree", "Course", ErrorMessage = "degree must be greater than minDegree", AdditionalFields = "minDegree")]
        public int degree { get; set; }
        [Required]
        [Range(1, 150)]
        public int minDegree { get; set; }
        [Required]
        [Range(3, 20)]
        public int hours { get; set; }
        [Display (Name="Department Name")]
        public int deptId { get; set; }
        [ForeignKey("deptId")]
        public Department? department { get; set; }
    }
}
