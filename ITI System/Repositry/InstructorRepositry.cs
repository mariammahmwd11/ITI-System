using ITI_System.Models;
using ITI_System.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ITI_System.Repositry
{
    public class InstructorRepositry : IinstructorRepositry
    {
        private readonly ModelContext _context;
        public InstructorRepositry(ModelContext context)
        {
            _context = context;

        }
        public void Add(Instructor instructor)
        {
           _context.Add(instructor);
        }

        public void delete(int id)
        {
           _context.Remove(GetById(id));
        }

        public List<Instructor> GetAll()
        {
          return _context.Instructors.ToList();
        }

        public Instructor GetById(int id)
        {  
          return _context.Instructors.FirstOrDefault(e => e.Id == id);
        }

        public void save()
        {
           _context.SaveChanges();
        }

        public void update(Instructor instructor)
        {
            _context.Update(instructor);
        }

        public Instructor instDetails(int id)
        {
             return _context.Instructors.Include (i => i.course)
                               .Include(i => i.department)
                               .FirstOrDefault(i => i.Id == id);
        }

        public InstAndCrsList Edit(int id)
        {
            Instructor inst = _context.Instructors.FirstOrDefault(e => e.Id == id);
            InstAndCrsList instfromrequest = new InstAndCrsList();
            instfromrequest.departments = _context.Departments.ToList();
            instfromrequest.courses = _context.Courses.ToList();
            if (instfromrequest != null)
            {
                instfromrequest.Id = inst.Id;
                instfromrequest.Name = inst.Name;
                instfromrequest.salary = inst.salary;
                instfromrequest.imageUrl = inst.imageUrl;
                instfromrequest.address = inst.address;
                instfromrequest.deptId = inst.deptId;
                instfromrequest.crsId = inst.crsId;
            }
            return instfromrequest;
        }

      
    }
}
