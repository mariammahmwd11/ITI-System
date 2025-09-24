using ITI_System.Models;
using System.ComponentModel.DataAnnotations;

namespace ITI_System.ViewModels
{
    public class crsesult_traineeInfo
    {
        [Display(Name = " Trainee Id")]
        public int traineeid { get; set; }
        [Display(Name = " Trainee Name")]

        public string TraineeName { get; set; }
        [Display(Name = " Course Name")]
        public int crsid { get; set; }
        public string CourseName { get; set; }
        [Display(Name = " Degree")]
        public int degree { get; set; }
        [Display(Name = " Max Degree")]

        public int MaxDegree { get; set; }
        [Display(Name = " state")]
        public string state { get; set; }
        public string color { get; set; }
        
    }
}
