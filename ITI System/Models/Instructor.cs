using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_System.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]

        public decimal salary { get; set; }
        [Required]
        [RegularExpression(@"^\w+\.(jpg|png)$", ErrorMessage = "Image must be in jpg or png format")]

        public string imageUrl { get; set; }

        public string address { get; set; }

        [Display(Name = "Department")]
        public int deptId { get; set; }
        [ForeignKey("deptId")]
        public Department department { get; set; }
        [Display(Name = "Course")]
        public int crsId { get; set; }
        [ForeignKey("crsId")]
        public Course? course { get; set; }
    }
}
