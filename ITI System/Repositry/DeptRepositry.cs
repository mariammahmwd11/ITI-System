using ITI_System.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ITI_System.Repositry
{
    public class DeptRepositry: IDeptReprositry
    {
        //CRUD Operations
        ModelContext context;
        public DeptRepositry(ModelContext _context)
        {
            context = _context;
        }
        public void Add(Department department)
        {
            context.Add(department);
        }
        public void update(Department department)
        {
            context.Update(department);
        }

        public void delete(int id)
        {
            Department department = GetById(id);
            context.Remove(department);
        }

        public Department GetById(int id)
        {
            return context.Departments.FirstOrDefault(Department => Department.ID == id);
        }

        public List<Department> GetAll()
        {
            return context.Departments.ToList();
        }

        public void save()
        {
            context.SaveChanges();
        }
        public List<SelectListItem> GetAllDeptsWithNameandId()
        {
            return context.Departments
                  .Select(d => new SelectListItem { Value = d.ID.ToString(), Text = d.Name })
                   .ToList();
        }
    }
}
