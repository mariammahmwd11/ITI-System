using ITI_System.Models;
using ITI_System.Repositry;
using ITI_System.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ITI_System.Controllers
{
    [Authorize]
    public class InstructorController : Controller
    {
        IinstructorRepositry instructorRepositry;
        ICrsReprositry crsRepositry;
        IDeptReprositry deptRepositry;
        public InstructorController(IinstructorRepositry inst ,ICrsReprositry crs,IDeptReprositry dept)
        {
            instructorRepositry = inst;
            crsRepositry = crs;
            deptRepositry = dept;
        }


        public IActionResult Details()
        {
            List<Instructor> instModel = instructorRepositry.GetAll();
            return View("instructor_view",instModel);
        }

        public IActionResult insdetails(int id)
        {
            Instructor instModel = instructorRepositry.instDetails(id);
            return View("instructor_details", instModel);
        }
        public IActionResult Edit(int id)
        {

           
            InstAndCrsList instfromrequest = instructorRepositry.Edit(id);
            return View("instructor_edit", instfromrequest);
        }
        public IActionResult SaveEdit(int id, InstAndCrsList instfromrequest)
        {
            Instructor instDB = instructorRepositry.GetById(id);
            if (instfromrequest.Name!=null)
            {
                instfromrequest.Id = id;
                instDB.Name = instfromrequest.Name;
                instDB.salary = instfromrequest.salary;
                instDB.imageUrl = instfromrequest.imageUrl;
                instDB.address = instfromrequest.address;
                instDB.deptId = instfromrequest.deptId;
                instDB.crsId = instfromrequest.crsId;


                instructorRepositry.update(instDB);
                instructorRepositry.save();
                return RedirectToAction("Details");
            }
            instfromrequest.courses = crsRepositry.GetAll();
            instfromrequest.departments = deptRepositry.GetAll();
            return View("instructor_edit", instfromrequest );
        }

        public IActionResult Add()
        {
            listdepartment_listcrs_instructor? model= new listdepartment_listcrs_instructor();
            model.deptoptions =deptRepositry.GetAllDeptsWithNameandId();
            model.crsoptions = crsRepositry.GetAllCrsWithNameandId();
            return View("New",model);

        }
        [HttpPost]
        public IActionResult Savenew(listdepartment_listcrs_instructor instfromRequest)
        { Instructor instdb=new Instructor();
            if (instfromRequest.salary >= 4500&&instfromRequest.Name!=null)
            {
               
                
                    instdb.Name = instfromRequest.Name;
                    instdb.salary = instfromRequest.salary;
                    instdb.imageUrl = instfromRequest.imageUrl;
                    instdb.address = instfromRequest.address;
                    instdb.deptId = instfromRequest.deptId;
                    instdb.crsId = instfromRequest.crsId;

                    instructorRepositry.Add(instdb);
                instructorRepositry.save();
                return RedirectToAction("Details");
                
            }

            instfromRequest.deptoptions = deptRepositry.GetAllDeptsWithNameandId();
            instfromRequest.crsoptions = crsRepositry.GetAllCrsWithNameandId();
            return View("New", instfromRequest);
        }
        
        public IActionResult delete(int id)
        {
            instructorRepositry.delete(id);
            instructorRepositry.save();
            return RedirectToAction("Details");
        }
    }
}
