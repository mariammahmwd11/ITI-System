using ITI_System.Models;
using ITI_System.Repositry;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITI_System.Controllers
{
    [Authorize]   
    public class DeptController : Controller
    {
        IDeptReprositry deptRepositry;
        public DeptController(IDeptReprositry deptobj)
        {
            deptRepositry = deptobj;
        }
        
        public IActionResult Index()
        {
            List<Department> dept = deptRepositry.GetAll();
            return View("index", dept);
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult saveAdd(Department dept)
        {
            if (dept != null)
            {
                deptRepositry.Add(dept);
                deptRepositry.save();
                return RedirectToAction("Index");
            }
            return View("Add");
        }

       
    }
}
