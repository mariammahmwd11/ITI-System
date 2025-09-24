using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_System.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public string imageUrl { get; set; }

        public string address { get; set; }
        public string grade { get; set; }
        public int deptId { get; set; }
        [ForeignKey("deptId")]
        public Department? department { get; set; }


    }
}
