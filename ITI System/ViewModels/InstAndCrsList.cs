using ITI_System.Models;

namespace ITI_System.ViewModels
{
    public class InstAndCrsList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal salary { get; set; }
        public string imageUrl { get; set; }
         public int crsId { get; set; }
        public int deptId { get; set; }
        public string address { get; set; }
        public List<Course> courses { get; set; }
        public List<Department> departments { get; set; }

    }
}
