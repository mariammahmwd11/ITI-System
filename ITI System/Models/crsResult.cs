using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_System.Models
{
    public class crsResult
    {
        public int Id { get; set; }
        public int crsId { get; set; }
      
        public int traineeId { get; set; }
        public string traineeName { get; set; }
        public int degree { get; set; }

        [ForeignKey("crsId")]
        public Course? course { get; set; }
        [ForeignKey("traineeId")]
        public Trainee? trainee { get; set; }
    }
}
