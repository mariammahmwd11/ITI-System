using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ITI_System.Models;
using ITI_System.ViewModels;
using ITI_System.Repositry;
using Microsoft.AspNetCore.Authorization;

namespace ITI_System.Controllers
{
    [Authorize]
    public class traineeController : Controller
    {
        ItraineeRepositry traineeRepositry;
        IcrsResultRepositry crsRepositry;
        public traineeController(ItraineeRepositry trainee, IcrsResultRepositry crs)
        {
            traineeRepositry = trainee;
            crsRepositry = crs;

        }
        public IActionResult FormResult()
        {
            return View("FormResult");
        }

        [HttpPost]
        public IActionResult showResult(int traineeId, int crsId)
        {
            crsesult_traineeInfo result = new crsesult_traineeInfo();
            var resultfromdb=crsRepositry.getresultfortrainee_in_hisCourses(traineeId, crsId);

            if (resultfromdb != null)
            {
                result.traineeid = resultfromdb.traineeId;
                result.TraineeName = resultfromdb.traineeName;
                result.CourseName = resultfromdb.course.Name;
                result.degree = resultfromdb.degree;
                result.MaxDegree = resultfromdb.course.degree;
                if (result.degree > resultfromdb.course.minDegree)
                {
                    result.state = "Passed";
                    result.color = "table-success";
                }
                else
                {
                    result.state = "Failed";
                    result.color = "table-danger";
                }
            }
           
            else
            {
                ViewBag.Message = "No result found for this Trainee and Course.";
                return View("NotFoundResult");
            }

           

            return View("TableResult", result);
        }

        

    }
}
