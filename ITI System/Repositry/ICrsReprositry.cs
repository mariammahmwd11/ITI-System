using ITI_System.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ITI_System.Repositry
{
    public interface ICrsReprositry
    {
        public void Add(Course course);

        public void update(Course course);


        public void delete(int id);


        public Course GetById(int id);


        public List<Course> GetAll();

        public void save();


        public List<crsResult> GetCourseResultByID(int id);
        public List<SelectListItem> GetAllCrsWithNameandId();


    }
}
