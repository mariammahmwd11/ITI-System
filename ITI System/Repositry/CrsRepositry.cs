using ITI_System.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ITI_System.Repositry
{
    public class CrsRepositry: ICrsReprositry
    {
        //CRUD Operations
        ModelContext context;
        public CrsRepositry(ModelContext _context)
        {
            context = _context;
        }
        public void Add(Course course)
        {
            context.Add(course);
        }
        public void update(Course course)
        {
            context.Update(course);
        }

        public void delete(int id)
        {
            Course course = GetById(id);
            context.Remove(course);
        }

        public  Course  GetById(int id)
        {
         return  context.Courses.FirstOrDefault(c => c.Id == id);
        }

        public List<Course> GetAll()
        {
            return context.Courses.ToList();
        }
        public void save()
        {
            context.SaveChanges();
        }

        public List<crsResult> GetCourseResultByID(int id)
        {
            return context.crsResults
                .Include(c => c.trainee)
                .Include(r => r.course)
                .Where(c => c.crsId == id)
                .ToList();
        }
        public List<SelectListItem> GetAllCrsWithNameandId()
        {
            return context.Courses
                .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                                .ToList();
        }
    }
}
