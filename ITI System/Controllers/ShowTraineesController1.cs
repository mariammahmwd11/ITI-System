using ITI_System.Models;
using ITI_System.Repositry;
using ITI_System.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITI_System.Controllers
{
    [Authorize]
    public class ShowTraineesController1 : Controller
    {
        ItraineeRepositry traineeRepositry;
        IcrsResultRepositry crsRepositry;
        IDeptReprositry deptRepositry;
        listTrainee_listcourse _list = new listTrainee_listcourse();

        public ShowTraineesController1(ItraineeRepositry traineeRepositry, IcrsResultRepositry crsRepositry, IDeptReprositry deptRepositry)
        {
            this.traineeRepositry = traineeRepositry;
            this.crsRepositry = crsRepositry;
            this.deptRepositry = deptRepositry;
            
        }

        
        public IActionResult Index()
        {
            
            
            _list.list =  traineeRepositry. TraineeDetails();
            _list.list2 = crsRepositry.GetResultsByTraineeId();
            return View("Show_traines",_list);
        }
        public IActionResult showallresult(int id)
        {
            List<crsResult> results = crsRepositry.getallresult(id);



            return View("Show_all_result", results);
        }
    }
}
