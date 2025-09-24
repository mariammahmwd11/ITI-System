using ITI_System.Models;
using ITI_System.Repositry;
using ITI_System.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITI_System.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        ICrsReprositry crsRepositry ;
        IDeptReprositry deptRepositry ;
        public CourseController(IDeptReprositry deptobj, ICrsReprositry crsobj)
        {
            crsRepositry = crsobj;
            deptRepositry = deptobj;
        }
        public IActionResult Index()
        {
            List<Course> crsList = crsRepositry.GetAll();
            return View("View_courses", crsList);
        }
        public IActionResult AddCourse()
        {
            ViewData["depts"] = deptRepositry.GetAll();
            return View("Add_Course");
        }
        public IActionResult SaveAdd(Course crsfrpmRequest)
        {
            if (ModelState.IsValid == true)
            {
                if (crsfrpmRequest.deptId != 0)
                {
                    crsRepositry.Add(crsfrpmRequest);
                    crsRepositry.save();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(nameof(crsfrpmRequest.deptId), "Please select a department.");
                }
            }
            ViewData["depts"] = deptRepositry.GetAll();
            return View("Add_Course");

        }
        public IActionResult checkname(string Name)
        {
            if (Name.Contains("ITI"))
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }
        public IActionResult checkdegree(int degree, int minDegree)
        {
            if (degree > minDegree)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }

        public IActionResult Edit(int id)
        {
            ViewData["depts"] = deptRepositry.GetAll();

            Course crsfromdb = crsRepositry.GetById(id);
            if (crsfromdb == null)
            {
                return NotFound();
            }
            return View("Edit_Course", crsfromdb);

        }
        public IActionResult saveEdit(int id, Course coursefromrequest)
        {
            Course crsfromdb = crsRepositry.GetById(id);
            if (coursefromrequest.Name == crsfromdb.Name)
            {
                ModelState.Remove(nameof(coursefromrequest.Name));
            }
            if (ModelState.IsValid == true)
            {
                crsfromdb.Name = coursefromrequest.Name;
                crsfromdb.degree = coursefromrequest.degree;
                crsfromdb.minDegree = coursefromrequest.minDegree;
                crsfromdb.hours = coursefromrequest.hours;
                crsfromdb.deptId = coursefromrequest.deptId;
                crsRepositry.update(crsfromdb);
                crsRepositry.save();
                return RedirectToAction("Index");

            }
            ViewData["depts"] = deptRepositry.GetAll();
            return View("Edit_Course", coursefromrequest);
        }
        public IActionResult Course_Result(int id)
        {
            List<crsResult> results = crsRepositry.GetCourseResultByID(id);

            if (!results.Any())
            {
                return View("No_trainee");
              
            }
            return View("Course_Result", results);
        }


    }
}